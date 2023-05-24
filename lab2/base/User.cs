using lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace zadanie
{
    public class User: IUser, ISetData
    {
        private string nickname;
        private List<int> ownedGames;

        public User(string nickname, List<int> ownedGames)
        {
            this.nickname = nickname;
            this.ownedGames = ownedGames;
        }


        public override string ToString()
        {
            return "nickname: " + Nickname;
        }
        public List<IGame> OwnedGames   // property
        {
            get {
                List<IGame> temp = new List<IGame>();
                for (int i = 0; i < ownedGames.Count; i++)
                {
                    temp.Add(GlobalDictionaries.games[ownedGames[i]]);
                }

                return temp;
            }   // get method
        }

        public string Nickname
        {
            get { return nickname; }
        }

        List<IGame> IUser.OwnedGames => throw new NotImplementedException();

        public Dictionary<string, Func<string, User, bool>> setterDict = new Dictionary<string, Func<string, User, bool>>
        {
            {
                "nickname", new Func<object, User, bool>((value, obj) =>
                {
                    obj.nickname = (string)value;
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
