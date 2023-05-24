using System.Diagnostics;
using zadanie;

namespace lab2.eigth
{
    public class TupleMod
    {

        public Tuple<int, Stack<string>> stackMod;

        public TupleMod(string name, string description, List<int> authors, List<int> compatibility, int index)
        {
            Stack<string> temp = new Stack<string>();
            temp.Push(name);
            temp.Push("1");
            temp.Push("name");

            temp.Push(description);
            temp.Push("1");
            temp.Push("genre");

            string authorsString = string.Join(",", authors.ToArray());
            temp.Push(authorsString);
            temp.Push(authors.Count.ToString());
            temp.Push("authors");

            string compatibilityString = string.Join(",", compatibility.ToArray());
            temp.Push(compatibilityString);
            temp.Push(compatibility.Count.ToString());
            temp.Push("compatibility");

            stackMod = Tuple.Create(index, temp);
        }

    }
}
