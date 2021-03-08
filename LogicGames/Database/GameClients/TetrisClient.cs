using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGames.Database.GameClients
{
    class TetrisClient : GameClient
    {
        private static string table = "tetris";

        public new static string Highscore 
        {
            get
            {
                try
                {
                    DatabaseHandler.Open();
                    List<Dictionary<string, object>> result = DatabaseHandler.ExecuteRequest($"SELECT score FROM {table} ORDER BY score DESC LIMIT 1");
                    DatabaseHandler.Close();
                    if (result.Count > 0)
                    {
                        return result[0]["score"].ToString();
                    }
                    else return "0";
                }
                catch
                {
                    return "Hiba történt";
                }
            }
        }

        public static int LinesCleared 
        {
            get
            {
                DatabaseHandler.Open();
                List<Dictionary<string, object>> result = DatabaseHandler.ExecuteRequest($"SELECT SUM(cleared) as `lines` FROM {table}");
                DatabaseHandler.Close();
                int cleared;
                int.TryParse(result[0]["lines"].ToString(), out cleared);
                return cleared;
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
