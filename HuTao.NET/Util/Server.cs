using static HuTao.NET.Util.Errors;

namespace HuTao.NET.Util
{
    public class Server
    {
        internal static string GetServer(int uid)
        {
            switch (uid.ToString().Substring(0, 1))
            {
                case "1":
                    return "cn_gf01";
                case "2":
                    return "cn_gf01";
                case "5":
                    return "cn_qd01";
                case "6":
                    return "os_usa";
                case "7":
                    return "os_euro";
                case "8":
                    return "os_asia";
                case "9":
                    return "os_cht";
                default:
                    throw new AccountNotFoundException("Could not identify the server for this UID.");
            }
        }
    }
}
