namespace IksmClientDotNet.Core.RawJson
{
    public class ResultRoot
    {
        public Result[] results { get; set; }
        public string unique_id { get; set; }
        public Summary summary { get; set; }
    }

    public class Summary
    {
        public int defeat_count { get; set; }
        public float assist_count_average { get; set; }
        public float victory_rate { get; set; }
        public int count { get; set; }
        public float kill_count_average { get; set; }
        public int victory_count { get; set; }
        public float special_count_average { get; set; }
        public float death_count_average { get; set; }
    }

    public class Result
    {
        public int battle_number { get; set; }
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

        public int other_team_count { get; set; }
        public int? other_estimate_league_point { get; set; }
        public Team_Result other_team_result { get; set; }

        public float? max_league_point { get; set; }
        public int? estimate_gachi_power { get; set; }

        public string tag_id { get; set; }
        public int weapon_paint_point { get; set; }
        public float? league_point { get; set; }
    }

    public class Rule
    {
        public string name { get; set; }
        public string key { get; set; }
        public string multiline_name { get; set; }
    }

    public class Team_Result
    {
        public string key { get; set; }
        public string name { get; set; }
    }

    public class Game_Mode
    {
        public string key { get; set; }
        public string name { get; set; }
    }

    public class Player_Result
    {
        public int sort_score { get; set; }
        public int kill_count { get; set; }
        public int assist_count { get; set; }
        public int death_count { get; set; }
        public int special_count { get; set; }
        public int game_paint_point { get; set; }
        public Player player { get; set; }
    }

    public class Player
    {
        public Player_Type player_type { get; set; }
        public string principal_id { get; set; }
        public int player_rank { get; set; }
        public Udemae udemae { get; set; }

        public Skills head_skills { get; set; }
        public Skills clothes_skills { get; set; }
        public Skills shoes_skills { get; set; }

        public Gear head { get; set; }
        public Gear clothes { get; set; }
        public Gear shoes { get; set; }

        public string nickname { get; set; }
        public int star_rank { get; set; }
        public Weapon weapon { get; set; }
    }

    public class Player_Type
    {
        public string style { get; set; }
        public string species { get; set; }
    }

    public class Brand
    {
        public string name { get; set; }
        public Frequent_Skill frequent_skill { get; set; }
        public string id { get; set; }
        public string image { get; set; }
    }

    public class Frequent_Skill
    {
        public string image { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Main
    {
        public string image { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Sub
    {
        public string name { get; set; }
        public string id { get; set; }
        public string image { get; set; }
    }

    public class WeaponSub
    {
        public string image_b { get; set; }
        public string image_a { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Udemae
    {
        public string name { get; set; }
        public object s_plus_number { get; set; }
        public bool is_x { get; set; }

        public bool? is_number_reached { get; set; }
        public int? number { get; set; }
    }

    public class Skills
    {
        public Sub[] subs { get; set; }
        public Main main { get; set; }
    }

    public class Gear
    {
        public int rarity { get; set; }
        public string kind { get; set; }
        public string thumbnail { get; set; }
        public Brand brand { get; set; }
        public string image { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Weapon
    {
        public string thumbnail { get; set; }
        public Special special { get; set; }
        public WeaponSub sub { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }

    public class Special
    {
        public string name { get; set; }
        public string id { get; set; }
        public string image_a { get; set; }
        public string image_b { get; set; }
    }
}
