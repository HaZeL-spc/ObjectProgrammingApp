using lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie
{
    public class Game:IGame, ISetData
    {
        private string name;
        private string genre;
        private List<int> authors;
        private List<int> reviews;
        private List<int> mods;
        private string devices;

        public Game(string name, string genre, List<int> authors, List<int> reviews, List<int> mods, string devices)
        {
            this.name = name;
            this.genre = genre;
            this.authors = authors;
            this.reviews = reviews;
            this.mods = mods;
            this.devices = devices;
        }
        public override string ToString()
        {
            return "name: " + Name + ", genre: " + Genre + ", devices: " + Devices;
        }

        public string Name
        {
            get { return name; }
        }

        public string Genre
        {
             get { return genre; }
        }

        public string Devices
        {
            get { return devices; }
        }

        public List<IUser> Authors
        {
            get
            {
                List<IUser> temp = new List<IUser>();
                for (int i = 0; i < authors.Count; i++)
                {
                    temp.Add(GlobalDictionaries.users[authors[i]]);
                }

                return temp;
            }
        }

        public List<IReview> Reviews
        {
            get
            {
                List<IReview> temp = new List<IReview>();
                for (int i = 0; i < reviews.Count; i++)
                {
                    temp.Add(GlobalDictionaries.reviews[reviews[i]]);
                }

                return temp;
            }
        }

        public List<IMod> Mods
        {
            get
            {
                List<IMod> temp = new List<IMod>();
                for (int i = 0; i < mods.Count; i++)
                {
                    temp.Add(GlobalDictionaries.mods[mods[i]]);
                }

                return temp;
            }
        }

        public Dictionary<string, Func<string, Game, bool>> setterDict = new Dictionary<string, Func<string, Game, bool>>
        {
            {
                "name", new Func<string, Game, bool>((value, obj) =>
                {
                    obj.name = value;
                    return true;
                })
            },
            {
                "genre", new Func<string, Game, bool>((value, obj) =>
                {
                    obj.genre = value;
                    return true;
                })
            },
                {
                "devices", new Func<string, Game, bool>((value, obj) =>
                {
                    obj.devices = value;
                    return true;
                })
            }
        };

        public void setData(string field, string value)
        {
            setterDict[field](value, this);
        }

        public int Key { get; set; }

        //public override int GetHashCode()
        //{
        //    return Key.GetHashCode();
        //}

        //public override bool Equals(object obj)
        //{
        //    if (obj is Game other)
        //    {
        //        return Key.Equals(other.Key);
        //    }

        //    return false;
        //}

    }
}
