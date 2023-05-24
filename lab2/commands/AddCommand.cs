using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using zadanie;
using zadanie.second;

namespace lab2.commands
{
    [Serializable]
    public class AddCommand:ICommandCustom
    {
        bool okLeft;
        string typeData;
        string type;
        Dictionary<string, object> Default = new Dictionary<string, object>();

        public AddCommand()
        {
                
        }
        public AddCommand(string[] substrings)
        {
            typeData = substrings[2];
            type = substrings[1];

            Console.WriteLine(GlobalDictionaries.communications[substrings[1]]);
            var obj = GlobalDictionaries.treeDict[substrings[1]];

            Default = new Dictionary<string, object>(GlobalDictionaries.defaultValues[substrings[1]]);
            okLeft = true;

            try
            {
                while (true)
                {
                    string inputField = Console.ReadLine();

                    if (inputField == "DONE") break;
                    if (inputField == "EXIT")
                    {
                        okLeft = false;
                        break;
                    }

                    string[] dataField = inputField.Split("=");
                    string field = Char.ToUpper(dataField[0][0]) + dataField[0][1..];

                    if (!GlobalDictionaries.defaultValues[substrings[1]].ContainsKey(field))
                    {
                        Console.WriteLine("this property doesnt exist");
                        continue;
                    }

                    Default[field] = (object)dataField[1];
                    //TypesBinaryTree[typeData][substrings[1]];
                }
            }
            catch (Exception e)
            {
                okLeft = false;
            }
        }

        public void PrepareDataXML(XmlWriter writer)
        {
            foreach (var el in Default)
            {
                writer.WriteElementString(el.Key, (string)el.Value);
            }
            
        }
        public bool Execute()
        {
            if (okLeft)
            {
                Console.WriteLine("Element added correctly");
                //TypesBinaryTree[typeData][substrings[1]].Insert()

                if (typeData == "secondary")
                {
                    if (type == "game")
                    {
                        TextGame newTextGame = new TextGame((string)Default["Name"], (string)Default["Genre"], new List<string>() { }, new List<int>() { }, new List<string>() { }, (string)Default["Devices"]);
                        GlobalDictionaries.TypesBinaryTree[typeData][type].Insert(new TextGameAdapter(newTextGame));
                    }
                    else if (type == "mod")
                    {
                        TextMod newTextGame = new TextMod((string)Default["Name"], (string)Default["Description"], new List<string>() { }, new List<string>() { });
                        GlobalDictionaries.TypesBinaryTree[typeData][type].Insert(new TextModAdapter(newTextGame));
                    }
                    else if (type == "review")
                    {
                        TextReview newTextGame = new TextReview((string)Default["Text"], (int)Default["Rating"], "1");
                        GlobalDictionaries.TypesBinaryTree[typeData][type].Insert(new TextReviewAdapter(newTextGame));
                    }
                    else if (type == "user")
                    {
                        TextUser newTextGame = new TextUser((string)Default["Nickname"], new List<string>() { });
                        GlobalDictionaries.TypesBinaryTree[typeData][type].Insert(new TextUserAdapter(newTextGame));
                    }
                }
                else if (typeData == "base")
                {
                    if (type == "game")
                    {
                        Game newTextGame = new Game((string)Default["Name"], (string)Default["Genre"], new List<int>() { }, new List<int>() { }, new List<int>() { }, (string)Default["Devices"]);
                        GlobalDictionaries.TypesBinaryTree[typeData][type].Insert(newTextGame);
                    }
                    else if (type == "mod")
                    {
                        Mod newTextGame = new Mod((string)Default["Name"], (string)Default["Description"], new List<int>() { }, new List<int>() { });
                        GlobalDictionaries.TypesBinaryTree[typeData][type].Insert(newTextGame);
                    }
                    else if (type == "review")
                    {
                        Review newTextGame = new Review((string)Default["Text"], (int)Default["Rating"], 1);
                        GlobalDictionaries.TypesBinaryTree[typeData][type].Insert(newTextGame);
                    }
                    else if (type == "user")
                    {
                        User newTextGame = new User((string)Default["Nickname"], new List<int>() { });
                        GlobalDictionaries.TypesBinaryTree[typeData][type].Insert(newTextGame);
                    }
                }

            }
            return true;
        }

        public override string ToString()
        {
            string output = $"add {type} {typeData}\n";
            output += GlobalDictionaries.communications[type] + "\n";
            foreach (var el in Default)
            {
                output += $"{el.Key}={el.Value}\n";
            }

            return output;
        }
    }
}
