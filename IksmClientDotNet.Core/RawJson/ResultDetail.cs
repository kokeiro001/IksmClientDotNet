namespace IksmClientDotNet.Core.RawJson
{
    public class ResultDetailRoot
    {
        public string battle_number { get; set; }
        public string type { get; set; }
        public Game_Mode game_mode { get; set; }
        public Stage stage { get; set; }
        public Rule rule { get; set; }

        public int start_time { get; set; }
        public int elapsed_time { get; set; }

        public int star_rank { get; set; }
        public int player_rank { get; set; }
        public Udemae udemae { get; set; }

        public Player_Result player_result { get; set; }

        public int my_team_count { get; set; }
        public int? my_estimate_league_point { get; set; }
        public Team_Result my_team_result { get; set; }
        public Player_Result[] my_team_members { get; set; }

        public int other_team_count { get; set; }
        public int? other_estimate_league_point { get; set; }
        public Team_Result other_team_result { get; set; }
        public Player_Result[] other_team_members { get; set; }

        public float? max_league_point { get; set; }
        public int? estimate_gachi_power { get; set; }

        public string tag_id { get; set; }
        public int weapon_paint_point { get; set; }
        public float? league_point { get; set; }
    }
}
