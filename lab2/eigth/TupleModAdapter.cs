using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadanie;

namespace lab2.eigth
{
    public class TupleModAdapter: IMod
    {
        TupleMod tp;

        public TupleModAdapter(TupleMod tupleMod)
        {
            tp = tupleMod;
        }

        public string Name
        {
            get
            {
                Stack<string> tempStack = tp.stackMod.Item2;

                while (tempStack.Pop() != "name") ;
                tempStack.Pop();
                string name = tempStack.Pop();


                return name;
            }
        }

        public string Description
        {
            get
            {
                Stack<string> tempStack = tp.stackMod.Item2;

                while (tempStack.Pop() != "description") ;
                tempStack.Pop();
                string name = tempStack.Pop();


                return name;
            }
        }

        public List<IUser> Authors
        {
            get
            {
                Stack<string> tempStack = tp.stackMod.Item2;
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

        public List<IMod> Compability
        {
            get
            {
                Stack<string> tempStack = tp.stackMod.Item2;
                while (tempStack.Pop() != "compatibility") ;

                int n = int.Parse(tempStack.Pop());
                List<IMod> temp = new List<IMod>();
                string compatibilityString = tempStack.Pop();
                string[] compatibilityArr = compatibilityString.Split(",");
                for (int i = 0; i < compatibilityArr.Length; i++)
                {
                    temp.Add(GlobalDictionaries.mods[int.Parse(compatibilityArr[i])]);
                }

                return temp;
            }
        }
    }
}
