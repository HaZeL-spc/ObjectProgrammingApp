using lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace zadanie.second
{
    public class TextGameAdapter:IGame, ISetData
    {
        public TextGame tg;

        public TextGameAdapter(TextGame tg2)
        {
            tg = tg2;
        }

        public override string ToString()
        {
            return "name: " + Name + ", genre: " + Genre + ", devices: " + Devices;
        }
        public string Name
        {
            get
            {
                string text = tg.text;
                int index1 = text.IndexOf("(");
                string word = text.Substring(1, index1 - 2);

                return word;
            }
        }

        public string Genre
        {
            get
            {
                string text = tg.text;
                int index1 = text.IndexOf("(");
                int index2 = text.IndexOf(")");
                return text.Substring(index1 + 2, index2 - index1 - 3);
            }
        }

        public string Devices
        {
            get
            {
                string text = tg.text;
                int index1 = text.IndexOf("^");
                int index2 = text.IndexOf("@");
                return text.Substring(index1 + 2, index2 - index1 - 3);
            }
        }

        public List<IUser> Authors
        {
            get
            {
                string text = tg.text;
                List<IUser> temp = new List<IUser>();
                int index1 = text.IndexOf("@");
                int index2 = text.IndexOf("%");

                string authorsSubstr = text.Substring(index1 + 1, index2 - 1);
                string[] authorsArr = authorsSubstr.Split(",");

                for (int i = 0; i < authorsArr.Length; i++)
                {
                    string authorSpec = authorsArr[i].Substring(1, authorsArr[i].Length - 2);
                    for (int j = 0; j < GlobalDictionaries.users.Count; j++)
                    {
                        if (authorSpec == GlobalDictionaries.users[j].Nickname)
                            temp.Add(GlobalDictionaries.users[j]);
                    }
                }

                return temp;
            }
        }

        public List<IReview> Reviews
        {
            get
            {
                string text = tg.text;
                List<IReview> temp = new List<IReview>();
                int index1 = text.IndexOf("%");
                int index2 = text.IndexOf("$");
                if (index1 + 1 > index2 - 1) return temp;

                string reviewsSubstr = text.Substring(index1 + 1, index2 - index1 - 1);
                string[] reviewsArr = reviewsSubstr.Split(",");

                for (int i = 0; i < reviewsArr.Length; i++)
                {
                    string indexReview = reviewsArr[i].Substring(1, reviewsArr[i].Length - 2);
                    foreach (KeyValuePair<int, IReview> kvp in GlobalDictionaries.reviews)
                    {
                        if (int.Parse(indexReview) == kvp.Key)
                            temp.Add(kvp.Value);
                    }
                }

                return temp;
            }
        }

        public List<IMod> Mods
        {
            get
            {
                string text = tg.text;
                List<IMod> temp = new List<IMod>();
                int index1 = text.IndexOf("$");
                int index2 = text.Length;

                string modsSubstr = text.Substring(index1 + 1, index2 - 1);
                string[] modsArr = modsSubstr.Split(",");

                for (int i = 0; i < modsArr.Length; i++)
                {
                    string modName = modsArr[i].Substring(1, modsArr[i].Length - 2);
                    foreach (KeyValuePair<int, IMod> kvp in GlobalDictionaries.mods)
                    {
                        if (modName == kvp.Value.Name)
                            temp.Add(kvp.Value);
                    }
                }

                return temp;
            }
        }
        public void setData(string field, string value)
        {

        }
    }
}
