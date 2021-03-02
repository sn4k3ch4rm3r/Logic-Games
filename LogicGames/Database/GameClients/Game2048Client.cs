﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGames.Database.GameClients
{
    class Game2048Client : GameClient
    {
        private static string table = "game2048";

        public new static int Highscore
        {
            get
            {
                dbHandler.Open();
                List<Dictionary<string, object>> result = dbHandler.ExecuteRequest($"SELECT score FROM {table} ORDER BY score DESC LIMIT 1");
                dbHandler.Close();
                if (result.Count > 0)
                {
                    return Convert.ToInt32(result[0]["score"]);
                }
                else return 0;
            }
        }

        public static int GamesWon
        {
            get
            {
                dbHandler.Open();
                List<Dictionary<string, object>> result = dbHandler.ExecuteRequest($"SELECT COUNT(id) as won FROM {table} WHERE tile2048 > 0");
                dbHandler.Close();
                int won;
                int.TryParse(result[0]["won"].ToString(), out won);
                return won;
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