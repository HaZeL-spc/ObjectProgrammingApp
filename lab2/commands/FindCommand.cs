using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using zadanie;

namespace lab2.commands
{
    public class FindCommand:ICommandCustom
    {
        char comparison;
        string value;
        string field;
        string type;

        public FindCommand(string[] substrings)
        {
            var obj = GlobalDictionaries.treeDict[substrings[1]];
            string[] requirements = substrings[2].Split('=', '>', '<');
            field = Char.ToUpper(requirements[0][0]) + requirements[0][1..];
            int indexComp = substrings[2].IndexOf(requirements[1]) - 1;
            comparison = substrings[2][indexComp];
            type = substrings[1];

            //string stringExec = $"return BinaryTreeExtensions.Find(obj.GetEnumerator(), x => x.{field} == {requirements[1]})";
            value = requirements[1];
        }

        public bool Execute()
        {
            try
            {
                foreach (var el in GlobalDictionaries.treeDict[type].GetEnumerator())
                {
                    object mmm = el;
                    if (type == "game")
                        mmm = (IGame)el;
                    else if (type == "review")
                        mmm = (IReview)el;
                    else if (type == "mod")
                        mmm = (IMod)el;
                    else if (type == "user")
                        mmm = (IUser)el;

                    if (!GlobalDictionaries.defaultValues[type].ContainsKey(field))
                    {
                        Console.WriteLine("this property doesnt exist");
                        break;
                    }

                    object valueEl = (object)mmm.GetType().GetProperty(field).GetValue(mmm);

                    //string value
                    if (comparison == '=')
                    {
                        if (valueEl is string stringValue)
                        {
                            if (stringValue == value)
                            {
                                Console.WriteLine(mmm);
                            }
                        }
                        else if (valueEl is int intValue)
                        {
                            if (intValue == int.Parse(value))
                            {
                                Console.WriteLine(mmm);
                            }
                        }
                    }
                    else if (comparison == '>')
                    {
                        if (valueEl is string stringValue)
                        {
                            if (stringValue.CompareTo(value) > 0)
                            {
                                Console.WriteLine(mmm);
                            }
                        }
                        else if (valueEl is int intValue)
                        {
                            if (intValue > int.Parse(value))
                            {
                                Console.WriteLine(mmm);
                            }
                        }
                    }
                    else if (comparison == '<')
                    {
                        if (valueEl is string stringValue)
                        {
                            if (stringValue.CompareTo(value) < 0)
                            {
                                Console.WriteLine(mmm);
                            }
                        }
                        else if (valueEl is int intValue)
                        {
                            if (intValue < int.Parse(value))
                            {
                                Console.WriteLine(mmm);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("uncorrect type of data to parameter");
            }

            return true;
        }

        public override string ToString()
        {
            return $"find {type} {field}{comparison}{value}";
        }
    }
}
