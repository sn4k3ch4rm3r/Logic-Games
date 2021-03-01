using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGames.Database.GameClients
{
    class MinesweeperClient : GameClient
    {
        protected override string Table { get { return "minesweeper"; } }

        public override int Highscore => throw new NotImplementedException();
    }
}
