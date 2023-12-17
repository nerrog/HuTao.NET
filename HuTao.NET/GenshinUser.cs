using HuTao.NET.Models;
using HuTao.NET.Util;

namespace HuTao.NET
{
    public class GenshinUser
    {
        public int uid;
        public string server;
        private readonly static int GENSHIN_GAME_ID = 2;

        public GenshinUser(int uid)
        {
            this.uid = uid;
            this.server = Server.GetServer(uid);
        }

        public static GenshinUser GetUIDFromHoyoLab(UserStats user)
        {
            int uid = 0;
            Parallel.ForEach(user.data!.GameLists!, game =>
            {
                if (game.GameId == GENSHIN_GAME_ID)
                {
                    uid = int.Parse(game.GameUid!);
                }
            });

            if (uid == 0)
            {
                throw new Errors.AccountNotFoundException();
            }

            return new GenshinUser(uid);
        }
    }
}
