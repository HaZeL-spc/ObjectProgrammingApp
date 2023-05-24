using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadanie;

namespace lab2.eigth
{
    public class TupleUserAdapter: IUser
    {
        public TupleUser tu;

        public TupleUserAdapter(TupleUser tu)
        {
            this.tu = tu;
        }

        public string Nickname
        {
            get
            {
                Stack<string> tempStack = tu.stackUser.Item2;

                while (tempStack.Pop() != "nickname") ;
                tempStack.Pop();
                string name = tempStack.Pop();

                return name;
            }
        }

        public List<IGame> OwnedGames
        {
            get
            {
                Stack<string> tempStack = tu.stackUser.Item2;
                while (tempStack.Pop() != "ownedGames") ;

                int n = int.Parse(tempStack.Pop());
                List<IGame> temp = new List<IGame>();
                string gamesString = tempStack.Pop();
                string[] gamesArr = gamesString.Split(",");
                for (int i = 0; i < gamesArr.Length; i++)
                {
                    temp.Add(GlobalDictionaries.games[int.Parse(gamesArr[i])]);
                }

                return temp;
            }
        }
    }
}
