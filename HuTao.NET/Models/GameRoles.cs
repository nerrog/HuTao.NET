namespace HuTao.NET.Models
{
    public class GameRolesData
    {
        public List<GameRole> list { get; set; } = new List<GameRole>();
    }

    public class GameRole
    {
        public string game_biz { get; set; } = "";
        public string region { get; set; } = "";
        public string game_uid { get; set; } = "";
        public string nickname { get; set; } = "";
        public int level { get; set; }
        public bool is_chosen { get; set; }
        public string region_name { get; set; } = "";
        public bool is_official { get; set; }
    }

    public class GameRoles : IHoyoLab
    {
        public int retcode { get; set; }
        public string? message { get; set; }
        public GameRolesData? data { get; set; }
    }
}
