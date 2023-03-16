namespace HuTao.NET.Models
{
    public class Data
    {
        public List<List> list { get; set; } = new List<List>();
    }

    public class List
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
        public Data? data { get; set; }
    }
}
