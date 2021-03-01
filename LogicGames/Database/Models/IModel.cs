using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGames.Database.Models
{
    interface IModel
    {
        void Save();
        string Table { get; }
    }
}
