using static HuTao.NET.Util.Errors;

namespace HuTao.NET.Util
{
    public class Server
    {
        public class Servers
        {
            public static readonly string ASIA = "os_asia"; //アジア
            public static readonly string TW_HK_MO = "os_cht"; //TW, HK, MO
            public static readonly string AMERICA = "os_usa"; //アメリカ
            public static readonly string EUROPE = "os_euro"; //ヨーロッパ
            public static readonly string CHINA_CELESTIA = "cn_gf01"; //天空島(中国)
            public static readonly string CHINA_IRUMINSUI = "cn_qd01"; //世界樹(中国)
        }
        internal static string GetServer(int uid)
        {
            switch (uid.ToString().Substring(0, 1))
            {
                case "1":
                    return Servers.CHINA_CELESTIA;
                case "2":
                    return Servers.CHINA_CELESTIA;
                case "5":
                    return Servers.CHINA_IRUMINSUI;
                case "6":
                    return Servers.AMERICA;
                case "7":
                    return Servers.EUROPE;
                case "8":
                    return Servers.ASIA;
                case "9":
                    return Servers.TW_HK_MO;
                default:
                    throw new AccountNotFoundException("Could not identify the server for this UID.");
            }
        }
    }
}
