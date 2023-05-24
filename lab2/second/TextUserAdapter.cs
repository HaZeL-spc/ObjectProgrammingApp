using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace zadanie.second
{
    public class TextUserAdapter:IUser
    {
        public TextUser tm;

        public TextUserAdapter(TextUser tm2)
        {
            tm = tm2;
        }

        public override string ToString()
        {
            return "nickname: " + Nickname;
        }
        public string Nickname
        {
            get
            {
                string text = tm.text;
                int index1 = text.IndexOf("+");

                return text.Substring(1, index1 - 2);
            }
        }

        public List<IGame> OwnedGames => throw new NotImplementedException();
    }
}
