namespace IksmClientDotNet.Core.RawJson
{
    public class RankingRoot
    {
        public object my_ranking { get; set; }
        public string season_id { get; set; }
        public int start_time { get; set; }
        public object weapon_ranking { get; set; }
        public string status { get; set; }
        public int end_time { get; set; }
        public int top_rankings_count { get; set; }
        public Top_Rankings[] top_rankings { get; set; }
        public Rule rule { get; set; }
    }

    public class Top_Rankings
    {
        public string rank_change { get; set; }
        public int rank { get; set; }
        public string principal_id { get; set; }
        public Weapon weapon { get; set; }
        public string name { get; set; }
        public float x_power { get; set; }
        public string unique_id { get; set; }
        public bool cheater { get; set; }
    }
}
