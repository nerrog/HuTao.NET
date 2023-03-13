namespace HuTao.NET
{
    public class EndPoints
    {
        public EndPoint UserStats = new EndPoint("https://bbs-api-os.hoyoverse.com/game_record/card/wapi/getGameRecordCard", true, false);
        public EndPoint UserAccountInfo = new EndPoint("https://api-account-os.hoyolab.com/auth/api/getUserAccountInfoByLToken", true, false);
        public EndPoint GenshinStats = new EndPoint("https://bbs-api-os.hoyolab.com/game_record/genshin/api/index", true, true);
        public EndPoint GenshinDailyNote = new EndPoint("https://bbs-api-os.hoyolab.com/game_record/genshin/api/dailyNote", true, true);
        public EndPoint GetLanguage = new EndPoint("https://bbs-api-os.hoyolab.com/community/misc/wapi/langs", false, false);
    }

    public class EndPoint
    {
        public string Url { get; set; }
        public bool RequireAuth { get; set; }
        public bool RequireDS { get; set; }

        public EndPoint(string url, bool isAuth = true, bool isDS = false)
        {
            Url = url;
            RequireAuth = isAuth;
            RequireDS = isDS;
        }
    }

}
