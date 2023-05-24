using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace zadanie.second
{
    public class TextReviewAdapter:IReview
    {
        //public static string ChangeToText(string text, int rating, string author)
        //{
        //    string temp = "<" + text + ">$$<" + rating + ">$$(<" + author + ">)";

        //    return temp;
        //}

        public TextReview tm;

        public override string ToString()
        {
            return "text: " + Text + ", rating: "+  Rating;
        }
        public TextReviewAdapter(TextReview tm2)
        {
            tm = tm2;
        }

        public string Text
        {
            get
            {
                string text = tm.text;
                int index1 = text.IndexOf("$");
                return text.Substring(1, index1 - 2);
            }
        }

        public int Rating
        {
            get
            {
                string text = tm.text;
                string[] arraySplit = text.Split("$$");
                string ratingStr = arraySplit[1].Substring(1, arraySplit[1].Length - 2);


                return int.Parse(ratingStr);
            }
        }

        public IUser Author => throw new NotImplementedException();
    }
}
