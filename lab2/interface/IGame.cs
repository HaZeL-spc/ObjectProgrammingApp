using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie
{
    public interface IGame
    {
        public string Name { get; }
        public string Genre { get; }
        public string Devices { get; }

        public List<IUser> Authors { get; }
        public List<IReview> Reviews { get; }
        public List<IMod> Mods { get; }
    }
}
