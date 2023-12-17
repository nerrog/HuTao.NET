using System.Text.Json.Serialization;

namespace HuTao.NET.Models
{
    public class GameRolesData
    {
        public List<GameRole> list { get; set; } = new List<GameRole>();
    }

    public class GameRole
    {
        [JsonPropertyName("game_biz")]
        public string GameRegionName { get; set; } = "";

        [JsonPropertyName("region")]
        public string Region { get; set; } = "";

        [JsonPropertyName("game_uid")]
        public string GameUid { get; set; } = "";

        [JsonPropertyName("nickname")]
        public string NickName { get; set; } = "";

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("is_chosen")]
        public bool IsChosen { get; set; }

        [JsonPropertyName("region_name")]
        public string RegionName { get; set; } = "";

        [JsonPropertyName("is_official")]
        public bool IsOfficial { get; set; }
    }

    public class GameRoles : IHoyoLab
    {
        public int retcode { get; set; }
        public string? message { get; set; }
        public GameRolesData? data { get; set; }
    }
}
