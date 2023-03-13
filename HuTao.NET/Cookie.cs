namespace HuTao.NET
{
    public class Cookie
    {
        public string ltoken { get; set; } = string.Empty;
        public string ltuid { get; set; } = string.Empty;

        public string GetCookie()
        {
            return $"ltoken={ltoken}; ltuid={ltuid}";
        }
    }
}
