using System.Text.Json.Serialization;

namespace HuTao.NET.Models
{
    public class GenshinStats : IHoyoLab
    {
        public int retcode { get; set; }
        public string? message { get; set; }

        public GenshinStatsData? data { get; set; }
    }

    public class GenshinStatsData
    {
        [JsonPropertyName("avaters")]
        public Avater[]? Avaters { get; set; }
        //[JsonPropertyName("city_explorations")]
        //public Object[]? CityExplorations { get; set; } //不明
        [JsonPropertyName("homes")]
        public Home[]? Homes { get; set; }
        [JsonPropertyName("role")]
        public Role? Role { get; set; }
        [JsonPropertyName("stats")]
        public Stats? Stats { get; set; }
    }

    public class Avater
    {
        [JsonPropertyName("actived_constellation_num")]
        public int ActivedConstellationNum { get; set; }
        [JsonPropertyName("card_image")]
        public string CardImageUrl { get; set; } = string.Empty;
        [JsonPropertyName("element")]
        public string Element { get; set; } = string.Empty;
        [JsonPropertyName("fetter")]
        public int Fetter { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("image")]
        public string ImageUrl { get; set; } = string.Empty;
        [JsonPropertyName("is_chosen")]
        public bool IsChosen { get; set; }
        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("rearity")]
        public int Rearity { get; set; }
    }

    public class Home
    {
        [JsonPropertyName("comfort_level_icon")]
        public string ComfortLevelIconUrl { get; set; } = string.Empty;
        [JsonPropertyName("comfort_level_name")]
        public string ComfortLevelName { get; set; } = string.Empty;
        [JsonPropertyName("comfort_num")]
        public int ComfortNum { get; set; }
        [JsonPropertyName("icon")]
        public string IconUrl { get; set; } = string.Empty;
        [JsonPropertyName("item_num")]
        public int ItemNum { get; set; }
        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("visit_num")]
        public int VisitNum { get; set; }
    }

    public class Role
    {
        public string AvaterUrl { get; set; } = string.Empty;
        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("nickname")]
        public string NickName { get; set; } = string.Empty;
        [JsonPropertyName("region")]
        public string Region { get; set; } = string.Empty;
    }

    public class Stats
    {
        [JsonPropertyName("achievement_number")]
        public int Achievements { get; set; }
        [JsonPropertyName("active_day_number")]
        public int ActiveDays { get; set; }
        [JsonPropertyName("anemoculus_number")]
        public int Anemoculus { get; set; }
        [JsonPropertyName("dendroculus_number")]
        public int Dendroculus { get; set; }
        [JsonPropertyName("electroculus_number")]
        public int Electroculs { get; set; }
        [JsonPropertyName("geoculus_number")]
        public int Geoculus { get; set; }
        [JsonPropertyName("avatar_number")]
        public int Avaters { get; set; }
        [JsonPropertyName("common_chest_number")]
        public int CommonChestNumber { get; set; }
        [JsonPropertyName("exquisite_chest_number")]
        public int ExquisiteChestNumber { get; set; }
        [JsonPropertyName("luxurious_chest_number")]
        public int LuxuriousChestNumber { get; set; }
        [JsonPropertyName("magic_chest_number")]
        public int MagicChestNumber { get; set; }
        [JsonPropertyName("precious_chest_number")]
        public int PreciousChestNumber { get; set; }
        [JsonPropertyName("domain_number")]
        public int Domains { get; set; }
        [JsonPropertyName("spiral_abyss")]
        public string SpiralAbyss { get; set; } = string.Empty;
        [JsonPropertyName("way_point_number")]
        public int WayPointNumber { get; set; }
    }

    public class WorldExplorations
    {
        [JsonPropertyName("background_image")]
        public string BackgroundImageUrl { get; set; } = string.Empty;
        [JsonPropertyName("cover")]
        public string CoverUrl { get; set; } = string.Empty;
        [JsonPropertyName("exploration_percentage")]
        public int ExplorationPercentage { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("inner_icon")]
        public string InnerIcon { get; set; } = string.Empty;
        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("map_url")]
        public string MapUrl { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("offerings")]
        public WorldOfferings[]? Offerings { get; set; }
        [JsonPropertyName("parent_id")]
        public int ParentId { get; set; }
        [JsonPropertyName("strategy_url")]
        public string StrategyUrl { get; set; } = string.Empty;
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
    }

    public class WorldOfferings
    {
        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;
        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}