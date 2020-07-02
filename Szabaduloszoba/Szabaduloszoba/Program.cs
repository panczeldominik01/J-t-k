using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.IO;
using System.Threading;

namespace Szabaduloszoba
{
    class Program
    {
        
        static string elso;
        static string masodik;
        static string harmadik;
        static int kulcs = 0;
        static int feszitovas = 0;
        static int doboznyitas = 0;
        static int kijutas = 0;
        static int szekrenymozgas = 0;
        static string helyzet = "nappali";
        #region Simanezes
        static void nez()
        {
            if (helyzet =="nappali")
            {
                
                    Console.WriteLine("A nappaliban tartózkodsz. Itt egy szekrény látható. Nyugatra a fürdőszoba");
               
            }
            if (helyzet == "furdo")
            {
                Console.WriteLine("A fürdőbeen tartózkodsz. Itt található egy kád. Keletre a nappali.");
            }

        }
        #endregion
        #region Nezese
        static void dolgoknezese(int mit)
        {
            if (mit == 1 && helyzet=="nappali")
            {
                Console.WriteLine("A szekrényen nem látszik semmi, csak az, hogy kinyitható.");
            }
            if (mit ==2&& helyzet == "furdo")
            {
                Console.WriteLine("A kádban egy feszítővasat látsz.");
            }
            if (mit == 3&& helyzet == "nappali" && szekrenymozgas ==1)
            {
                Console.WriteLine("Az ablak egy jó menekülési útvonalnak tűnik. Valahogyan be kell törni.");
            }
        }
        #endregion
        #region veddfel
        static void veddfel(int h = 0)
        {
            if (h==1 && doboznyitas==1)
            {
                Console.WriteLine("Felvetted a kulcsot. Mostnatól a leltáradban megtalálható, amíg le nem teszed.");
                kulcs = 1;
            }
            if (h!=1 || doboznyitas!=1)
            {
                Console.WriteLine("Nem tudod felvenni a tárgyat amit beírtál.");
            }

        }
        #endregion
        #region nyisd
        static void nyisd(int t = 0)
        {
            if (t == 1)
            {
                Console.WriteLine("Kinyitottad a szekrényt. Benne egy dobozt látsz.");
            }
            if (t == 2 && kulcs == 1)
            {
                Console.WriteLine("Kinyitottad az ajtót, át tudsz menni a fürdőszobába.");
            }
            if (t == 2 && kulcs !=1)
            {
                Console.WriteLine("Az ajtó nyitásához szükséged van egy kulcsra.");
            }
            if (t == 3)
            {
                Console.WriteLine("Kinyitottad a dobozt, egy kulcsot látsz benne.");
                doboznyitas = 1;
            }
            else if(t==0)
            {
                Console.WriteLine("Ezt a tárgyat nem tudod kinyitni");
            }


        }
        #endregion
        static void Main(string[] args)
        {
            
            while (kijutas != 1)
            {
                int i = 0;
                for (i = 0; i < 3; i++)
                {
                    if (elso == "*" || masodik == "*" || harmadik == "*")
                    {
                        i = 3;
                    }
                    if (i ==0)
                    {
                        Console.WriteLine("Adja meg mit szeretne tenni.\nAbban az esetben ha nem 3 szavas kifehezést ad meg kérem az üres helyen írja be a következőt = '*'");
                        elso = Convert.ToString(Console.ReadLine());
                        Console.Clear();
                    }
                    if (i == 1)
                    {
                        Console.WriteLine("Adja meg mit szeretne tenni.");
                        Console.Write("{0} ",elso);
                        masodik = Convert.ToString(Console.ReadLine());
                        Console.Clear();
                    }
                    if (i == 2)
                    {
                        Console.WriteLine("Adja meg mit szeretne tenni.");
                        Console.Write("{0} {1} ",elso,masodik);
                         harmadik = Convert.ToString(Console.ReadLine());
                        Console.Clear();
                    }                   
                }
                if (elso =="nyisd")
                {
                    if (masodik =="szekrény")
                    {
                        nyisd(1);
                        
                    }
                    if (masodik == "ajtó")
                    {
                        nyisd(2);
                    }
                    if (masodik == "doboz")
                    {
                        nyisd(3);
                    }
                    
                }
                if (elso=="vedd fel")
                {
                    if (masodik =="kulcs")
                    {
                        veddfel(1);
                    }
                }
                if (elso =="nézd" || elso =="néz")
                {
                    if (masodik == "szekrény")
                    {
                        dolgoknezese(1);
                    }
                    if (masodik =="kád")
                    {
                        dolgoknezese(2);
                    }
                    if (masodik =="ablak")
                    {
                        dolgoknezese(3);
                    }
                    else if(masodik =="*")
                    {
                        nez();

                    }
                }
                if (elso=="leltár")
                {
                    Console.Write("A leltáradban ");
                    if (kulcs == 1)
                    {
                        Console.Write("kulcs");
                    }
                    if (kulcs == 1&& feszitovas == 1)
                    {
                        Console.Write(",");
                    }
                    if (feszitovas == 1)
                    {
                        Console.Write(" feszitővas");
                    }
                    Console.Write(" található");
                }
                elso = " "; masodik = " "; harmadik = " ";
                i = 0;
                Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("Gratulálok kijutottál!!");
            Console.ReadKey();

        }
    }
}
