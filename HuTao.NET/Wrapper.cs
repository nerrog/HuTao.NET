using HuTao.NET.Models;
using HuTao.NET.Util;
using System.Text.Json;
using static HuTao.NET.Util.Errors;

namespace HuTao.NET
{
    internal class Wrapper<T> where T : IHoyoLab
    {
        private HttpClient client;
        private string ua;
        private string lang;

        internal Wrapper(ClientData data)
        {
            this.client = data.HttpClient;
            this.ua = data.UserAgent;
            this.lang = data.Language;
        }

        internal async Task<T> FetchData(string url, Cookie? cookie = null, bool RequireDS = false)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, url);

            req.Headers.Add("x-rpc-app_version", "1.5.0");
            req.Headers.Add("x-rpc-client_type", "5");
            req.Headers.Add("x-rpc-language", lang);
            req.Headers.Add("user-agent", ua);
            if (cookie != null) req.Headers.Add("Cookie", cookie.GetCookie());
            if (RequireDS) req.Headers.Add("ds", DynamicSecret.GenerateDynamicSecret());

            var res = await client.SendAsync(req);
            string jsonString = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode)
            {
                var jsonData = JsonSerializer.Deserialize<T>(jsonString);

                if (jsonData == null) throw new NullReferenceException();
                if (jsonData.retcode != 0) throw new HoyoLabAPIBadRequestException(jsonData.message!, jsonData.retcode);

                return jsonData;
            }
            else
            {
                throw new HttpRequestException();
            }
        }
    }
}
