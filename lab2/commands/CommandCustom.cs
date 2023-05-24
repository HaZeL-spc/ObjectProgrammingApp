using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;
using zadanie;

namespace lab2.commands
{
    public class CommandCustom
    {
        public List<ICommandCustom> commands = new List<ICommandCustom>();
        public List<string> commandsString = new List<string>();

        public bool Execute()
        {
            foreach (var command in commands)
            {
                command.Execute();
                Console.WriteLine("------------------------");
            }

           return true;
        }

        public bool Clear()
        {
            commands = new List<ICommandCustom>();
            commandsString = new List<string>();
            return true;
        }

        public bool AddData(ICommandCustom command, string operation)
        {
            commands.Add(command);
            commandsString.Add(operation);

            return true;
        }

        public void PrintData()
        {
            Console.WriteLine("------------------------");
            foreach (var command in commands)
            {
                Console.WriteLine(command);
                Console.WriteLine("------------------------");
            }
        }

        public void Export(string filename, string format)
        {

            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Indent = true;  // Enable indentation for readability

            //using (XmlWriter writer = XmlWriter.Create(xmlFilePath, settings))
            //{
            //    writer.WriteStartDocument();
            //    for (int i = 0; i < commands.Count; i++)
            //    {
            //        ICommandCustom command = commands[i];
            //        string operation = commandsString[i];

            //        writer.WriteStartElement(operation);
            //        //command.PrepareDataXML(writer);
            //        writer.WriteEndElement();
            //    }

            //    writer.WriteEndDocument();
            //}

            //XmlSerializer serializer = new XmlSerializer(typeof(Person));

            // Create a FileStream to write the serialized object

            string xmlFilePath = filename + ".xml";
            XmlSerializer serializer = new XmlSerializer(typeof(AddCommand));

            using (FileStream fileStream = new FileStream(xmlFilePath, FileMode.Create))
            {
                foreach (var command in commands)
                {
                    serializer.Serialize(fileStream, command);
                }
                
            }
        }
    }
}
