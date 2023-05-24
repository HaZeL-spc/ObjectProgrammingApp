using lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie
{
    public class Review: IReview, ISetData
    {
        private string text;
        private int rating;
        private int author;

        public Review(string text, int rating, int author)
        {
            this.text = text;
            if (rating >= 1 && rating <= 16)
            {
                this.rating = rating;
            }
            else
            {
                this.rating = 0;
            }

            this.author = author;
        }

        public override string ToString()
        {
            return "text: " + Text + ", rating: " + Rating;
        }
        public IUser Author   // property
        {
            get {


                return GlobalDictionaries.users[author];
            }   // get method
            set { Author = value; }  // set method
        }

        public string Text
        {
           get { return text; }
        }

        public int Rating
        {
            get { return rating; }
        }

        IUser IReview.Author => throw new NotImplementedException();

        public Dictionary<string, Func<object, Review, bool>> setterDict = new Dictionary<string, Func<object, Review, bool>>
        {
            {
                "text", new Func<object, Review, bool>((value, obj) =>
                {
                    obj.text = (string)value;
                    return true;
                })
            },
            {
                "rating", new Func<object, Review, bool>((value, obj) =>
                {
                    obj.rating = (int)value;
                    return true;
                })
            }
        };

        public void setData(string field, string value)
        {
            setterDict[field](value, this);
        }
    }
}
