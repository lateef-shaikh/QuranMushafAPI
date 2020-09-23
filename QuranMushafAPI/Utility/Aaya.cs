using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuranMushafAPI.Utility
{
    /** 
     This class keeps Aaya data in fields.

        V 0.1 - Added End of Aaya as separate public field.
     */
    public class Aaya
    {
        //data-aaya="1" data-juz="1" data-ruku="1" data-manzil="1"
        public int AayaNumber;
        public int Juz;
        public int Ruku;
        public int Manzil;
        public string EoA;

        public Aaya(XmlNode aayaNode)
        {
            if (XmlFunctions.CheckAndLoadInt(aayaNode, "data-aaya", -1) > -1)
            {
                AayaNumber = XmlFunctions.CheckAndLoadInt(aayaNode, "data-aaya", -1);
            }

            if (XmlFunctions.CheckAndLoadInt(aayaNode, "data-juz", -1) > -1)
            {
                Juz = XmlFunctions.CheckAndLoadInt(aayaNode, "data-juz", -1);
            }

            if (XmlFunctions.CheckAndLoadInt(aayaNode, "data-ruku", -1) > -1)
            {
                Ruku = XmlFunctions.CheckAndLoadInt(aayaNode, "data-ruku", -1);
            }

            if (XmlFunctions.CheckAndLoadInt(aayaNode, "data-manzil", -1) > -1)
            {
                Manzil = XmlFunctions.CheckAndLoadInt(aayaNode, "data-manzil", -1);
            }

            EoA = aayaNode.SelectSingleNode("span[@data-type='eoa-sc']").InnerText;

        }
    }
}
