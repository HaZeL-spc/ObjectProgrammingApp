using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using zadanie;

namespace lab2.commands
{
    public class EditCommand:ICommandCustom
    {
        string type;
        string[] requirements;
        public Dictionary<string, object> Default = new Dictionary<string, object>();
        public ISetData elementEdited;
        public EditCommand(string[] substrings)
        {
            type = substrings[1];
            requirements = new string[substrings.Length - 2];
            for (int i = 2; i < substrings.Length; i++)
            {
                requirements[i - 2] = substrings[i];
            }

            Default = new Dictionary<string, object>(GlobalDictionaries.defaultValues[type]);


            foreach (var el in GlobalDictionaries.treeDict[type].GetEnumerator())
            {
                var originalType = el.GetType();
                var castedObject = Convert.ChangeType(el, originalType);
                bool isOkay = true;

                foreach (string req in requirements)
                {
                    string[] mustHave = req.Split('=', '>', '<');
                    int indexComp = req.IndexOf(mustHave[1]) - 1;
                    string field = mustHave[0];
                    field = Char.ToUpper(field[0]) + field[1..];
                    char comparison = req[indexComp];

                    if (!GlobalDictionaries.defaultValues[type].ContainsKey(field))
                    {
                        Console.WriteLine("this property doesnt exist");
                        break;
                    }

                    var fieldValue = (object)castedObject.GetType().GetProperty(field).GetValue(castedObject);

                    // checking requirements
                    if (!CompareValues(comparison, fieldValue, mustHave[1]))
                    {
                        isOkay = false;
                    }
                }

                if (isOkay)
                {
                    elementEdited = (ISetData)el;
                    
                    Console.WriteLine(GlobalDictionaries.communications[type]);

                    while (true)
                    {
                        string inputField = Console.ReadLine();

                        if (inputField == "DONE") break;

                        string[] dataField = inputField.Split("=");
                        string field = Char.ToUpper(dataField[0][0]) + dataField[0][1..];
                        //var a = (ISetData)el;
                        //a.setData(dataField[0], dataField[1]);
                        Default[field] = dataField[1];

                        if (!GlobalDictionaries.defaultValues[type].ContainsKey(field))
                        {
                            Console.WriteLine("this property doesnt exist");
                            continue;
                        }
                    }
                    break;
                }
            }
        }
        

        public bool CompareValues(char comparison, object valueEl, string value)
        {
            if (comparison == '=')
            {
                if (valueEl is string stringValue)
                {
                    return stringValue == value;
                }
                else if (valueEl is int intValue)
                {
                    return intValue == int.Parse(value);
                }
            }
            else if (comparison == '>')
            {
                if (valueEl is string stringValue)
                {
                    return stringValue.CompareTo(value) > 0;
                   
                }
                else if (valueEl is int intValue)
                {
                    return intValue > int.Parse(value);
                }
            }
            else if (comparison == '<')
            {
                if (valueEl is string stringValue)
                {
                    return stringValue.CompareTo(value) < 0;
                }
                else if (valueEl is int intValue)
                {
                    return intValue < int.Parse(value);
                }
            }
            return false;
        }

        public bool Execute()
        {
            foreach (var el in Default)
            {
                if (GlobalDictionaries.defaultValues[type][el.Key] != Default[el.Key])
                {
                    elementEdited.setData(el.Key.ToLower(), (string)el.Value);
                }
            }

            //GlobalDictionaries.games[1].setData(field, mustHave[1]);

            return true;
        }

        public void PrepareDataXML(XmlWriter writer)
        {
            foreach (var req in requirements)
            {
                //writer.WriteElementString(req.)
            }

            foreach (var el in Default)
            {
                writer.WriteElementString(el.Key, (string)el.Value);
            }
        }

        public override string ToString()
        {
            string output = $"add {type}";
            foreach (var req in requirements)
            {
                output += $" {req}";
            }
            output += "\n";
            output += GlobalDictionaries.communications[type] + "\n";
            foreach (var el in Default)
            {
                output += $"{el.Key}={el.Value}\n";
            }

            return output;
        }
    }
}
