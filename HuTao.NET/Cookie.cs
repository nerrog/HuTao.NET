using System;

namespace HuTao.NET
{
    public interface ICookie
    {
        public string GetCookie();
        public string GetHoyoUid();
    }

    public class Cookie: ICookie
    {
        public string ltoken { get; set; } = string.Empty;
        public string ltuid { get; set; } = string.Empty;

        public string GetCookie()
        {
            return $"ltoken={ltoken}; ltuid={ltuid}";
        }

        public string GetHoyoUid()
        {
            return ltuid;
        }
    }

    public class CookieV2: ICookie
    {
        public string ltoken_v2 { get; set; } = string.Empty;
        public string ltmid_v2 { get; set; } = string.Empty;

        public string ltuid_v2 { get; set; } = string.Empty;
        public string GetCookie()
        {
            return $"ltoken_v2={ltoken_v2}; ltmid_v2={ltmid_v2}; ltuid_v2={ltuid_v2}";
        }

        public string GetHoyoUid()
        {
            return ltuid_v2;
        }
    }

    public class RawCookie : ICookie
    {
        private string cookie;
        private string hoyolabUid;

        public RawCookie(string cookie, string hoyolabUid)
        {
            this.cookie = cookie;
            this.hoyolabUid = hoyolabUid;
        }

        public string GetCookie()
        {
            return cookie;
        }

        public string GetHoyoUid()
        {
            return hoyolabUid;
        }
    }
}
