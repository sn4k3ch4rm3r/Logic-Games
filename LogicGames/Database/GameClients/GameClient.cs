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
            int time;
            int.TryParse(result[0]["playtime"].ToString(), out time);
            return time;
        }

        protected static int getGamesPlayed(string table)
        {
            dbHandler.Open();
            List<Dictionary<string, object>> result = dbHandler.ExecuteRequest($"SELECT COUNT(*) as gamecount FROM {table};");
            dbHandler.Close();
            int games;
            int.TryParse(result[0]["gamecount"].ToString(), out games);
            return games;
        }
    }
}
