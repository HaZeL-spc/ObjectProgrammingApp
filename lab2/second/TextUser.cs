using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie.second
{
    public class TextUser
    {
        public string text;

        public TextUser(string nickname, List<string> ownedGames)
        {
            string temp = "<" + nickname + ">+";

            for (int i = 0; i < ownedGames.Count; i++)
            {
                temp += "<" + ownedGames[i] + ">";
                if (i + 1 < ownedGames.Count)
                {
                    temp += ",";
                }
            }

            text = temp;
        }

        
    }
}
