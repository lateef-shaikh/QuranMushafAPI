using QuranMushafAPI.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranMushafAPI
{
    /**
     This class has collection of Sura documents for Mushafs

        V 0.1 - Added Pakistani Mushaf support.
     */
    public class SuraData
    {
        Dictionary<int, SuraDocument> pakistaniSuras = new Dictionary<int, SuraDocument>();
        //List<SuraDocument> uthmaniSuras = new List<SuraDocument>();

        public SuraData(string path)
        {
            pakistaniSuras = FileLoader.LoadSurasFromFolder(path);

        }

        public Dictionary<int, SuraDocument> PakistaniSuras
        {
            get { return pakistaniSuras; }
        }

        public string GetEoA(int sura, int aaya)
        {
            return PakistaniSuras[sura - 1].Aayas[aaya - 1].EoA;
        }
    }


    public enum Mushaf
    {
        Pakistani,
        Uthmani
    }

    public enum RevelationPlace
    {
        Makkah,
        Madinah
    }
}
