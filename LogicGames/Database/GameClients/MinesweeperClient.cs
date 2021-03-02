using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGames.Database.GameClients
{
    class MinesweeperClient : GameClient
    {
        private static string table = "minesweeper";

        public new static int Highscore
        {
            get
            {
                dbHandler.Open();
                List<Dictionary<string, object>> result = dbHandler.ExecuteRequest($"SELECT time FROM {table} ORDER BY time LIMIT 1");
                dbHandler.Close();
                if (result.Count > 0)
                {
                    return Convert.ToInt32(result[0]["time"]);
                }
                else return 0;
            }
        }

        public static int Playtime 
        {
            get { return getPlaytime(table); }
        }
        public static int GamesPlayed 
        {
            get { return getGamesPlayed(table); }
        }
    }
}
