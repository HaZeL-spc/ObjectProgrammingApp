using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadanie;
using static System.Net.Mime.MediaTypeNames;

namespace lab2.eigth
{
    public class TupleReview
    {
        public Tuple<int, Stack<string>> stackReview;

        public TupleReview(string text, int rating, int author, int index)
        {
            Stack<string> temp = new Stack<string>();
            temp.Push(text);
            temp.Push("1");
            temp.Push("text");

            temp.Push(rating.ToString());
            temp.Push("1");
            temp.Push("rating");

            temp.Push(author.ToString());
            temp.Push("1");
            temp.Push("author");

            stackReview = Tuple.Create(index, temp);
        }
    }
}
