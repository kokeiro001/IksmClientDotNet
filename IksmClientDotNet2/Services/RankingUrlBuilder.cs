namespace IksmClientDotNet.Core.Services
{
    public class RankingUrlBuilder
    {
        public string Url { get; }
        public int Page { get; }

        public string Rule;
        public string Period { get; }

        public RankingUrlBuilder(int year, int month, GameRule gameRule, int page)
        {
            if (year <= 2018 || year >= 3000)
            {
                throw new ArgumentOutOfRangeException(nameof(year));
            }
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(month));
            }
            if (page < 1 || page > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }

            Page = page;

            Rule = gameRule switch
            {
                GameRule.SplatZones => "splat_zones",
                GameRule.TowerControl => "tower_control",
                GameRule.Rainmaker => "rainmaker",
                GameRule.ClamBlitz => "clam_blitz",
                _ => throw new InvalidOperationException(nameof(gameRule)),
            };

            var startTime = new DateTime(year, month, 1);
            var endTime = startTime.AddMonths(1);

            Period = startTime.ToString("yyMMdd") + "T00_" + endTime.ToString("yyMMdd") + "T00";

            Url = $"api/x_power_ranking/{Period}/{Rule}?page={page}";
        }
    }
}