using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using IksmClientDotNet.ConsoleApp.Services;
using IksmClientDotNet.Core.Services;
using Microsoft.Extensions.Configuration;

namespace IksmClientDotNet.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile(@"AppConfig.json");
            var config = builder.Build().Get<Config>();

            var service = new IksmService(config.IksmSession, config.EditHtmlPath);
            await service.Run();
        }
    }

    class Config
    {
        public string IksmSession { get; set; }
        public string EditHtmlPath { get; set; }
    }

    class IksmService
    {
        private static readonly int AutoUpdateIntervalSecond = 300;

        private readonly string iksmSession;
        private readonly string editHtmlPath;

        private DateTime lastUpdatedAt;
        private bool updating = false;

        public IksmService(string iksmSession, string editHtmlPath)
        {
            this.iksmSession = iksmSession;
            this.editHtmlPath = editHtmlPath;
        }

        public async Task Run()
        {
            InitializeConsoleMode();

            var interval = TimeSpan.FromSeconds(1).TotalMilliseconds;
            System.Timers.Timer timer = new System.Timers.Timer(interval);

            timer.Elapsed += Timer_Elapsed;
            lastUpdatedAt = DateTime.Now;
            timer.Start();

            while (true)
            {
                var keyInfo = Console.ReadKey();

                if (updating)
                {
                    continue;
                }

                if (keyInfo.KeyChar == 'q')
                {
                    break;
                }

                Console.WriteLine("");

                Console.WriteLine("stop timer and Update");
                timer.Stop();

                await Update();

                lastUpdatedAt = DateTime.Now;
                timer.Start();
            }
        }

        private async Task Update()
        {
            if (updating)
            {
                return;
            }

            try
            {
                updating = true;
                await OutputRecentBattleResultHtml();
            }
            finally
            {
                updating = false;
            }
        }

        private async Task OutputRecentBattleResultHtml()
        {
            var iksmClient = new IksmClient(iksmSession);

            var battleResults = await iksmClient.GetBattleResults();

            var data = battleResults.Results.Take(10).Select(x => new BattleDataSummary
            {
                Win = x.MyTeamResult.Name == "WIN!" ? true : false,
                KillCount = x.PlayerResult.KillCount,
                AssistCount = x.PlayerResult.AssistCount,
                DeathCount = x.PlayerResult.DeathCount,
            });

            var htmlEditor = new RecentBattleResultHtmlEditor(editHtmlPath, "OutputHtmlBase.html");
            var debugLog = new StringBuilder();
            foreach (var item in data)
            {
                var text = htmlEditor.AddBattleData(item);
                debugLog.AppendLine(text);
            }

            Console.WriteLine();
            Console.WriteLine(debugLog.ToString());

            htmlEditor.Flush();
        }

        private async void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var remainSecond = (int)(lastUpdatedAt.AddSeconds(AutoUpdateIntervalSecond) - DateTime.Now).TotalSeconds;
            if (remainSecond > 0)
            {
                Console.CursorLeft = 0;
                Console.Write($"自動更新まであと{remainSecond,3}秒(キー入力で強制更新/qキーで終了) ");
                return;
            }

            await Update();

            lastUpdatedAt = DateTime.Now;
        }

        private void InitializeConsoleMode()
        {
            const uint ENABLE_QUICK_EDIT = 0x0040;
            uint consoleMode;
            const int STD_INPUT_HANDLE = -10;

            IntPtr consoleHandle = WinApiNativeMethods.GetStdHandle(STD_INPUT_HANDLE);
            WinApiNativeMethods.GetConsoleMode(consoleHandle, out consoleMode);

            consoleMode &= ~ENABLE_QUICK_EDIT;

            WinApiNativeMethods.SetConsoleMode(consoleHandle, consoleMode);
        }
    }

    class WinApiNativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        public static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);
    }
}
