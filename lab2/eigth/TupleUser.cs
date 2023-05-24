using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadanie;

namespace lab2.eigth
{
    public class TupleUser
    {
        public Tuple<int, Stack<string>> stackUser;

        public TupleUser(string nickname, List<int> ownedGames, int index)
        {
            Stack<string> temp = new Stack<string>();
            temp.Push(nickname);
            temp.Push("1");
            temp.Push("nickname");

            string ownedGamesString = string.Join(",", ownedGames.ToArray());
            temp.Push(ownedGamesString);
            temp.Push(ownedGames.Count.ToString());
            temp.Push("ownedGames");

            stackUser = Tuple.Create(index, temp);
        }
        
    }
}
