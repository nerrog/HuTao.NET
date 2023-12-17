using System.Text.Json.Serialization;

namespace HuTao.NET.Models
{
    public class UserAccountInfo : IHoyoLab
    {
        public int retcode { get; set; }
        public string? message { get; set; }

        public AccountInfoData? data { get; set; }

        public class AccountInfoData
        {
            [JsonPropertyName("account_id")]
            public string? AccountId { get; set; }
            [JsonPropertyName("account_name")]
            public string? AccountName { get; set; }
            [JsonPropertyName("apple_name")]
            public string? AppleName { get; set; }
            [JsonPropertyName("area_code")]
            public string? AreaCode { get; set; }
            [JsonPropertyName("email")]
            public string? Email { get; set; }
            [JsonPropertyName("facebook_name")]
            public string? FacebookName { get; set; }
            [JsonPropertyName("game_center_name")]
            public string? GameCenterName { get; set; }
            [JsonPropertyName("gender")]
            public int Gender { get; set; }
            [JsonPropertyName("google_name")]
            public string? GoogleName { get; set; }
            [JsonPropertyName("mobile")]
            public string? Mobile { get; set; }
            [JsonPropertyName("nick_name")]
            public string? NickName { get; set; }
            [JsonPropertyName("sony_name")]
            public string? SonyName { get; set; }
            [JsonPropertyName("steam_name")]
            public string? SteamName { get; set; }
            [JsonPropertyName("twitter_name")]
            public string? TwitterName { get; set; }
            [JsonPropertyName("user_icon_id")]
            public int UserIconId { get; set; }
        }
    }
}
