using System.Text.RegularExpressions;

namespace HuTao.NET.Auth
{
    public class Parser
    {
        private static string parser(string str, string name)
        {
            var r = Regex.Match(str, name + "=[^;]+");
            return r.Value.Replace(name + "=", "");
        }
        public static Cookie CoockieParser(string str)
        {
            string ltoken = parser(str, "ltoken");
            string ltuid = parser(str, "ltuid");
            return new Cookie() { ltoken = ltoken, ltuid = ltuid };
        }

    }
}
