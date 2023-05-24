using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using zadanie;

namespace lab2.eigth
{
    public class TupleGame
    {
        public Tuple<int, Stack<string>> stackGame;

        public TupleGame(string name, string genre, List<int> authors, List<int> reviews, List<int> mods, string devices, int index)
        {
            //stackGame = stackGame2.Item2;
            //var clonedStack = stackGame2.Item2;
            ////stackGame = new Stack<string>();

            //foreach (string value in stackGame2.Item2)
            //{
            //    stackGame.Push(value);
            //}
            Stack<string> temp = new Stack<string>();
            temp.Push(name);
            temp.Push("1");
            temp.Push("name");

            temp.Push(genre);
            temp.Push("1");
            temp.Push("genre");

            string authorsString = string.Join(",", authors.ToArray());
            temp.Push(authorsString);
            temp.Push(authors.Count.ToString());
            temp.Push("authors");

            string reviewsString = string.Join(",", reviews.ToArray());
            temp.Push(reviewsString);
            temp.Push(reviews.Count.ToString());
            temp.Push("reviews");

            string modsString = string.Join(",", mods.ToArray());
            temp.Push(modsString);
            temp.Push(mods.Count.ToString());
            temp.Push("mods");

            temp.Push(devices);
            temp.Push("1");
            temp.Push("devices");

            Stack<string> reversedStack = new Stack<string>();

            // Pop each element from the original stack and push it onto the new stack
            while (temp.Count > 0)
            {
                reversedStack.Push(temp.Pop());
            }

            stackGame = Tuple.Create(index, reversedStack);
        }

    }
}
