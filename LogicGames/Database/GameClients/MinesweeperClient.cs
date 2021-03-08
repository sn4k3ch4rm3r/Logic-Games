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
                DatabaseHandler.Open();
                List<Dictionary<string, object>> result = DatabaseHandler.ExecuteRequest($"SELECT time FROM {table} WHERE mine = 0 ORDER BY time LIMIT 1");
                DatabaseHandler.Close();
                if (result.Count > 0)
                {
                    return Convert.ToInt32(result[0]["time"]);
                }
                else return 0;
            }
        }

        public static int GamesWon
        {
            get
            {
                DatabaseHandler.Open();
                List<Dictionary<string, object>> result = DatabaseHandler.ExecuteRequest($"SELECT COUNT(id) as won FROM {table} WHERE mine = 0");
                DatabaseHandler.Close();
                int won;
                int.TryParse(result[0]["won"].ToString(), out won);
                return won;
            }
        }

        public static int SquaresDiscovered
        {
            get
            {
                DatabaseHandler.Open();
                List<Dictionary<string, object>> result = DatabaseHandler.ExecuteRequest($"SELECT SUM(checked) as `checked` FROM {table}");
                DatabaseHandler.Close();
                int discovered;
                int.TryParse(result[0]["checked"].ToString(), out discovered);
                return discovered;
            }
        }
        
        public static int FlagsPlaced
        {
            get
            {
                DatabaseHandler.Open();
                List<Dictionary<string, object>> result = DatabaseHandler.ExecuteRequest($"SELECT SUM(flags) as `flags` FROM {table}");
                DatabaseHandler.Close();
                int flags;
                int.TryParse(result[0]["flags"].ToString(), out flags);
                return flags;
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
