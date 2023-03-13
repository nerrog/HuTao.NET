using HuTao.NET.Auth;

namespace HuTao.NET.Tests
{
    public class AuthTest
    {
        /// <summary>
        /// 自動化できないテスト
        /// </summary>
        //[Fact]
        internal async void BrowserAuth()
        {
            BrowserLogin login = new BrowserLogin();
            login.OpenBrowser();
            await Task.Delay(30000); //30秒後に取得する
            Cookie cookie = login.GetCookie();

            Assert.NotNull(cookie);

            login.CloseBrowser();
        }

        [Fact]
        public void Parse()
        {
            string str = "mi18nLang=ja-jp; _MHYUUID=00000000-xxxx-0000-xxxx-000000000000; G_ENABLED_IDPS=google; ltoken=xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx; ltuid=00000000; DEVICEFP_SEED_ID=xxxxxxxxxxxxxxxx; DEVICEFP_SEED_TIME=0000000000000; DEVICEFP=0000000000000; G_AUTHUSER_H=0";
            Cookie cookie = Parser.CoockieParser(str);

            Assert.False(string.IsNullOrEmpty(cookie.ltuid) || string.IsNullOrEmpty(cookie.ltoken));
        }
    }
}
