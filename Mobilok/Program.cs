using System;
using System.Collections.Generic;
using System.IO;

namespace Osztalyalapok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Phon> mobilok = new List<Phon>();
            #region Betöltés állományból
            string[] sorok = File.ReadAllLines("mobiladatok.txt");
            foreach (string sor in sorok)
            {
                mobilok.Add(new Phon(sor));
            }
            #endregion
            Console.Write("Adja meg a mobil nevét: ");
            string s = Console.ReadLine().ToLower();
            bool van = false;
            for (int i = 0; i < mobilok.Count; i++)
            {
                if (mobilok[i].megnev.ToLower() == s)
                {
                    Console.WriteLine(mobilok[i].ToString());
                    van = true;
                    break;
                }
            }
            if (van == false)
            {
                Console.WriteLine("Nincs ilyen");
            }
        }
    }

    internal class Phon
    {
        public string megnev;
        public string gyarto;
        public decimal kijmeret;
        public int tarhely;
        public int ram;
        public int akku;

        public Phon() { }

        public Phon(string megnev, string gyarto, decimal kijmeret, int tarhely, int ram, int akku)
        {
            this.megnev = megnev;
            this.gyarto = gyarto;
            this.kijmeret = kijmeret;
            this.tarhely = tarhely;
            this.ram = ram;
            this.akku = akku;
        }

        public Phon(string sor)
        {
            string[] adatok = sor.Split(';');
            megnev = adatok[0];
            gyarto = adatok[1];
            kijmeret = decimal.Parse(adatok[2]);
            tarhely = int.Parse(adatok[3]);
            ram = int.Parse(adatok[4]);
            akku = int.Parse(adatok[5]);
        }

        public override string ToString()
        {
            return $"Megnevezés: {megnev}\n" +
                $"Gyártó: {gyarto}\n" + 
                $"Kijelző mérete (hüvelyk): {kijmeret}\n" +
                $"Tárhely (Gb): {tarhely}\n" +
                $"RAM (Gb): {ram}\n" +
                $"Akkumlátor (mAh) {akku}";
        }
    }
}
