using AngleSharp.Html;
using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IksmClientDotNet.ConsoleApp.Services
{
    public class BattleDataSummary
    {
        public bool Win { get; set; }
        public int KillCount { get; set; }
        public int AssistCount { get; set; }
        public int DeathCount { get; set; }
    }

    public class RecentBattleResultHtmlEditor
    {
        private readonly string outputHtmlPath;
        private readonly string baseHtmlPath;

        private List<(string text, string cssClass)> data = new List<(string text, string cssClass)>();

        public RecentBattleResultHtmlEditor(string outputHtmlPath, string baseHtmlPath)
        {
            this.outputHtmlPath = outputHtmlPath;
            this.baseHtmlPath = baseHtmlPath;
        }

        public string AddBattleData(BattleDataSummary battleData)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(battleData.Win? "勝 " : "負 ");

            var totalKill = battleData.KillCount + battleData.AssistCount;
            var assist = battleData.AssistCount;
            var death = battleData.DeathCount;
            stringBuilder.Append($"{totalKill,2}({assist,2})k/{death,2}d");

            var cssClass = battleData.Win ? "win" : "lose";

            var text = stringBuilder.ToString();
            data.Add((text, cssClass));

            return text;
        }

        public void Flush()
        {
            var baseHtml = File.ReadAllText(baseHtmlPath);

            var htmlParser = new HtmlParser();
            var htmlDocument = htmlParser.ParseDocument(baseHtml);

            var div = htmlDocument.QuerySelector("div");

            foreach (var (text, cssClass) in data)
            {
                var item = htmlDocument.CreateElement("span");
                item.TextContent = text;
                item.ClassList.Add(cssClass);
                div.AppendChild(item);

                div.AppendChild(htmlDocument.CreateElement("br"));
            }

            using (var textWriter = new StringWriter())
            {
                var formatter = new PrettyMarkupFormatter();
                htmlDocument.ToHtml(textWriter, formatter);

                File.WriteAllText(outputHtmlPath, textWriter.ToString());
            }
        }
    }
}
