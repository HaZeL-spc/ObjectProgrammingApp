using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace zadanie
{
    public interface ICommandCustom
    {
        public bool Execute();
        //public void PrepareDataXML(XmlWriter writer);
    }
}
