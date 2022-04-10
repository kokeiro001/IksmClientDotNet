using System.Text.Json.Serialization;

namespace IksmClientDotNet.Core.RawJson.Ranking
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public record Sub(
        [property: JsonPropertyName("image_a")] string ImageA,
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("image_b")] string ImageB,
        [property: JsonPropertyName("name")] string Name
    );

    public record Special(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("image_a")] string ImageA,
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("image_b")] string ImageB
    );

    public record Weapon(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("image")] string Image,
        [property: JsonPropertyName("sub")] Sub Sub,
        [property: JsonPropertyName("thumbnail")] string Thumbnail,
        [property: JsonPropertyName("special")] Special Special,
        [property: JsonPropertyName("id")] string Id
    );

    public record TopRanking(
        [property: JsonPropertyName("unique_id")] string UniqueId,
        [property: JsonPropertyName("weapon")] Weapon Weapon,
        [property: JsonPropertyName("cheater")] bool Cheater,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("x_power")] double XPower,
        [property: JsonPropertyName("rank_change")] string RankChange,
        [property: JsonPropertyName("rank")] int Rank,
        [property: JsonPropertyName("principal_id")] string PrincipalId
    );

    public record Rule(
        [property: JsonPropertyName("multiline_name")] string MultilineName,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("key")] string Key
    );

    public record RankingRoot(
        [property: JsonPropertyName("start_time")] int StartTime,
        [property: JsonPropertyName("end_time")] int EndTime,
        [property: JsonPropertyName("my_ranking")] object MyRanking,
        [property: JsonPropertyName("top_rankings_count")] int TopRankingsCount,
        [property: JsonPropertyName("weapon_ranking")] object WeaponRanking,
        [property: JsonPropertyName("status")] string Status,
        [property: JsonPropertyName("top_rankings")] IReadOnlyList<TopRanking> TopRankings,
        [property: JsonPropertyName("rule")] Rule Rule,
        [property: JsonPropertyName("season_id")] string SeasonId
    );
}
