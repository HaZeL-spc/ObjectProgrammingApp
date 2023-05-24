using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadanie;

namespace lab2.commands
{
    public class ListCommand:ICommandCustom
    {
        public string type;

        public ListCommand(string type)
        {
            this.type = type;
        }

        public bool Execute()
        {
            foreach (var el in GlobalDictionaries.treeDict[type].GetEnumerator())
            {
                Console.WriteLine(el);
            }

            return true;
        }

        public override string ToString()
        {
            return "list " + type;
        }
    }
}
