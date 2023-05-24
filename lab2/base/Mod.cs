using lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie
{
    public class Mod: IMod, ISetData
    {
        private string name;
        private string description;
        private List<int> authors;
        private List<int> compatibility;

        public Mod(string name, string description, List<int> authors, List<int> compatibility)
        {
            this.name = name;
            this.description = description;
            this.authors = authors;
            this.compatibility = compatibility;
        }

        public override string ToString()
        {
            return "name: " + Name + ", description: " + Description;
        }
        public List<IUser> Authors   // property
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

        public List<IMod> Compatibility   // property
        {
            get {
                List<IMod> temp = new List<IMod>();
                for (int i = 0; i < compatibility.Count; i++)
                {
                    temp.Add(GlobalDictionaries.mods[compatibility[i]]);
                }

                return temp;

            }   // get method
        }

        public string Name
        {
            get { return name; }
        }

        public string Description
        {
            get { return description; }
        }

        public List<IMod> Compability => throw new NotImplementedException();

        List<IUser> IMod.Authors => throw new NotImplementedException();

        public Dictionary<string, Func<string, Mod, bool>> setterDict = new Dictionary<string, Func<string, Mod, bool>>
        {
            {
                "name", new Func<string, Mod, bool>((value, obj) =>
                {
                    obj.name = value;
                    return true;
                })
            },
            {
                "description", new Func<string, Mod, bool>((value, obj) =>
                {
                    obj.description = value;
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
