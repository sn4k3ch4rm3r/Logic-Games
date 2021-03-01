using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGames.Database.Models
{
    class MinesweeperModel : IModel
    {
        public int Time { get; set; }
        public int Flags { get; set; }
        public int Checked { get; set; }
        public bool Mine { get; set; }

        private DatabaseHandler dbHandler = new DatabaseHandler();
        public string Table { get { return "minesweeper"; } }

        public MinesweeperModel()
        {
            this.Time = 0;
            this.Flags = 0;
            this.Checked = 0;
            this.Mine = false;
        }

        public MinesweeperModel(int time, int flags, int checkedCount, bool mine)
        {
            this.Time = time;
            this.Flags = flags;
            this.Checked = checkedCount;
            this.Mine = mine;
        }

        public void Save()
        {
            dbHandler.Open();
            dbHandler.ExecuteCommand($"INSERT INTO {Table} (time, flags, checked, mine) VALUES ({Time}, {Flags}, {Checked}, {(Mine?1:0)})");
            dbHandler.Close();
        }
    }
}
