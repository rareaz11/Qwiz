using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwiz
{
    internal class Program
    {

        static void Main(string[] args)

        {
            string x;
            List<string> provjera = new List<string>();
            List<Igrac> igracs = new List<Igrac>();
            Random rnd = new Random();
            Igrac igrac = new Igrac();
            List<string> list = new List<string>();
            using (StreamReader sr = File.OpenText("popis.txt"))
            {
                string linija = "";

                while ((linija = sr.ReadLine()) != null)
                {

                    list.Add(linija);
                }
            }

                List<string> pitanja1 = new List<string>();
            pitanja1.Add("Koliko ima kontinenata?");
            pitanja1.Add("Koji je najveci ocean?");
            pitanja1.Add("Koja je najveca pustinja");
            pitanja1.Add("Koji je glavni grad Hrvatske");
            pitanja1.Add("Kako se zove najveca rijeka na svijetu");
            pitanja1.Add(" Kako se zove drugi najvec grad u Hrvatskoj");
            pitanja1.Add("Kad je Hrvatska primljena u EU");
            pitanja1.Add("Koliko 1 kilometar ima metara");
            pitanja1.Add("na kojoj novcanici od eura se nalazi Nikola Tesla");
            List<string> odgovori1 = new List<string>();
            odgovori1.Add("7");
            odgovori1.Add("Tihi ocean");
            odgovori1.Add("Sahara");
            odgovori1.Add("Zagreb");
            odgovori1.Add("Amazona");
            odgovori1.Add("Split");
            odgovori1.Add("2013");
            odgovori1.Add("1000");
            odgovori1.Add("20 centi");

            List<string> pitanja2 = new List<string>();
            pitanja2.Add("koliko kilobajta ima 1 Mb: ");
            pitanja2.Add("Kako se zove zagorov najbolji prijatelj:");
            pitanja2.Add("kako se zove muz od ane karenjne:");
            pitanja2.Add("to je vladao rimskim carstvom za vrijeme Isusova rodenja: ");

            List<string> odgovori2 = new List<string>();
            odgovori2.Add("1024");
            odgovori2.Add("cicho");
            odgovori2.Add("aleksej");
            odgovori2.Add("augustin");




            /*   igracs.Add(new Igrac()
           {
               UserName = "Mate",
               Password = 1234
           });

           igracs.Add(new Igrac()
           {
               UserName = "Kata",
               Password = 4321
           });*/
            for (int i = 0; i < list.Count; i++)

            {
                if (i % 2 == 0)
                {
                    igracs.Add(new Igrac()
                    {
                        UserName = list[i],
                        Password =list[i+1],
                    });
                }
            }

            foreach (var c in igracs)
            {

                Console.WriteLine("korisnicko ime: " + c.UserName);
                Console.WriteLine("lozinka je: " + c.Password);
                Console.WriteLine("-----------------------");
               
            }
           

        k:
            Console.WriteLine("Dobrodosli u kviz");
            Console.WriteLine("za izbornik pritisninte tipku");
            Console.WriteLine("1.PRIJAVA");
            Console.WriteLine("2.REGISTRACIJA");
            int izbor;
            Console.WriteLine("izaberite opciju");
          
            izbor = Convert.ToInt32(Console.ReadLine());
            switch (izbor)
            {
                case 1:

                    Console.WriteLine("unesite svoje korisnicko ime:");
                    x = Console.ReadLine();
                    Console.WriteLine("upisite lozinku: ");
                    string y = Console.ReadLine();
                    //login provjera
                    foreach (var c in igracs)
                    {
                        if (x == c.UserName && y == c.Password)
                        {
                            Console.WriteLine("Dobrodosli korisnice: " + c.UserName);
                            using (StreamWriter upis = File.AppendText("Log.txt"))
                            {
                                upis.Write("\nIME: " + c.UserName);
                                upis.Write("\nVRIJEME ULASKA: \n");
                                upis.Write(  c.vrijemeIgranja=DateTime.Now);
                                upis.Write("\n____________________________");


                            }
                                goto i;


                        }



                    }

                    Console.WriteLine("pogresan unos korisnickog imena ili lozinke");

                    goto k;

                case 2:
                nov:
                    Console.WriteLine("unesite vase korisnicko ime: ");
                    igrac.UserName = Console.ReadLine();
                    
                    if(igrac.UserName == "" || igrac.UserName.Length<3) 
                    {
                        Console.WriteLine("GRESKA NESMIJE KORISNICKO IME BITI PRAZNO ili mora imat bar 3 znaka");
                        goto nov;
                    }


                    Console.WriteLine("unesite vasu lozinku: ");
                    igrac.Password = Console.ReadLine();
                    if (igrac.Password == "" || igrac.Password.Length < 4)
                    {
                        Console.WriteLine("GRESKA NESMIJE LOZINKA BITI PRAZNA ili mora imat bar 4 znaka");
                        goto nov;
                    }
                    foreach (var c in list)
                    {
                        if (igrac.UserName == c )
                        {
                            Console.WriteLine("ime vec postoji: " + c);
                            Console.WriteLine("pokusajte opet");
                           
                            goto k;
                           



                        }

                    }
                    using (StreamWriter upis = File.AppendText("popis.txt")) 
                    {
                        upis.Write(igrac.UserName+"\n");
                        upis.Write(igrac.Password + "\n");

                    }
                    Console.WriteLine("USPJESNO !!!!!!!");
                    Console.ReadLine();
                    igracs.Add(igrac);
                            Console.WriteLine("sad se opet probajete ulogirati: " +  igrac.UserName);
                    Console.ReadLine();
                    goto k;
                          


                        
                      

                    
                i:
                    //izbornik
                    Console.WriteLine(" DOBRODOSLI U IZBORNIK KVIZ");
                    Console.WriteLine("1. zapocni novu igru");
                    Console.WriteLine("2.najbolji rezultati");
                    Console.WriteLine("3.kraj");

                    int izbornik;
                    izbornik = Convert.ToInt32(Console.ReadLine());
                    int brojac = 0;
                    switch (izbornik)
                    {
                        case 1:
                            Console.WriteLine("Igra pocinje");
                            for (int i = 0; i < pitanja1.Count; i++)
                            {

                                i = rnd.Next(0, 9);
                                Console.WriteLine(pitanja1[i]);
                                Console.WriteLine("vas odgovor je: ");
                                string a = Console.ReadLine();
                                if (a == odgovori1[i])
                                {
                                    brojac++;
                                    Console.WriteLine("Cestitamo!! Odgovor je tocan");
                                    Console.WriteLine("osvojili ste : " + brojac + " bod");
                                    Console.ReadLine();
                                    goto drugo;
                                }
                                else
                                {
                                    brojac = 0;
                                    Console.WriteLine("Nazalost krivi odgovor ");
                                    Console.WriteLine("Pokusaj opet");
                                    Console.WriteLine("za nastavak pristisnite enter");
                                    Console.ReadLine();
                                    goto drugo;
                                }

                            drugo:

                                Console.WriteLine("Drugo  pitanje: ");
                              

                                for (int j = 0; j < pitanja1.Count; j++)
                                {

                                    j = rnd.Next(0, 9);
                                    Console.WriteLine(pitanja1[j]);
                                    string b = Console.ReadLine();

                                    if (b == odgovori1[j])
                                    {
                                        brojac++;
                                        Console.WriteLine("cestitamo!! odgovor je tocan");
                                        Console.WriteLine("osvojili ste : " + brojac + " bod");
                                     
                                        Console.ReadLine();
                                        goto y;
                                        

                                    }

                                    else
                                    {
                                        brojac--;
                                        Console.WriteLine("krivi odgovor!! pokusajete opet!!");
                                        Console.WriteLine("trenutno osvojenih bodova: " + brojac);
                                        Console.WriteLine("za nastavakk u izbronik pritisnite enter");
                                        Console.ReadLine();
                                         goto y;
                                    }

                                }
                            y:
                                Console.WriteLine("TRECE PITANJE!!");

                                for (int j = 0; j < pitanja2.Count; j++)
                                {
                                    j = rnd.Next(0, 3);
                                    Console.WriteLine(pitanja2[j]);
                                    Console.WriteLine("vas odgovor je : ");
                                    string odg = Console.ReadLine();
                                    if (odg == odgovori2[j])
                                    {
                                        Console.WriteLine("cestitamo!! \nodgovor je tocan");
                                        brojac++;
                                        Console.WriteLine("za nastavak pritnite enter");
                                        Console.WriteLine("trenutno stanje brojaca je : " + brojac);
                                        Console.WriteLine("CESTITAMO!!!!!!!!POBJEDILI STE");
                                        using (StreamWriter upis = File.AppendText("rez.txt"))// upisuje u file rez ime, rezultat i vrijeme igranja
                                        {
                                            upis.Write(x + "\n");
                                            upis.Write(brojac + "\n");
                                            upis.Write("VRIJEME ULASKA: \n");
                                            upis.Write(DateTime.Now);
                                            upis.Write("\n____________________________\n");


                                        }
                                        Console.ReadLine();

                                        goto k;
                                        // foreach (var s in igracs.Where(s => s.UserName == x).ToList())-- ispravan pokusaj isti s u foreach i u where zagradi
                                        /*           foreach (var s in igracs.Where(s => s.UserName == x).ToList()) 
                                               {
                                                   s.Score = brojac;
                                                   Console.WriteLine("rezultat za korisnika " + x +" je: " + s.Score);
                                                   Console.ReadLine();
                                               }

                                               goto k;*/
                                    }

                                    else
                                    {
                                        Console.WriteLine("nazalost krivi odgovor");
                                        brojac--;
                                        Console.WriteLine("za nastavak pritnite enter");
                                        Console.WriteLine("trenutno stanje brojaca je : " + brojac);
                                       
                                        using (StreamWriter upis = File.AppendText("rez.txt"))// upisuje u file rez ime, rezultat i vrijeme igranja
                                        {
                                            upis.Write(x + "\n");
                                            upis.Write(brojac + "\n");
                                            upis.Write("VRIJEME ULASKA: \n");
                                            upis.Write(DateTime.Now);
                                            upis.Write("\n____________________________\n");


                                        }

                                        Console.WriteLine("nazalost krivi odgovor");
                                        goto k;
                                    }
                                }
                                Console.ReadLine();


                            }




                            break;


                        case 2:
                            List<string> rec = new List<string>();
                            using(StreamReader sr= File.OpenText("rez.txt")) 
                            {
                                string linija ="";

                                while((linija= sr.ReadLine())!= null)
                                {
                                    Console.WriteLine(linija);
                                    rec.Add(linija);
                                }
                                


                                        
                                
                            }
                            for(int i = 0; i < rec.Count; i++) 
                            {
                                if(i == 0||i%5==0) 
                                {
                                    provjera.Add(rec[i]);
                                    provjera.Add(rec[i+1]);
                                   

                                }
                            }

                            Console.WriteLine("broj u listi prvojera: " + provjera.Count);

                            for(
                                int i = 0; i < provjera.Count; i++)
                            {
                                foreach(var n in igracs) 
                                {
                                    if (n.UserName == provjera[i])
                                    {
                                        int rezult = Int32.Parse(provjera[i + 1]);
                                        n.Score = rezult;
                                        Console.WriteLine("USPIJESNO!!!");
                                    }
                                }
                            }
                            Console.ReadLine() ;

                         

                            foreach(var n in igracs) 
                            {
                                Console.WriteLine("ime je " + n.UserName);
                                Console.WriteLine("a rezultat je : " + n.Score);
                            }
                            int max=0;
                            string prvi="";
                            foreach(var n in igracs) 
                            {
                                if (n.Score > 0) 
                                {

                                    if (max < n.Score) 
                                    {
                                        max = n.Score;  
                                        prvi = n.UserName;
                                    }
                                    
                                }

                            }
                            Console.WriteLine("NAJBOJLJI REZULTAT IMA: " + prvi +" sa rezultatom: " + max);
                            Console.ReadLine();


                            break;

                        case 3:
                            Console.WriteLine("Pozz");

                            break;
                            default:

                            Console.WriteLine("Pogresan unos!!!!!!");
                            goto k;
                           



                    }

                
                    
                   
                    break;
                default:

                    Console.WriteLine("pogresan unos!!!!");
                    goto k;


            }

            
        }


    }
}
