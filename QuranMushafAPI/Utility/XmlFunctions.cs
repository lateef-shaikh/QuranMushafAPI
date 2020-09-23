using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuranMushafAPI.Utility
{
    class XmlFunctions
    {
        public static int CheckAndLoadInt(XmlNode node, string attribName, int nullVal)
        {
            if(node.SelectSingleNode("@"+ attribName)!= null)
            {
                return int.Parse(node.Attributes[attribName].Value);
            }
            return nullVal;
        }
    }
}
