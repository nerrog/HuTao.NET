namespace HuTao.NET.Tests
{
    public class UnitTest
    {
        private ICookie cookie;
        private Client client;
        private GenshinUser user;

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

        [Fact]
        public async void UserStats()
        {
            var res = await client.FetchUserStats();

            Assert.NotNull(res.data);
        }

        [Fact]
        public async void GetRoles()
        {
            var res = await client.GetGenshinRoles();

            Assert.NotNull(res.data);
        }

        [Fact]
        public async void AccountInfo()
        {
            var res = await client.GetUserAccountInfoByLToken();

            Assert.Equal("OK", res.message);
        }

        [Fact]
        public async void GetGenshinStats()
        {
            var res = await client.FetchGenshinStats(user);

            Assert.Equal("OK", res.message);
        }

        [Fact]
        public async void GetNote()
        {
            var res = await client.FetchDailyNote(user);

            Assert.Equal("OK", res.message);
        }

        [Fact]
        public async void GetLangs()
        {
            var res = await Client.GetAvailableLanguage();

            Assert.Equal("OK", res.message);
        }

        [Fact]
        public async void ClaimDailyReward()
        {
            var res = await client.ClaimDailyReward(user);

            Assert.True(res.IsSuccessed);
        }
    }
}