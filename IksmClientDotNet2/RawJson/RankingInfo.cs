namespace IksmClientDotNet.Core.RawJson
{
    public class RankingRoot
    {
        public object? MyRanking { get; set; }
        public string SeasonId { get; set; } = "";
        public int StartTime { get; set; }
        public object? WeaponRanking { get; set; }
        public string Status { get; set; } = "";
        public int EndTime { get; set; }
        public int TopRankingsCount { get; set; }
        public TopRankings[]? TopRankings { get; set; }
        public Rule? Rule { get; set; }
    }

    public class TopRankings
    {
        public string RankChange { get; set; } = "";
        public int Rank { get; set; }
        public string PrincipalId { get; set; } = "";
        public Weapon? Weapon { get; set; }
        public string Name { get; set; } = "";
        public float XPower { get; set; }
        public string UniqueId { get; set; } = "";
        public bool Cheater { get; set; }
    }
}
