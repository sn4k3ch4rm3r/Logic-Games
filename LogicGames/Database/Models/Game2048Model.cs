using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGames.Database.Models
{
    class Game2048Model : IModel
    {
        public int Score { get; set; }
        public Dictionary<int, int> Tiles { get; set; }
        public int Time { get; set; }
        public string Table { get { return "game2048"; } }

        private DatabaseHandler dbHandler = new DatabaseHandler();

        public Game2048Model()
        {
            this.Score = 0;
            this.Tiles = new Dictionary<int, int>();
            this.Time = 0;
            Tiles[-1] = 0;
            for (int i = 1; i <= 11; i++)
            {
                Tiles[(int)Math.Pow(2, i)] = 0;
            }
        }
       
        public Game2048Model(int score, Dictionary<int,int> tiles, int time)
        {
            this.Score = score;
            this.Tiles = tiles;
            this.Time = 0;
        }

        public void Save()
        {
            dbHandler.Open();
            dbHandler.ExecuteCommand($"INSERT INTO {Table} (score, tile2, tile4, tile8, tile16, tile32, tile64, tile128, tile256, tile512, tile1024, tile2048, tileMore, time) " +
                $"VALUES ({Score}, {Tiles[2]}, {Tiles[4]}, {Tiles[8]}, {Tiles[16]}, {Tiles[32]}, {Tiles[64]}, {Tiles[128]}, {Tiles[256]}, {Tiles[512]}, {Tiles[1024]}, {Tiles[2048]}, {Tiles[-1]}, {Time});");
            dbHandler.Close();
        }
    }
}
