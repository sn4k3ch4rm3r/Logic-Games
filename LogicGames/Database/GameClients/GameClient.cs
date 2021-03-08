using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicGames.Database;

namespace LogicGames.Database.GameClients
{
    class GameClient
    {
        public static int Highscore { get; }

        protected static int getPlaytime(string table)
        {
            DatabaseHandler.Open();
            List<Dictionary<string, object>> result = DatabaseHandler.ExecuteRequest($"SELECT SUM(time) as playtime FROM {table};");
            DatabaseHandler.Close();
            int time;
            int.TryParse(result[0]["playtime"].ToString(), out time);
            return time;
        }

        protected static int getGamesPlayed(string table)
        {
            DatabaseHandler.Open();
            List<Dictionary<string, object>> result = DatabaseHandler.ExecuteRequest($"SELECT COUNT(*) as gamecount FROM {table};");
            DatabaseHandler.Close();
            int games;
            int.TryParse(result[0]["gamecount"].ToString(), out games);
            return games;
        }
    }
}
