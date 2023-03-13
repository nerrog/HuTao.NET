namespace HuTao.NET.Models
{
    public class UserAccountInfo : IHoyoLab
    {
        public int retcode { get; set; }
        public string? message { get; set; }

        public AccountInfoData? data { get; set; }

        public class AccountInfoData
        {
            public string? account_id { get; set; }

            public string? account_name { get; set; }

            public string? apple_name { get; set; }

            public string? area_code { get; set; }

            public string? email { get; set; }

            public string? facebook_name { get; set; }

            public string? game_center_name { get; set; }

            public int gender { get; set; }

            public string? google_name { get; set; }

            public string? mobile { get; set; }

            public string? nick_name { get; set; }

            public string? sony_name { get; set; }

            public string? steam_name { get; set; }

            public string? twitter_name { get; set; }

            public int user_icon_id { get; set; }
        }
    }
}
