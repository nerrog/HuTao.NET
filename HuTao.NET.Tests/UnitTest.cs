using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using static HuTao.NET.Util.Errors;

namespace HuTao.NET.Tests
{
    public class UnitTest
    {
        private ICookie cookie;
        private Client client;
        private GenshinUser user;

        public static string TEST_LOG_FILE_NAME = "TestLog.log";

        public UnitTest()
        {
            List<string> str = new();
            foreach (string line in File.ReadLines("./tokens.txt"))
            {
                str.Add(line);
            }
            /*
            cookie = new Cookie()
            {
                ltoken = str[0],
                ltuid = str[1],
            };*/
            cookie = new CookieV2()
            {
                ltmid_v2 = str[0],
                ltoken_v2 = str[1],
                ltuid_v2 = str[2],
            };
            client = new Client(cookie, new ClientData() { Language = "ja-jp" });
            user = new GenshinUser(int.Parse(str[3]));
        }

        [ModuleInitializer]
        internal static void LogInit()
        {
            //ログファイル初期化
            if (File.Exists(TEST_LOG_FILE_NAME)) { File.Delete(TEST_LOG_FILE_NAME); };
            File.AppendAllText(TEST_LOG_FILE_NAME, "Unit Test: " + DateTime.Now.ToString() + "\n");
        }

        private void WriteLog(object obj, string logName)
        {
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.AppendAllText(TEST_LOG_FILE_NAME, "[UnitTest]["+logName+"]\n"+json+"\n");
        }

        [Fact]
        public async void UserStats()
        {
            var res = await client.FetchUserStats();

            Assert.NotNull(res.data);
            WriteLog(res, "FetchUserStats");
        }

        [Fact]
        public async void GetRoles()
        {
            var res = await client.GetGenshinRoles();

            Assert.NotNull(res.data);
            WriteLog(res, "GetGenshinRoles");
        }

        [Fact]
        public async void AccountInfo()
        {
            var res = await client.GetUserAccountInfoByLToken();

            Assert.Equal("OK", res.message);
            WriteLog(res, "GetUserAccountInfoByLToken");
        }

        [Fact]
        public async void GetGenshinStats()
        {
            var res = await client.FetchGenshinStats(user);

            Assert.Equal("OK", res.message);
            WriteLog(res, "FetchGenshinStats");
        }

        [Fact]
        public async void GetNote()
        {
            var res = await client.FetchDailyNote(user);

            Assert.Equal("OK", res.message);
            WriteLog(res, "FetchDailyNote");
        }

        [Fact]
        public async void GetLangs()
        {
            var res = await Client.GetAvailableLanguage();

            Assert.Equal("OK", res.message);
            WriteLog(res, "GetAvailableLanguage");
        }

        [Fact]
        public async void ClaimDailyReward()
        {
            try
            {
                var res = await client.ClaimDailyReward(user);
                Assert.True(res.IsSuccessed);
                WriteLog(res, "ClaimDailyReward");
            }
            catch(DailyRewardAlreadyReceivedException)
            {
                Assert.True(true, "daily reward is already received!");
            }
            

        }
    }
}