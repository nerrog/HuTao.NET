using HuTao.NET.Models;
using HuTao.NET.Util;
using System.Text.Json.Nodes;
using static HuTao.NET.Util.Errors;

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
        private ICookie cookie;
        private ClientData clientData;
        public Client(ICookie cookie)
        {
            this.cookie = cookie;
            this.clientData = new ClientData();
        }
        public Client(ICookie cookie, ClientData data)
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
            string target_uid = uid ?? cookie.GetHoyoUid();
            string url = clientData.EndPoints.UserStats.Url + $"?uid={target_uid}";
            return await new Wrapper<UserStats>(clientData).FetchData(url, this.cookie);

        }


        public async Task<UserAccountInfo> GetUserAccountInfoByLToken()
        {
            string url = clientData.EndPoints.UserAccountInfo.Url;
            return await new Wrapper<UserAccountInfo>(clientData).FetchData(url, this.cookie);
        }

        public async Task<GameRoles> GetGenshinRoles(bool IsGenshinOnly = true, string region = "")
        {
            string url = clientData.EndPoints.GetRoles.Url;
            url += IsGenshinOnly ? "?game_biz=hk4e_global" : "";
            url += region != "" ? $"&region={region}" : "";
            return await new Wrapper<GameRoles>(clientData).FetchData(url, this.cookie);
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

        public async Task<RewardData> ClaimDailyReward(GenshinUser user)
        {
            RewardData data = new RewardData();

            string infoUrl = clientData.EndPoints.RewardInfo.Url + "&lang=" + clientData.Language;
            string homeUrl = clientData.EndPoints.RewardData.Url + "&lang=" + clientData.Language;
            string claimUrl = clientData.EndPoints.RewardSign.Url + "&lang=" + clientData.Language;

            //home計算用受け取り日数取得
            var info = await FetchDynamicApi(infoUrl, false);
            int days = info?["data"]?["total_sign_day"]?.GetValue<int>() ?? throw new NullReferenceException();
            days--; //受け取り日数(トータルから-1)

            //homeからアイテム名と数量を取得
            var home = await FetchDynamicApi(homeUrl, false);
            string name = home?["data"]?["awards"]?[days]?["name"]?.GetValue<string>() ?? throw new NullReferenceException();
            int amount = home?["data"]?["awards"]?[days]?["cnt"]?.GetValue<int>() ?? throw new NullReferenceException();

            data.RewardName = name;
            data.Amount = amount;

            //reward受け取り
            var sign = await FetchDynamicApi(claimUrl, true);
            int code = sign?["retcode"]?.GetValue<int>() ?? throw new NullReferenceException();
            if (code == 0)
            {
                data.IsSuccessed = true;
            }
            else if (code == -5003)
            {
                throw new DailyRewardAlreadyReceivedException();
            }
            else if (sign?["data"]?["gt_result"]?["is_risk"]?.GetValue<string>() == "true")
            {
                throw new HoyoLabCaptchaBlockException();
            }
            else
            {
                string message = sign?["message"]?.GetValue<string>() ?? throw new NullReferenceException();
                throw new Errors.HoyoLabAPIBadRequestException(message, code);
            }

            return data;
        }




        private async Task<JsonNode> FetchDynamicApi(string url, bool isPost = false)
        {
            HttpResponseMessage res;
            if (!isPost)
            {
                var req = new HttpRequestMessage(HttpMethod.Get, url);

                req.Headers.Add("x-rpc-app_version", "1.5.0");
                req.Headers.Add("x-rpc-client_type", "5");
                req.Headers.Add("x-rpc-language", clientData.Language);
                req.Headers.Add("user-agent", clientData.UserAgent);
                req.Headers.Add("Cookie", cookie.GetCookie());

                res = await clientData.HttpClient.SendAsync(req);
            }
            else
            {
                HttpContent req = new StringContent("");

                req.Headers.Add("x-rpc-app_version", "1.5.0");
                req.Headers.Add("x-rpc-client_type", "5");
                req.Headers.Add("x-rpc-language", clientData.Language);
                clientData.HttpClient.DefaultRequestHeaders.Add("User-Agent", clientData.UserAgent);
                req.Headers.Add("Cookie", cookie.GetCookie());

                res = await clientData.HttpClient.PostAsync(url, req);
            }

            string jsonString = await res.Content.ReadAsStringAsync();

            return JsonNode.Parse(jsonString) ?? throw new NullReferenceException();
        }
    }
}