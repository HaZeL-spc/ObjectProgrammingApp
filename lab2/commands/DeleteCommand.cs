using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using zadanie;

namespace lab2.commands
{
    public class DeleteCommand:ICommandCustom
    {
        string type;
        string[] requirements;

        public DeleteCommand(string[] substrings)
        {
            type = substrings[1];
            requirements = new string[substrings.Length - 2];
            for (int i = 2; i < substrings.Length; i++)
            {
                requirements[i - 2] = substrings[i];
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
                    GlobalDictionaries.TypesBinaryTree["base"][type].Delete(castedObject);
                }
            }
            return true;
        }

        public void PrepareDataXML(XmlWriter writer)
        {
            foreach (var req in requirements)
            {
                string[] mustHave = req.Split('=', '>', '<');
                int indexComp = req.IndexOf(mustHave[1]) - 1;
                string field = mustHave[0];
                field = Char.ToUpper(field[0]) + field[1..];
                char comparison = req[indexComp];
                writer.WriteStartElement(field);
                writer.WriteElementString(mustHave[1], comparison.ToString());
                writer.WriteEndElement();
            }
        }
        public override string ToString()
        {
            string output = "";
            output += "delete ";
            foreach (var req in requirements)
            {
                output += req + " ";
            }

            return output;
        }
    }
}
