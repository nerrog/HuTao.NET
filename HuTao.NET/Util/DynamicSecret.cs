using System.Security.Cryptography;
using System.Text;

namespace HuTao.NET.Util
{
    internal class DynamicSecret
    {
        private readonly static string SALT_OVERSEA = "6s25p5ox5y14umn1p61aqyyvbvvl3lrt";
        private readonly static string SALT_CHINESE = "xV8v4Qu54lUKrEYFZkJhB8cuOh9Asafs";

        private readonly static string TEXT = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        internal static string GenerateDynamicSecret()
        {
            int t = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string r = GenerateRandomString(6);
            string h = ComputeMD5Hash($"salt={SALT_OVERSEA}&t={t}&r={r}");
            return $"{t},{r},{h}";
        }

        private static string GenerateRandomString(int n)
        {
            string result = "";
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                result += TEXT[random.Next(TEXT.Length)];
            }

            return result;
        }

        private static string ComputeMD5Hash(string str)
        {
            using (var md5 = MD5.Create())
            {
                byte[] md5byte = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                return BitConverter.ToString(md5byte).ToLower().Replace("-", "");
            }
        }
    }
}
