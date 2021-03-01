using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGames.Database.GameClients
{
    class GameClient
    {
        protected static DatabaseHandler dbHandler = new DatabaseHandler();
        public static int Highscore { get; }

        protected static int getPlaytime(string table)
        {
            dbHandler.Open();
            List<Dictionary<string, object>> result = dbHandler.ExecuteRequest($"SELECT SUM(time) as playtime FROM {table};");
            dbHandler.Close();
            if (result.Count > 0)
            {
                return Convert.ToInt32(result[0]["playtime"]);
            }
            else return 0;
        }

        protected static int getGamesPlayed(string table)
        {
            dbHandler.Open();
            List<Dictionary<string, object>> result = dbHandler.ExecuteRequest($"SELECT COUNT(*) as gamecount FROM {table};");
            dbHandler.Close();
            if (result.Count > 0)
            {
                return Convert.ToInt32(result[0]["gamecount"]);
            }
            else return 0;
        }
    }
}
