using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadanie;

namespace lab2.eigth
{
    public class TupleGameAdapter:IGame, ISetData
    {
        private TupleGame tg;

        public TupleGameAdapter(TupleGame tupleGame)
        {
            tg = tupleGame;
        }
        public string Name
        {
            get
            {
                Stack<string> tempStack = new Stack<string>(tg.stackGame.Item2);

                while (tempStack.Pop() != "name") ;
                tempStack.Pop();
                string name = tempStack.Pop();


                return name;
            }
        }

        public string Genre
        {
            get
            {
                Stack<string> tempStack = new Stack<string>(tg.stackGame.Item2);

                while (tempStack.Pop() != "genre") ;
                tempStack.Pop();
                string genre = tempStack.Pop();


                return genre;
            }
        }
        public string Devices
        {
            get
            {
                Stack<string> tempStack = new Stack<string>(tg.stackGame.Item2);
                while (tempStack.Pop() != "device") ;
                tempStack.Pop();
                string device = tempStack.Pop();

                return device;
            }
        }

        public List<IUser> Authors
        {
            get
            {
                Stack<string> tempStack = new Stack<string>(tg.stackGame.Item2);
                while (tempStack.Pop() != "authors") ;

                int n = int.Parse(tempStack.Pop());
                List<IUser> temp = new List<IUser>();
                string authorsString = tempStack.Pop();
                string[] authorsArr = authorsString.Split(",");
                for (int i = 0; i < authorsArr.Length; i++)
                {
                    temp.Add(GlobalDictionaries.users[int.Parse(authorsArr[i])]);
                }

                return temp;
            }
        }

        public List<IReview> Reviews
        {
            get
            {
                Stack<string> tempStack = new Stack<string>(tg.stackGame.Item2);
                //tempStack = tempStack.Reverse();
                while (tempStack.Pop() != "reviews") ;

                int n = int.Parse(tempStack.Pop());
                List<IReview> temp = new List<IReview>();
                string reviewsString = tempStack.Pop();
                string[] reviewsArr = reviewsString.Split(",");

                if (n > 0)
                    for (int i = 0; i < reviewsArr.Length; i++)
                    {
                        temp.Add(GlobalDictionaries.reviews[int.Parse(reviewsArr[i])]);
                    }

                return temp;
            }
        }

        public List<IMod> Mods
        {
            get
            {
                Stack<string> tempStack = new Stack<string>(tg.stackGame.Item2);
                while (tempStack.Pop() != "mo") ;

                int n = int.Parse(tempStack.Pop());
                List<IMod> temp = new List<IMod>();
                string modsString = tempStack.Pop();
                string[] modsArr = modsString.Split(",");

                for (int i = 0; i < modsArr.Length; i++)
                {
                    temp.Add(GlobalDictionaries.mods[int.Parse(modsArr[i])]);
                }

                return temp;
            }
        }
        public void setData(string field, string value)
        {

        }
    }
}