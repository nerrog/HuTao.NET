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
Client client = new Client(cookie, new ClientData() { Language = "ja-jp" });

Task.Run(async () =>
{
    UserStats res = await client.FetchUserStats();
    Console.WriteLine(res.data.name);
});
```
