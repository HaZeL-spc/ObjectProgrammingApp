using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie.second
{
    public class TextReview
    {
        public string text;

        public TextReview(string text, int rating, string author)
        {
            this.text = "<" + text + ">$$<" + rating + ">$$(<" + author + ">)";

            
        }



    }
}
