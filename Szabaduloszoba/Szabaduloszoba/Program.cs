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
            string irany = " ";
            while (ablak == 0 || irany != "észak")
            {
                Console.WriteLine("Leltár : {0}  {1}",leltár1, leltár2);
                Console.WriteLine("Mit szerentél tenni? ");
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
                    irany = "észak";
                }
                if (lepes == "mentes")
                {
                    string leltar = leltár1 + leltár2;
                    mentes(leltar);
                }
                Console.Clear();
            }
            Console.WriteLine("Gratulálok kijutottál!");
        }
    }
}
