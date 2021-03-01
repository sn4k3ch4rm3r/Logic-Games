using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGames.Database.GameClients
{
    class Game2048Client : GameClient
    {
        protected override string Table { get { return "game2048"; } }

        public override int Highscore => throw new NotImplementedException();
    }
}
