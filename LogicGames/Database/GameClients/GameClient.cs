using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGames.Database.GameClients
{
    abstract class GameClient
    {
        protected DatabaseHandler dbHandler = new DatabaseHandler();
        protected abstract string Table { get; }
        public abstract int Highscore { get; }
        public int Playtime 
        {
            get
            {
                dbHandler.Open();
                List<Dictionary<string, object>> result = dbHandler.ExecuteRequest($"SELECT SUM(time) as playtime FROM {Table};");
                dbHandler.Close();
                if (result.Count > 0)
                {
                    return Convert.ToInt32(result[0]["playtime"]);
                }
                else return 0;
            }
        }

        public int GamesPlayed
        {
            get
            {
                dbHandler.Open();
                List<Dictionary<string, object>> result = dbHandler.ExecuteRequest($"SELECT COUNT(*) as gamecount FROM {Table};");
                dbHandler.Close();
                if (result.Count > 0)
                {
                    return Convert.ToInt32(result[0]["gamecount"]);
                }
                else return 0;
            }
        }
    }
}
