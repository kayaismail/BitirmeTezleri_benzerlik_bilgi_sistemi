using MetinAnalizi.Abstract;
using Nuve.Lang;
using Nuve.Morphologic.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace MetinAnalizi
{
    public class Metin : IMetinler
    {
        string SafMetin;
        string[] DosyaKelimeler;
        Dictionary<string, int> sozluk;
        public Metin(string Metin)
        {
            //oku.txt
            SafMetin = Metin;
            sozluk = new Dictionary<string, int>();
            FazlaliklardanKurtul();
            KelimeKokleriniBul();
            sozluk = sozluk.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        public List<string> MetinKelimeler()
        {return sozluk.Keys.ToList();
        }
        public Dictionary<string,int> SozlukGetir()
        {
            return sozluk;
        }

        private void KelimeKokleriniBul()
        {
            bool girdi = false;
            Language tr = LanguageFactory.Create(LanguageType.Turkish);
            IList<Word> words;
            foreach (string gelen in DosyaKelimeler)
            {
                girdi = false;
                //Console.WriteLine(gelen);
                words = tr.Analyze(gelen);
                if (words.Count != 0)
                {
                    if (sozluk.ContainsKey(words[0].GetStem().ToString().Split('/')[0]))
                    {
                        sozluk[words[0].GetStem().ToString().Split('/')[0]]++;
                        girdi = true;

                    }

                    if (!girdi)
                    {
                        sozluk.Add(words[0].GetStem().ToString().Split('/')[0], 1);
                        girdi = false;

                    }
                }
                else
                {
                    if (sozluk.ContainsKey(gelen))
                    {
                        sozluk[gelen]++;
                        girdi = true;
                    }

                    if (!girdi)
                    {
                        sozluk.Add(gelen, 1);
                        girdi = false;
                    }
                }
            }
        }
        public void MetinOkuma(List<dbTez> tezler)
        {
            foreach (var item in tezler)
            {
                SafMetin += item.TezAdi+" ";
                SafMetin += item.TezOzet + " ";
            }
        }

        public void FazlaliklardanKurtul()
        {
            for (int i = 0; i < 10; i++)
            {
                SafMetin = SafMetin.Replace(i + "", "");
            }

            SafMetin = SafMetin.Replace(System.Environment.NewLine, " ");
            SafMetin = SafMetin.Replace(".", " ");
            SafMetin = SafMetin.Replace("  ", " ");
            SafMetin = SafMetin.Replace(",", " ");
            SafMetin = SafMetin.Replace(")", " ");
            SafMetin = SafMetin.Replace("(", " ");
            SafMetin = SafMetin.Replace(";", " ");
            SafMetin = SafMetin.Replace("Kelimeler:", " ");
            SafMetin = SafMetin.Replace(":", " ");
            SafMetin = SafMetin.Replace("’", " ");
            SafMetin = SafMetin.Replace("”", " ");
            SafMetin = SafMetin.Replace("“", " ");
            SafMetin = SafMetin.Replace("‘", " ");
            SafMetin = SafMetin.Replace("/", " ");
            SafMetin = SafMetin.ToLower();

            DosyaKelimeler = SafMetin.Split(' ');
        }


    }
}
