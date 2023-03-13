using HuTao.NET.Models;

namespace HuTao.NET
{
    public class ClientData
    {
        public string UserAgent { get; set; } = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36";

        public EndPoints EndPoints { get; set; } = new EndPoints();

        public string Language { get; set; } = "en-us";
        public HttpClient HttpClient { get; set; } = new HttpClient();
    }
    public class Client
    {
        private Cookie cookie;
        private ClientData clientData;
        public Client(Cookie cookie)
        {
            this.cookie = cookie;
            this.clientData = new ClientData();
        }
        public Client(Cookie cookie, ClientData data)
        {
            this.cookie = cookie;
            this.clientData = data;
        }

        /// <summary>
        /// ゲームステータスを取得します
        /// </summary>
        /// <param name="uid">hoyolabのuid</param>
        /// <returns></returns>
        public async Task<UserStats> FetchUserStats(string? uid = null)
        {
            string target_uid = uid ?? cookie.ltuid;
            string url = clientData.EndPoints.UserStats + $"?uid={target_uid}";
            return await new Wrapper<UserStats>(clientData).FetchData(url, this.cookie);
        }


        public async Task<UserAccountInfo> GetUserAccountInfoByLToken()
        {
            string url = clientData.EndPoints.UserAccountInfo.Url;
            return await new Wrapper<UserAccountInfo>(clientData).FetchData(url, this.cookie);
        }

        public async Task<GenshinStats> FetchGenshinStats(GenshinUser user)
        {
            string url = clientData.EndPoints.GenshinStats.Url + $"?server={user.server}&role_id={user.uid}";
            return await new Wrapper<GenshinStats>(clientData).FetchData(url, this.cookie, true);
        }

        public async Task<DailyNote> FetchDailyNote(GenshinUser user)
        {
            string url = clientData.EndPoints.GenshinDailyNote.Url + $"?server={user.server}&role_id={user.uid}";
            return await new Wrapper<DailyNote>(clientData).FetchData(url, this.cookie, true);
        }

        public static async Task<Languages> GetAvailableLanguage()
        {
            ClientData data = new ClientData();
            return await new Wrapper<Languages>(data).FetchData(data.EndPoints.GetLanguage.Url);
        }
    }
}