using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGames.Database.Models
{
    class TetrisModel : IModel
    {
        public int Score { get; set; }
        public int Cleared { get; set; }
        public int Time { get; set; }
        public Dictionary<char, int> Shapes { get; set; }
        public string Table { get { return "tetris"; } }

        private DatabaseHandler dbHandler = new DatabaseHandler();
        public TetrisModel()
        {
            this.Score = 0;
            this.Cleared = 0;
            this.Time = 0;
            this.Shapes = new Dictionary<char, int>();
        }

        public TetrisModel(int score, int cleared, int time, Dictionary<char, int> shapes)
        {
            this.Score = score;
            this.Cleared = cleared;
            this.Time = time;
            this.Shapes = shapes;
        }

        public void Save()
        {
            dbHandler.Open();
            dbHandler.ExecuteCommand($"INSERT INTO {Table} (score, cleared, o, i, l, j, t, s, z, time) " +
                $"VALUES ({Score}, {Cleared}, {Shapes['o']}, {Shapes['i']}, {Shapes['l']}, {Shapes['j']}, {Shapes['t']}, {Shapes['s']}, {Shapes['z']}, {Time});");
            dbHandler.Close();
        }
    }
}
