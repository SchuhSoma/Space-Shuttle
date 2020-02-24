using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Space_Shuttle
{
    class Program
    {
        static List<Ursiklo> UrsikloList;
        static List<string> UrsiklokNeve;
        static Dictionary<string,  int> UrskloOra;
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------------");
            Feladat2Beolvasas();
            Console.WriteLine("---------------------------------------------");
            Feladat3KuldetesSzam();
            Console.WriteLine("---------------------------------------------");
            Feladat4UtasokSzama();
            Console.WriteLine("---------------------------------------------");
            Feladat5Otnelkevesebb();
            Console.WriteLine("---------------------------------------------");
            Feladat6Columbia();
            Console.WriteLine("---------------------------------------------");
            Feladat7Legtobbettavollevo();
            Console.WriteLine("---------------------------------------------");
            Feladat8BekertEvszamKereses();
            Console.WriteLine("---------------------------------------------");
            Feladat9LandolasokSzamaKenedyn();
            Console.WriteLine("---------------------------------------------");
            Feladat10Kiiratas();


            Console.ReadKey();

        }

        private static void Feladat10Kiiratas()
        {
            Console.WriteLine("10.Feladat: írja ki az ursiklok.txt állományba, hogy melyik űrsikló összesen hány napot töltött az űrben!");
            var sw = new StreamWriter(@"ursiklok.txt", false, Encoding.UTF8);
            double Napok = 0;
            foreach (var b in UrskloOra)
            {
                Napok = (double)b.Value / 24;
                Console.WriteLine("{0,-15}: {1}", b.Key, Napok);
                sw.WriteLine("{0,-15}: {1:0.00}", b.Key, Napok);
            }
            sw.Close();
        }

        private static void Feladat9LandolasokSzamaKenedyn()
        {
            Console.WriteLine("\n9.Feladat: Határozza meg, hogy a landolások hány %-a történt az Kennedy űrközponton?");
            int db = 0;
            double atlag = 0;
            foreach (var u in UrsikloList)
            {
                if(u.KuldetesVegHelyszin== "Kennedy")
                {
                    db++;
                }
                atlag = ((double)db / UrsikloList.Count)*100;
            }
            
            Console.WriteLine("\tA landolások {0:0.00} %-a történt az Kennedy űrközponton", atlag);
        }

        private static void Feladat8BekertEvszamKereses()
        {
            Console.WriteLine("\n8.Feladat: Határozza meg és írja ki a képernyőre a minta szerint, hogy a megadott évben hány alkalommal indítottak űrsiklót útnak?");
            Console.Write("\tKérem adjon meg egy vizsgált évet: ");
            int Ev = int.Parse(Console.ReadLine());
            int db = 0;
            foreach (var u in UrsikloList)
            {
                
                if(u.KilovesDatum.Year==Ev)
                {
                    db++;
                }
            }
            if(db>0)
            {
                Console.WriteLine("\tAz adott évben {0}, {1} kilövés volt", Ev, db);
            }
            else
            {
                Console.WriteLine("\tAz adott évben nem volt kilövés");
            }
            
        }

        private static void Feladat7Legtobbettavollevo()
        {
            Console.WriteLine("\n7.Feladat: leghosszabb ideig volt távol a Földtől űrhajó, amit Space Shuttle program indított!");
            UrsiklokNeve = new List<string>();
            UrskloOra = new Dictionary<string, int>();
            foreach (var u in UrsikloList)
            {
                if(!UrsiklokNeve.Contains(u.UrsikloNeve))
                {
                    UrsiklokNeve.Add(u.UrsikloNeve);
                }
            }
            foreach (var a in UrsiklokNeve)
            {
               // Console.WriteLine("\t{0}", a);
            }

            foreach (var a in UrsiklokNeve)
            {
                int db = 0;
                foreach (var u in UrsikloList)
                {
                    if(a==u.UrsikloNeve)
                    {
                        db += u.OrakSzama;
                    }
                }
               // Console.WriteLine("\t{0, -20} : {1}", a, db);
                UrskloOra.Add(a, db);
            }
           // Console.WriteLine("---------------------------------------------");
            foreach (var b in UrskloOra)
            {
               // Console.WriteLine("\t{0, -20} : {1}", b.Key, b.Value);
            }

            int MaxIdo = int.MinValue;
            string MaxAzonosito = "cica";
            string MaxUrhajonev = "kutya";
            foreach (var b in UrskloOra)
            {
                if(MaxIdo<b.Value)
                {
                    MaxIdo = b.Value;
                    MaxUrhajonev = b.Key;
                    foreach (var u in UrsikloList)
                    {
                        if (MaxUrhajonev == u.UrsikloNeve)
                        {
                            MaxAzonosito = u.KulddetesKodja;
                        }
                    }
                }
            }
            Console.WriteLine("\tA leghosszabb ideig volt távol a Földtől {0} űrhajó volt a \n\t{2,-6} azonosítóval, \n\tmely {1} órát töltött távol.", MaxUrhajonev, MaxIdo, MaxAzonosito);
        }

        private static void Feladat6Columbia()
        {
            Console.WriteLine("\n6.Feladat:hány asztronauta kísérte el a Columbiát utolsó útjára ");
            DateTime MaxDatum = DateTime.MinValue;
            int MaxLetszam = 0;
            foreach (var u in UrsikloList)
            {
                if(MaxDatum<u.KilovesDatum && u.UrsikloNeve=="Columbia")
                {
                    MaxLetszam = u.Legenyseg;
                }
            }
            Console.WriteLine("\t{0} asztronauta kísérte el a Columbiát utolsó útjára!", MaxLetszam);
        }

        private static void Feladat5Otnelkevesebb()
        {
            Console.WriteLine("\n5.Feladat: hány alkalommal indítottak űrsiklót kevesebb, mint 5 fővel a világűrbe");
            int db = 0;
            foreach (var u in UrsikloList)
            {
                if(u.Legenyseg<5)
                {
                    db++;
                }
            }
            Console.WriteLine("\t{0} alkalommal indítottak űrsiklót kevesebb, mint 5 fővel a világűrbe", db);
        }

        private static void Feladat4UtasokSzama()
        {
            Console.WriteLine("\n4.Feladat: utasok száma a Space Shuttle keretében");
            int UtasdSzam = 0;
            foreach (var u in UrsikloList)
            {
                UtasdSzam += u.Legenyseg;
            }
            Console.WriteLine("\tUtasok száma a Space Shuttle keretében: {0} fő", UtasdSzam);
        }

        private static void Feladat3KuldetesSzam()
        {
            Console.WriteLine("\n3.Feladat: Küldetésel száma");
            Console.WriteLine("\t{0} küldetés volt a Space Shuttle keretében", UrsikloList.Count);
           
        }

        private static void Feladat2Beolvasas()
        {
            Console.WriteLine("\n2.Feladat: Adatok beolvasása");
            UrsikloList = new List<Ursiklo>();
            var sr = new StreamReader(@"kuldetesek.csv", Encoding.UTF8);
            int db = 0;
            while (!sr.EndOfStream)
            {
                UrsikloList.Add(new Ursiklo(sr.ReadLine()));
                db++;

            }
            sr.Close();
            if (db > 0)
            {
                Console.WriteLine("\tSikeres beolvasás");
            }
            else
            {
                Console.WriteLine("\tSikertelen beolvasás");
            }
           
        }
    }
}
