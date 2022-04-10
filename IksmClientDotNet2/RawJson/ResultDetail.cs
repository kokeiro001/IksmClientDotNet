namespace IksmClientDotNet.Core.RawJson
{
    public class ResultDetailRoot
    {
        public string BattleNumber { get; set; } = "";
        public string Type { get; set; } = "";
        public GameMode? GameMode { get; set; }
        public Stage? Stage { get; set; }
        public Rule? Rule { get; set; }

        public int StartTime { get; set; }
        public int ElapsedTime { get; set; }

        public int StarRank { get; set; }
        public int PlayerRank { get; set; }
        public Udemae? Udemae { get; set; }

        public PlayerResult? PlayerResult { get; set; }

        public int MyTeamCount { get; set; }
        public int? MyEstimateLeaguePoint { get; set; }
        public TeamResult? MyTeamResult { get; set; }
        public PlayerResult[]? MyTeamMembers { get; set; }

        public int OtherTeamCount { get; set; }
        public int? OtherEstimateLeaguePoint { get; set; }
        public TeamResult? OtherTeamResult { get; set; }
        public PlayerResult[]? OtherTeamMembers { get; set; }

        public float? MaxLeaguePoint { get; set; }
        public int? EstimateGachiPower { get; set; }

        public string TagId { get; set; } = "";
        public int WeaponPaintPoint { get; set; }
        public float? LeaguePoint { get; set; }
    }
}
