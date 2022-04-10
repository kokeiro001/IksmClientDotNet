using IksmClientDotNet.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IksmClientDotNet.Core.Services.Tests
{
    public class SecretSettings
    {
        public string IksmSession { get; set; } = "";
        public string RankingRawOutputDirectory { get; set; } = "";
    }

    [TestClass()]
    public class IksmClientTests
    {
        private readonly string iksmSession;
        private readonly string rankingRawOutputDirectory;

        public IksmClientTests()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<IksmClientTests>()
                .Build();

            var secretSettings = config.Get<SecretSettings>();

            iksmSession = secretSettings.IksmSession;

            rankingRawOutputDirectory = secretSettings.RankingRawOutputDirectory;
        }

        [TestMethod()]
        public async Task GetBattleResultsTest()
        {
            var iksmClient = new IksmClient(iksmSession);

            var battleResults = await iksmClient.GetBattleResults();

            Assert.IsNotNull(battleResults);
            Assert.IsNotNull(battleResults.Results);
            Assert.IsTrue(battleResults.Results.Length <= 50);
        }

        [TestMethod()]
        public async Task GetRakingTest()
        {
            var iksmClient = new IksmClient(iksmSession);

            for (int page = 1; page <= 5; page++)
            {
                var rankingUrlBuilder = new RankingUrlBuilder(2022, 3, GameRule.TowerControl, page);

                var rankingRaw = await iksmClient.GetRankingRaw(rankingUrlBuilder);

                var filename = @$"{rankingRawOutputDirectory}\{rankingUrlBuilder.Season}_{rankingUrlBuilder.Rule}_{rankingUrlBuilder.Page}.json";
                File.WriteAllText(filename, rankingRaw);

                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }


        [TestMethod()]
        public async Task DownloadRankings()
        {
            var iksmClient = new IksmClient(iksmSession);

            var now = DateTime.UtcNow;
            var currentSeasonStart = new DateTime(now.Year, now.Month, 1);
            var splatoon2FirstSeadon = new DateTime(2018, 4, 1);

            var rules = new GameRule[]
            {
                GameRule.SplatZones,
                GameRule.TowerControl,
                GameRule.Rainmaker,
                GameRule.ClamBlitz,
            };

            foreach (var rule in rules)
            {
                for (var indexSeason = splatoon2FirstSeadon; indexSeason < currentSeasonStart; indexSeason = indexSeason.AddMonths(1))
                {
                    for (int page = 1; page <= 5; page++)
                    {
                        var rankingUrlBuilder = new RankingUrlBuilder(indexSeason.Year, indexSeason.Month, rule, page);

                        var filepath = @$"{rankingRawOutputDirectory}\{rankingUrlBuilder.Season}_{rankingUrlBuilder.Rule}_{rankingUrlBuilder.Page}.json";

                        if (File.Exists(filepath))
                        {
                            continue;
                        }

                        var rankingRaw = await iksmClient.GetRankingRaw(rankingUrlBuilder);

                        File.WriteAllText(filepath, rankingRaw);

                        await Task.Delay(TimeSpan.FromSeconds(5));
                    }
                }
            }
        }
    }
}