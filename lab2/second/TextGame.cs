using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie.second
{
    public class TextGame
    {
        public string text;
        public TextGame(string name, string genre, List<string> authors, List<int> reviews, List<string> mods, string devices)
        {
            string temp = "<" + name + ">(<" + genre + ">)^<" + devices + ">@";
            for (int i = 0; i < authors.Count; i++)
            {
                temp += "<" + authors[i] + ">";
                if (i + 1 < authors.Count)
                {
                    temp += ",";
                }
            }

            temp += "%";

            for (int i = 0; i < reviews.Count; i++)
            {
                temp += "<" + reviews[i] + ">";
                if (i + 1 < reviews.Count)
                {
                    temp += ",";
                }
            }

            temp += "$";

            for (int i = 0; i < mods.Count; i++)
            {
                temp += "<" + mods[i] + ">";
                if (i + 1 < mods.Count)
                {
                    temp += ",";
                }
            }

            text = temp;
        }

    }
}
