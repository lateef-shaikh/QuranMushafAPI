using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using QuranMushafAPI;
using QuranMushafAPI.Utility;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SuraData suraData = new SuraData(@"C:\Users\Mariam\Documents\Lateef\SVN-GIT\pakistani-mushaf");

            Dictionary<int, SuraDocument> pakistaniSuras = suraData.PakistaniSuras;

            string[] lines = File.ReadAllLines(@"C:\Users\Mariam\Documents\Lateef\SVN-GIT\Urdu Mehfil\indopak_ayahs.sql");

            List<string> data = new List<string>();

            foreach(string line in lines)
            {
                if (!line.StartsWith("(")) { continue; }

                string lineWithDelim = line.Remove(0, 1);
                lineWithDelim = lineWithDelim.Remove(lineWithDelim.Length - 2, 2);
                string[] tokens = lineWithDelim.Split(new char[] { ',' });

                int pk = int.Parse(tokens[0]);
                int sura = int.Parse(tokens[1]);
                int aaya = int.Parse(tokens[2]);

                string aayaTextRaw = tokens[3].Replace("'", "").Trim();

                string[] textTokens = aayaTextRaw.Split(new char[] { ' ' });

                string textWOeoa = string.Empty;

                if (textTokens[textTokens.Length - 1].Length <= 2)
                {
                    textWOeoa = aayaTextRaw.Replace(textTokens[textTokens.Length - 1], "");
                }
                else
                {
                    textWOeoa = aayaTextRaw.Remove(aayaTextRaw.Length - 1, 1);
                    if(textWOeoa.EndsWith("\u0615") || textWOeoa.EndsWith("\u0617") || textWOeoa.EndsWith("\u06D6") || textWOeoa.EndsWith("\u06D7") || textWOeoa.EndsWith("\u06DA"))
                    {
                        textWOeoa = textWOeoa.Remove(textWOeoa.Length - 1, 1);
                    }

                    if (textWOeoa.EndsWith("\u0615") || textWOeoa.EndsWith("\u0617") || textWOeoa.EndsWith("\u06D6") || textWOeoa.EndsWith("\u06D7") || textWOeoa.EndsWith("\u06DA"))
                    {
                        textWOeoa = textWOeoa.Remove(textWOeoa.Length - 1, 1);
                    }

                    if (textWOeoa.EndsWith("\u0615") || textWOeoa.EndsWith("\u0617") || textWOeoa.EndsWith("\u06D6") || textWOeoa.EndsWith("\u06D7") || textWOeoa.EndsWith("\u06DA"))
                    {
                        textWOeoa = textWOeoa.Remove(textWOeoa.Length - 1, 1);
                    }

                    if (textWOeoa.EndsWith("\u0615") || textWOeoa.EndsWith("\u0617") || textWOeoa.EndsWith("\u06D6") || textWOeoa.EndsWith("\u06D7") || textWOeoa.EndsWith("\u06DA"))
                    {
                        textWOeoa = textWOeoa.Remove(textWOeoa.Length - 1, 1);
                    }
                }

                string eoa = pakistaniSuras[sura].Aayas[aaya].EoA;
                //(1, 1, 1, 'بِسْمِ اللّٰهِ الرَّحْمٰنِ الرَّحِیْمِ '),
                string newLine = "(" + pk.ToString() + ", " + sura.ToString() + ", " + aaya.ToString() + ", '" + textWOeoa + " " + eoa + " ')";

                if(pk < 6236)
                {
                    newLine += ",";
                }
                else
                {
                    newLine += ";";
                }

                data.Add(newLine);
            }

            File.WriteAllLines(@"C:\Users\Mariam\Documents\Lateef\SVN-GIT\Urdu Mehfil\a.txt", data);
        }
    }
}
