using System.Text.Json.Serialization;

namespace HuTao.NET.Models
{
    public class UserStats : IHoyoLab
    {
        public int retcode { get; set; }
        public string? message { get; set; }
        public UserStatsData? data { get; set; }
    }

    public class UserStatsData
    {
        [JsonPropertyName("list")]
        public List<GameList>? GameLists { get; set; }
        public string? name { get; set; }
        public int? type { get; set; }
        public string? value { get; set; }
    }
    public class GameList
    {
        public bool has_role { get; set; }
        public int game_id { get; set; }
        public string? game_role_id { get; set; }
        public string? nickname { get; set; }
        public string? region { get; set; }
        public int level { get; set; }
        public string? background_image { get; set; }
        public bool is_public { get; set; }
        public List<GameData>? data { get; set; }
        public string? region_name { get; set; }
        public string? url { get; set; }
        public List<DataSwitch>? data_switches { get; set; }
        public List<object>? h5_data_switches { get; set; }
        public string? background_color { get; set; }
    }

    public class GameData
    {
        public string? name { get; set; }
        public int? type { get; set; }
        public string? value { get; set; }
    }

    public class DataSwitch
    {
        public int? switch_id { get; set; }
        public bool? is_public { get; set; }
        public string? switch_name { get; set; }
    }
}
