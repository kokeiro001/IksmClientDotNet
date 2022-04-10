namespace IksmClientDotNet.Core.RawJson
{
    public class ResultRoot
    {
        public Result[]? Results { get; set; }
        public string UniqueId { get; set; } = "";
        public Summary? Summary { get; set; }
    }

    public class Summary
    {
        public int DefeatCount { get; set; }
        public float AssistCountAverage { get; set; }
        public float VictoryRate { get; set; }
        public int Count { get; set; }
        public float KillCountAverage { get; set; }
        public int VictoryCount { get; set; }
        public float SpecialCountAverage { get; set; }
        public float DeathCountAverage { get; set; }
    }

    public class Result
    {
        public int BattleNumber { get; set; }
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

        public int OtherTeamCount { get; set; }
        public int? OtherEstimateLeaguePoint { get; set; }
        public TeamResult? OtherTeamResult { get; set; }

        public float? MaxLeaguePoint { get; set; }
        public int? EstimateGachiPower { get; set; }

        public string TagId { get; set; } = "";
        public int WeaponPaintPoint { get; set; }
        public float? LeaguePoint { get; set; }
    }

    public class Rule
    {
        public string Name { get; set; } = "";
        public string Key { get; set; } = "";
        public string MultilineName { get; set; } = "";
    }

    public class TeamResult
    {
        public string Key { get; set; } = "";
        public string Name { get; set; } = "";
    }

    public class GameMode
    {
        public string Key { get; set; } = "";
        public string Name { get; set; } = "";
    }

    public class PlayerResult
    {
        public int SortScore { get; set; }
        public int KillCount { get; set; }
        public int AssistCount { get; set; }
        public int DeathCount { get; set; }
        public int SpecialCount { get; set; }
        public int GamePaintPoint { get; set; }
        public Player? Player { get; set; }
    }

    public class Player
    {
        public PlayerType? PlayerType { get; set; }
        public string PrincipalId { get; set; } = "";
        public int PlayerRank { get; set; }
        public Udemae? Udemae { get; set; }

        public Skills? HeadSkills { get; set; }
        public Skills? ClothesSkills { get; set; }
        public Skills? ShoesSkills { get; set; }

        public Gear? Head { get; set; }
        public Gear? Clothes { get; set; }
        public Gear? Shoes { get; set; }

        public string Nickname { get; set; } = "";
        public int StarRank { get; set; }
        public Weapon? Weapon { get; set; }
    }

    public class PlayerType
    {
        public string Style { get; set; } = "";
        public string Species { get; set; } = "";
    }

    public class Brand
    {
        public string Name { get; set; } = "";
        public FrequentSkill? FrequentSkill { get; set; }
        public string Id { get; set; } = "";
        public string Image { get; set; } = "";
    }

    public class FrequentSkill
    {
        public string Image { get; set; } = "";
        public string Name { get; set; } = "";
        public string Id { get; set; } = "";
    }

    public class Main
    {
        public string Image { get; set; } = "";
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
    }

    public class Sub
    {
        public string Name { get; set; } = "";
        public string Id { get; set; } = "";
        public string Image { get; set; } = "";
    }

    public class WeaponSub
    {
        public string ImageA { get; set; } = "";
        public string ImageB { get; set; } = "";
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
    }

    public class Udemae
    {
        public string Name { get; set; } = "";
        public object? SPlusNumber { get; set; }
        public bool IsX { get; set; }

        public bool? IsNumberReached { get; set; }
        public int? Number { get; set; }
    }

    public class Skills
    {
        public Sub[]? Subs { get; set; }
        public Main? Main { get; set; }
    }

    public class Gear
    {
        public int Rarity { get; set; }
        public string Kind { get; set; } = "";
        public string Thumbnail { get; set; } = "";
        public Brand? Brand { get; set; }
        public string Image { get; set; } = "";
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
    }

    public class Weapon
    {
        public string Thumbnail { get; set; } = "";
        public Special? Special { get; set; }
        public WeaponSub? Sub { get; set; }
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Image { get; set; } = "";
    }

    public class Special
    {
        public string Name { get; set; } = "";
        public string Id { get; set; } = "";
        public string ImageA { get; set; } = "";
        public string ImageB { get; set; } = "";
    }
}
