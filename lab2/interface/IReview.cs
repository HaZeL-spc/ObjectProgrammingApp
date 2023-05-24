using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie
{
    public interface IReview
{
        public string Text { get;  }
        public int Rating { get; }
        
        public IUser Author { get; }
}
}
