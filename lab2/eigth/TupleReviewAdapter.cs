using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadanie;

namespace lab2.eigth
{
    public class TupleReviewAdapter: IReview
    {

        private TupleReview tr;

        public TupleReviewAdapter(TupleReview tupleReview)
        {
            tr = tupleReview;
        }

        public string Text
        {
            get
            {
                Stack<string> tempStack = tr.stackReview.Item2;

                while (tempStack.Pop() != "text") ;
                tempStack.Pop();
                string text = tempStack.Pop();


                return text;
            }
        }

        public int Rating
        {
            get
            {
                Stack<string> tempStack = tr.stackReview.Item2;

                while (tempStack.Pop() != "rating") ;
                tempStack.Pop();
                string rating = tempStack.Pop();


                return int.Parse(rating);
            }
        }

        public IUser Author
        {
            get
            {
                Stack<string> tempStack = tr.stackReview.Item2;
                while (tempStack.Pop() != "author") ;

                int n = int.Parse(tempStack.Pop());
                string index = tempStack.Pop();
                IUser temp = GlobalDictionaries.users[int.Parse(index)];

                return temp;
            }
        }
    }
}
