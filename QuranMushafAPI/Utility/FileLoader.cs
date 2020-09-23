using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuranMushafAPI.Utility
{
    public class FileLoader
    {
        public SuraDocument suraDocument;
        public FileLoader(string fileName)
        {
            XmlDocument rawHtmlDocument = new XmlDocument();

            rawHtmlDocument.Load(fileName);

            suraDocument = new SuraDocument(rawHtmlDocument);
        }

        public static Dictionary<int, SuraDocument> LoadSurasFromFolder(string path)
        {
            Dictionary<int, SuraDocument> ret = new Dictionary<int, SuraDocument>();

            string[] files = Directory.GetFiles(path, "*.html", SearchOption.TopDirectoryOnly);

            foreach(string f in files)
            {
                FileLoader fl = new FileLoader(f);
                SuraDocument sd = fl.suraDocument;
                if (sd.IsSura())
                {
                    ret.Add(sd.SuraNumber, sd);
                }
            }


            return ret;
        }
    }
}
