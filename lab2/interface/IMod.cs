using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie
{
    public interface IMod
{

        public string Name { get; }
        public string Description { get; }

        public List<IUser> Authors { get; }
        public List<IMod> Compability { get; }
}
}
