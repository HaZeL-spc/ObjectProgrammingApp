using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie
{
    public interface IUser
{
        public string Nickname { get; }
        public List<IGame> OwnedGames { get; }
}
}
