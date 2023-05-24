using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie.second
{
    public class TextMod
    {
        public string text;

        public TextMod(string name, string description, List<string> authors, List<string> compatibility)
        {
            string temp = "<" + name + ">#<" + description + ">#";

            for (int i = 0; i < authors.Count; i++)
            {
                temp += "<" + authors[i] + ">";
                if (i + 1 < authors.Count)
                {
                    temp += ",";
                }
            }

            temp += "(";

            for (int i = 0; i < compatibility.Count; i++)
            {
                temp += "<" + compatibility[i] + ">";
                if (i + 1 < compatibility.Count)
                {
                    temp += ",";
                }
            }

            temp += ")";

            text = temp;
        }

    }
}
