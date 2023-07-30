# HuTao.NET

HoyoLab API の非公式 C#ラッパーライブラリ

# usage

```cs
using HuTao.NET


Cookie cookie = new Cookie()
{
    ltoken = "ltoken",
    ltuid = "ltuid"
};

//for use v2 cookie
CookieV2 cookie = new CookieV2()
{
    ltmid_v2 = "ltmid_v2",
    ltoken_v2 = "ltoken_v2",
    ltuid_v2 = "ltuid_v2",
};

//for use raw cookie
RawCookie cookie = new RawCookie("cookie", "hoyolab uid");


Client client = new Client(cookie, new ClientData() { Language = "ja-jp" });

Task.Run(async () =>
{
    UserStats res = await client.FetchUserStats();
    Console.WriteLine(res.data.name);
});
```
