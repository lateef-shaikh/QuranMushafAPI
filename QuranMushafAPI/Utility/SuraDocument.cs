using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace QuranMushafAPI.Utility
{
    /** 
     This class stores Sura data in XML format. It also holds Aaya objects for all Aayas
     */
    public class SuraDocument
    {
        private XmlDocument htmlDocument;
        private XmlNode suraSection;

        public RevelationPlace RevelationPlace;
        public int SuraNumber;
        public int RevelationOrder;
        public Mushaf MushafType;
        public Dictionary<int, Aaya> Aayas;

        public SuraDocument(XmlDocument rawDoc)
        {
            htmlDocument = new XmlDocument();
            htmlDocument.LoadXml(rawDoc.LastChild.OuterXml.Replace("xmlns=\"http://www.w3.org/1999/xhtml\"", ""));
            suraSection = htmlDocument.SelectSingleNode("html/body/section");
            Aayas = new Dictionary<int, Aaya>();

            if (suraSection != null)
            {
                // data-place="Makkah" data-order="5" data-sura="1" data-mushaf="pakistani"
                RevelationPlace = (QuranMushafAPI.RevelationPlace)Enum.Parse(typeof(QuranMushafAPI.RevelationPlace), suraSection.Attributes["data-place"].Value);

                if (XmlFunctions.CheckAndLoadInt(suraSection, "data-sura", -1) > -1)
                {
                    SuraNumber = XmlFunctions.CheckAndLoadInt(suraSection, "data-sura", -1);
                }

                if (XmlFunctions.CheckAndLoadInt(suraSection, "data-order", -1) > -1)
                {
                    RevelationOrder = XmlFunctions.CheckAndLoadInt(suraSection, "data-order", -1);
                }

                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;

                MushafType = (QuranMushafAPI.Mushaf)Enum.Parse(typeof(QuranMushafAPI.Mushaf), textInfo.ToTitleCase(suraSection.Attributes["data-mushaf"].Value));

                Aayas = new Dictionary<int, Aaya>();

                XmlNodeList aayas = suraSection.SelectNodes("span[@data-type='aaya']");
                foreach(XmlNode aaya in aayas)
                {
                    Aaya a = new Aaya(aaya);
                    Aayas.Add(a.AayaNumber, a);
                }
            }

        }



        public bool IsSura()
        {
            if(suraSection != null)
            {
                return true;
            }
            return false;
        }



    }
}
