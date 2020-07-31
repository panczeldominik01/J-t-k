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
        static int ablaktores = 0;
        static int szekrenymozgas = 0;
        static int ajtonyitas = 0;
        static int furdonezes = 0;
        static string helyzet = "nappali";
        #region Simanezes
        static void nez()
        {
            if (helyzet =="nappali")
            {
                
                    Console.WriteLine("A nappaliban tartózkodsz. Itt egy szekrény látható. Nyugatra a fürdőszoba");
                if (szekrenymozgas == 1)
                {
                    Console.WriteLine("A szekrény mögött egy ablakot látsz.");
                }
               
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
            if (mit ==2 && helyzet == "furdo")
            {
                Console.WriteLine("A kádban egy feszítővasat látsz.");
                furdonezes = 1;
            }
            if (mit == 3&& helyzet == "nappali" && szekrenymozgas ==1)
            {
                Console.WriteLine("Az ablak egy jó menekülési útvonalnak tűnik. Valahogyan be kell törni.");
            }
        }
        #endregion
        #region veddfel
        static void veddfel(int h)
        {
            if (h==1 && doboznyitas==1)
            {
                Console.WriteLine("Felvetted a kulcsot. Mostnatól a leltáradban megtalálható, amíg le nem teszed.");
                kulcs = 1;
            }
            else if (h == 1 && doboznyitas == 0)
            {
                Console.WriteLine("Nem találtad még meg a kulcs helyét.");
            }           
            else if (h == 2 && helyzet =="furdo")
            {
                Console.WriteLine("Felvetted a feszítővasat. Mostantól a leltáradban szerepel, amíg le nem teszed.");
                feszitovas = 1;
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
                ajtonyitas = 1;
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
        #region betolt
        static void betoltes()
        {
            StreamReader reader = new StreamReader("mentes.txt");
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    helyzet = reader.ReadLine();
                }
                if (i == 1)
                {
                    kulcs = Convert.ToInt32(reader.ReadLine());
                }
                if (i == 2)
                {
                    feszitovas = Convert.ToInt32(reader.ReadLine());
                }
                if (i == 3)
                {
                    doboznyitas = Convert.ToInt32(reader.ReadLine());
                }
                if (i == 4)
                {
                    szekrenymozgas = Convert.ToInt32(reader.ReadLine());
                }
                if (i == 5)
                {
                    ablaktores = Convert.ToInt32(reader.ReadLine());
                }
            }
        }
        #endregion
        #region Mentes
        static void mentes(string hely, int kulcs, int feszitovas, int doboznyitas, int szekrenymozgas, int ablaktores)
        {
            StreamWriter writer = new StreamWriter("mentes.txt");
            for (int i = 0; i < 6; i++)
            {
                if (i==0)
                {
                    writer.WriteLine(hely);
                }
                if (i==1)
                {
                    writer.WriteLine(kulcs);
                }
                if (i == 2)
                {
                    writer.WriteLine(feszitovas);
                }
                if (i == 3)
                {
                    writer.WriteLine(doboznyitas);
                }
                if (i == 4)
                {
                    writer.WriteLine(szekrenymozgas);
                }
                if (i == 5)
                {
                    writer.WriteLine(ablaktores);
                }

            }
            
            writer.Close();
        }
        #endregion
        #region töres
        static void tores(int j)
        {
            if (j == 1 && helyzet == "nappali" && feszitovas == 1 && szekrenymozgas == 1)
            {
                Console.WriteLine("Kitörted az ablakot a feszítővassal.");
                ablaktores = 1;
            }
            if (j!=1)
            {
                Console.WriteLine("Ezt nem tudod eltörni");
            }
        }
        #endregion
        static void Main(string[] args)
        {
            Console.Title = "Szabadulószoba";
            Console.WriteLine("Az egyszavas paracsok után kérlek üss egy '*' jelet.");
            Console.WriteLine("A játékban a következő kifejezések szerepelnek : \nnézd\nveddfel\nnyisd\nmentés\nbetölt\nhúzd\ntörd\nleltár");
            Console.ReadLine();
            while (kijutas != 1)
            {
             Console.WriteLine("Adja meg mit szeretne tenni.");
            string phrase = Convert.ToString(Console.ReadLine());
            string[] words = phrase.Split(' ');
            int i = 0;
            foreach (var word in words)
            {               
                i++;
            }
            for (int j = 0; j < i; j++)
            {
                if (j == 0)
                {
                    elso = words[0];
                }
                if (j == 1)
                {
                    masodik = words[1];
                }
                if (j == 2)
                {
                    harmadik = words[2];
                }
            }
            if (elso == "betölt" || elso == "tölt")
                {
                    betoltes();
                }
                #region nyisd eleje
                if (elso =="nyisd")
                {
                    if (masodik =="szekrény")
                    {
                        nyisd(1);
                        
                    }
                    if (masodik == "ajtó")
                    {
                        if (harmadik == "kulcs")
                        {
                           nyisd(2);
                        }
                        if (harmadik !="kulcs")
                        {
                            Console.WriteLine("Kulccsal kell kinyitni az ajtót!");
                        }
                    }
                    if (masodik == "doboz")
                    {
                        nyisd(3);
                    }
                    
                }
                #endregion
                if (elso== "húzd" || elso=="huzd")
                {
                    if (masodik == "szekrény")
                    {
                        szekrenymozgas = 1;
                        Console.WriteLine("Elhúztad a szekrényt.");
                    }
                }
                if (elso == "mentes" || elso =="mentés")
                {
                    mentes(helyzet, kulcs, feszitovas, doboznyitas, szekrenymozgas, ablaktores);
                }
                if (elso=="veddfel")
                {
                    if (masodik =="kulcs" && doboznyitas == 1)
                    {
                        veddfel(1);
                    }
                    if (masodik =="feszítővas" && helyzet =="furdo" && furdonezes == 1)
                    {
                        veddfel(2);
                    }
                    if(masodik !="kulcs" && masodik!="feszitővas" && masodik!="feszitovas" && masodik!="feszítővas" )
                    {
                        Console.WriteLine("Ezt a tárgyat nem tudod felvenni");
                    }
                }
                #region nezdeleje
                if (elso =="nézd" || elso =="néz")
                {
                    if (masodik == "szekrény" && helyzet == "nappali")
                    {
                        dolgoknezese(1);
                    }
                    if (masodik =="kád" && helyzet =="furdo")
                    {
                        dolgoknezese(2);
                    }
                    if (masodik =="ablak" && szekrenymozgas==1 && helyzet =="nappali")
                    {
                        dolgoknezese(3);
                    }
                    else if(masodik =="*")
                    {
                        nez();

                    }
                }
                #endregion

                if (elso == "tör" || elso == "törd")
                {
                    if (masodik == "ablak" && helyzet=="nappali" && szekrenymozgas ==1)
                    {
                        if (harmadik =="feszítővas" || harmadik == "feszitovas" || harmadik =="feszitővas")
                        {
                            ablaktores = 1;
                            Console.WriteLine("Betörted az ablakot. Északra ki tudsz menekülni.");
                        }
                        else
                        {
                            Console.WriteLine("Egy eszközzel kell kitörni az ablakot, mert elvágnád magadat.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ezt a dolgot nem tudod eltörni");
                    }
                }
                #region menni
                if (elso == "menj" || elso == "menni" )
                {
                    if (masodik == "nyugat" && helyzet =="nappali" && ajtonyitas == 1)
                    {
                        Console.WriteLine("Áthaladtál a fürdőbe.");
                        helyzet = "furdo"; 
                    }
                    if (masodik == "nyugat" && helyzet == "nappali" && ajtonyitas != 1)
                    {
                        Console.WriteLine("A fürdőbe jutáshoz ki kell nyitnod az ajtót egy kulccsal.");
                    }
                    if (masodik =="kelet" && helyzet =="furdo")
                    {
                        Console.WriteLine("Áthaladtál a nappaliba");
                        helyzet = "nappali";
                    }
                    if (masodik == "észak" && helyzet =="nappali" && ablaktores == 1)
                    {
                        break;
                    }
                }
                #endregion
                #region leltar
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
                #endregion
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

