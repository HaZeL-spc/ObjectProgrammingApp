using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace zadanie.second
{
    public class TextModAdapter : IMod
    {
        public TextMod tm;

        public TextModAdapter(TextMod tm2)
        {
            tm = tm2;
        }

        public override string ToString()
        {
            return "name: " + Name + ", description: " + Description;
        }

        public string Name
        {
            get
            {
                string text = tm.text;
                int index1 = text.IndexOf("#");

                return text.Substring(1, index1 - 2);
            }
        }

        public string Description
        {
            get
            {
                string text = tm.text;
                string[] arraySplit = text.Split("#");
                return arraySplit[1].Substring(1, arraySplit[1].Length - 2);
            }
        }

        public List<IUser> Authors
        {
            get
            {
                string text = tm.text;
                string[] arraySplit = text.Split("#");
                string authorsStr = arraySplit[2].Substring(0, arraySplit[2].IndexOf("("));
                string[] authorsArr = authorsStr.Split(",");

                List<IUser> usersTemp = new List<IUser>();

                for (int i = 0; i < authorsArr.Length; i++)
                {
                    string modName = authorsArr[i].Substring(1, authorsArr[i].Length - 2);
                    foreach (KeyValuePair<int, IUser> kvp in GlobalDictionaries.users)
                    {
                        if (kvp.Key >= 100 && kvp.Key < 200)
                        if (modName == kvp.Value.Nickname)
                            usersTemp.Add(kvp.Value);
                    }
                }


                return usersTemp;
            }    
        }


        public List<IMod> Compability => throw new NotImplementedException();
    }
}
