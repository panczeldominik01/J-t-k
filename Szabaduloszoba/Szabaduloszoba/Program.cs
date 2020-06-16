using System;
using System.IO;

namespace Szabaduloszoba
{
    class Program
    {
        static void mentes(string leltar)
        {
            StreamWriter write = new StreamWriter("mentes.txt");
            write.WriteLine(leltar);          
            write.Close();
        }
        static void Main(string[] args)
        {
            string leltár1 = "";
            string leltár2 = "";          
            int ablak = 0;
            int bot = 0;
            string irany = " ";
            while (ablak == 0 || irany != "észak")
            {
                Console.WriteLine("Leltár : {0}  {1}",leltár1, leltár2);
                Console.WriteLine("Mit szerentél tenni? (nézd, menj, tör, mentes vedd fel)");
                string lepes = Convert.ToString(Console.ReadLine());
                if (lepes == "tör")
                {
                    ablak = 1;
                    if (leltár1 == "")
                    {
                        leltár1 = "törmelék";
                    }
                    else if (leltár2 =="")
                    {
                        leltár2 = "törmelék";
                    }
                }
                if (lepes == "menj")
                {
                    if (ablak == 1)
                    {
                        irany = "észak";
                    }
                    else
                    {
                        Console.WriteLine("Nem tudsz menni semerre.");
                        Console.ReadLine();
                    }
                }
                if (lepes == "mentes")
                {
                    string leltar = leltár1 + leltár2;
                    mentes(leltar);
                }
                if (lepes =="nézd")
                {
                    Console.WriteLine("Te egy szobában vagy ahol egy ablak látható, valószinűleg ki tudod törni a kezeddel.\nTovábblépéshez nyomj egy gombot");
                    Console.ReadLine();
                }
                if (lepes == "vedd fel")
                {
                    bot = 1;
                }
                Console.Clear();
            }
            Console.WriteLine("Gratulálok kijutottál!");
        }
    }
}
