using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Tschuuuuu_tschu
{
   public class Shop
    {
        private Motor[] motoren;
        private Zugtyp[] zugtypen;
        private Wagon[] wagons;
        private string oldshopTime;

        public Motor[]Motoren { get { return motoren; } set { motoren = value; } }
        public Zugtyp[] Zugtypen { get { return zugtypen; } set { zugtypen = value; } }
        public Wagon[] Wagons { get { return wagons; } set { wagons= value; } }
        public string OldshopTime{ get { return oldshopTime; } set { oldshopTime = value; } }
        public Shop()
        {

        }
        public Shop(int i)
        {
            string[] a = DateTime.Now.ToString("H:mm").Split(":");
            OldshopTime = a[0];
            wagons = new Wagon[2];
            zugtypen = new Zugtyp[2];
            motoren= new Motor[2];
            RefreshShop();


        }
        //private Methoden
        private Spieler Verkaufen(Spieler Sp, int Nummer, string Verkaustyp)
        {
            if(Verkaustyp == "Motor")
            {
                if(motoren[Nummer].Preis > Sp.Münzen)
                {
                    Console.WriteLine("Münzen reichen nicht !");
                }
                else
                {
                    Sp.Münzen -= motoren[Nummer].Preis;
                    Sp.Spieler_Zugteile.Add(motoren[Nummer]);
                    var m = new Motor();
                    m.Name = "Verkauft!";
                    motoren[Nummer] = m;
                    
                    return Sp;
                }
            }
            if (Verkaustyp == "Zugtyp")
            {
                if (zugtypen[Nummer].Preis > Sp.Münzen)
                {
                    Console.WriteLine("Münzen reichen nicht !");
                }
                else
                {
                    Sp.Münzen -= zugtypen[Nummer].Preis;
                    Sp.Spieler_Zugteile.Add(zugtypen[Nummer]);
                    var zt = new Zugtyp();
                    zt.Name = "Verkauft!";
                    zugtypen[Nummer] = zt;
                    
                }
            }
            if (Verkaustyp == "Wagon")
            {
                if (wagons[Nummer].Preis > Sp.Münzen)
                {
                    Console.WriteLine("Münzen reichen nicht !");
                }
                else
                {
                    Sp.Münzen -= wagons[Nummer].Preis;
                    Sp.Spieler_Zugteile.Add(wagons[Nummer]);
                    var wg = new Wagon();
                    wg.Name = "Verkauft!";
                    wagons[Nummer] = wg;
                }
            }

            return Sp;
        }
        private void RefreshShop()
        {
            
            for(int i = 0; i < 2; i++)
            {
                Random r = new Random();

                var m1 = new Motor();
                int a = r.Next(0, 3);
                switch (a)
                {
                    case 0:
                        m1.Name = "V4 Motor";
                        m1.Leistung = r.Next(50, 170);
                        m1.Preis = r.Next(200, 400);
                        break;
                    case 1:
                        m1.Name = "V6 Motor";
                        m1.Leistung = r.Next(100, 270);
                        m1.Preis = r.Next(300, 500);
                        break;
                    case 2:
                        m1.Name = "V8 Motor";
                        m1.Leistung = r.Next(300, 420);
                        m1.Preis = r.Next(500, 700);

                        break;
                }
                motoren[i] = m1;
            }
            for (int i = 0; i < 2; i++)
            {
                Random r = new Random();
                int a = r.Next(0, 3);
                int b = r.Next(300, 700);
                switch (a)
                {
                    
                    case 0:
                        var zt1 = new Zugtyp("Elektro");
                        zt1.Preis = b;
                        zugtypen[i] = zt1;
                        break;
                    case 1:
                        var zt2 = new Zugtyp("Dampf");
                        zt2.Preis = b;
                        zugtypen[i] = zt2;
                        break;
                    case 2:
                        var zt3 = new Zugtyp("Diesel");
                        zt3.Preis = b;
                        zugtypen[i] = zt3;

                        break;
                }
                
            }
            for (int i = 0; i < 2; i++)
            {
                Random r = new Random();
                int a = r.Next(0, 3);
                switch (a)
                {
                    case 0:
                        var Pw = new Personwagen();
                        Pw.Name = "PersonenWagon";
                        Pw.MaxPersonen= r.Next(20,100);
                        Pw.Preis = r.Next(200, 300);
                        wagons[i] = Pw;
                        break;
                    case 1:
                        var Gw = new Güterwagon();
                        int b = r.Next(0, 3);
                        switch (b)
                        {
                            case 0:
                                Gw.Güter = "Kohle";
                                Gw.Name = "KohleWagon";
                                Gw.Preis = r.Next(100,150);
                                break;
                            case 1:
                                Gw.Güter = "Gas";
                                Gw.Name = "GasWagon";
                                Gw.Preis = r.Next(150, 250);
                                break;
                            case 2:
                                Gw.Güter = "Teddy";
                                Gw.Name = "TeddyWagon";
                                Gw.Preis = r.Next(200, 300);
                                break;

                        }
                        wagons[i] = Gw;
                        break;
                    case 2:
                        var Bistrowagon = new Bistrowagon();
                        Bistrowagon.Name = "Bistrowagon";
                        Bistrowagon.Bonus = r.Next(10,100);
                        Bistrowagon.Preis = r.Next(200, 400);
                        wagons[i] = Bistrowagon;

                        break;
                }
                
            }
        }
        //public Methoden

        public Spieler DisplayShop(Spieler spieler)
        {
            string [] b = DateTime.Now.ToString("H:mm").Split(":");


            if (Convert.ToInt32(OldshopTime)< Convert.ToInt32(b[0]))
            {
                OldshopTime = b[0];
                RefreshShop();
            }
            
            
            int Index = 0;
            while(Index != 6)
            {
                var Namen = new string[7];
                int i = 0;
                foreach (Motor m in motoren)
                {
                    Namen[i] = m.Name;
                    i++;
                }
                foreach (Zugtyp zt in zugtypen)
                {
                    Namen[i] = zt.Name;
                    i++;
                }
                foreach (Wagon w in wagons)
                {
                    Namen[i] = w.Name;
                    i++;
                }
                Namen[6] = "Exit";
                string Taube = @"                                    ________________________________________________________________
              (/;                  /                                                                \
       .--..-(/;                  |                           WILLKOMMEN                             |
       |    (/;                   |                                                                  |
     __|====/=|__                /         Hier können sie  ihre Zugteile kaufen                     |
    (____________)              /                                                                    |
      / o __ o \  _______      /                                                                     |
      \   \/   / /     ___>   /_____                                                                 |
      /        \/      ____>        \                                                                |
_____/          \    ___>            \______________________________________________________________/
\__              )  /
 \              /__/
  \____________/
        |   |
        ``  ``
      SHOPTAUBE";
                var ShopMenü = new Menü( Taube+ "\nMünzen:" + spieler.Münzen, Namen);
                var JN = new string[] { "Ja", "Nein" };
                var Kaufmenü = new Menü("Willst du es kaufen?", JN);
                Index = ShopMenü.Run();
                int Kauf = -1;
                if(Namen[Index] == "Verkauft!")
                {
                    Console.WriteLine("Ist Verkauft!!!");
                }
                else
                {
                    switch (Index)
                    {
                        case 0:
                            Console.WriteLine("Leistung: {0}Ps", motoren[0].Leistung);
                            Console.WriteLine("Preis: {0}Münzen", motoren[0].Preis);
                            Console.ReadKey();
                            Kauf = Kaufmenü.Run();
                            if (Kauf == 0)
                            {
                                Verkaufen(spieler, 0, "Motor");
                                

                            }
                            break;
                        case 1:
                            Console.WriteLine("Leistung: {0}Ps", motoren[1].Leistung);
                            Console.WriteLine("Preis: {0}Münzen", motoren[1].Preis);
                            Console.ReadKey();
                            Kauf = Kaufmenü.Run();
                            if (Kauf == 0)
                            {
                                spieler = Verkaufen(spieler, 1, "Motor");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Type: {0}", zugtypen[0].Zugtype);
                            Console.WriteLine("Preis: {0}Münzen", zugtypen[0].Preis);
                            Console.ReadKey();
                            Kauf = Kaufmenü.Run();
                            if (Kauf == 0)
                            {
                                spieler = Verkaufen(spieler, 0, "Zugtyp");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Type: {0}", zugtypen[1].Zugtype);
                            Console.WriteLine("Preis: {0}Münzen", zugtypen[1].Preis);
                            Console.ReadKey();
                            Kauf = Kaufmenü.Run();
                            if (Kauf == 0)
                            {
                                spieler = Verkaufen(spieler, 1, "Zugtyp");
                            }
                            break;
                        case 4:
                            if (wagons[0].GetType() == typeof(Güterwagon))
                            {
                                var gw = new Güterwagon();
                                gw = (Güterwagon)wagons[0];
                                Console.WriteLine("Güter: {0}", gw.Güter);
                                Console.WriteLine("Preis: {0}Münzen", gw.Preis);
                                Console.ReadKey();
                                Kauf = Kaufmenü.Run();
                                if (Kauf == 0)
                                {
                                    spieler = Verkaufen(spieler, 0, "Wagon");
                                }
                            }
                            else if (wagons[0].GetType() == typeof(Personwagen))
                            {
                                var pw = new Personwagen();
                                pw = (Personwagen)wagons[0];
                                Console.WriteLine("MaxPersonen: {0}", pw.MaxPersonen);
                                Console.WriteLine("Preis: {0}Münzen", pw.Preis);
                                Console.ReadKey();
                                Kauf = Kaufmenü.Run();
                                if (Kauf == 0)
                                {
                                    spieler = Verkaufen(spieler, 0, "Wagon");
                                }
                            }
                            else if (wagons[0].GetType() == typeof(Bistrowagon))
                            {
                                var bw = new Bistrowagon();
                                bw = (Bistrowagon)wagons[0];
                                Console.WriteLine("Bonus: {0}%", bw.Bonus);
                                Console.WriteLine("Preis: {0}Münzen", bw.Preis);
                                Console.ReadKey();
                                Kauf = Kaufmenü.Run();
                                if (Kauf == 0)
                                {
                                    spieler = Verkaufen(spieler, 0, "Wagon");
                                }
                            }
                            break;
                        case 5:
                            if (wagons[0].GetType() == typeof(Güterwagon))
                            {
                                var gw = new Güterwagon();
                                gw = (Güterwagon)wagons[1];
                                Console.WriteLine("Güter: {0}", gw.Güter);
                                Console.WriteLine("Preis: {0}Münzen", gw.Preis);
                                Console.ReadKey();
                                Kauf = Kaufmenü.Run();
                                if (Kauf == 0)
                                {
                                    spieler = Verkaufen(spieler, 1, "Wagon");
                                }
                            }
                            else if (wagons[1].GetType() == typeof(Personwagen))
                            {
                                var pw = new Personwagen();
                                pw = (Personwagen)wagons[1];
                                Console.WriteLine("MaxPersonen: {0}", pw.MaxPersonen);
                                Console.WriteLine("Preis: {0}Münzen", pw.Preis);
                                Console.ReadKey();
                                Kauf = Kaufmenü.Run();
                                if (Kauf == 0)
                                {
                                    spieler = Verkaufen(spieler, 1, "Wagon");
                                }
                            }
                            else if (wagons[1].GetType() == typeof(Bistrowagon))
                            {
                                var bw = new Bistrowagon();
                                bw = (Bistrowagon)wagons[1];
                                Console.WriteLine("Bonus: {0}%", bw.Bonus);
                                Console.WriteLine("Preis: {0}Münzen", bw.Preis);
                                Console.ReadKey();
                                Kauf = Kaufmenü.Run();
                                if (Kauf == 0)
                                {
                                    spieler = Verkaufen(spieler, 1, "Wagon");
                                }
                            }
                            break;
                    }
                }
            }
            Console.Clear();
            string TaubeTschüss = @"              (/;       
       .--..-(/;         
       |    (/;        
     __|====/=|__        
    (____________)     
      / o __ o \ 
      \   \/   / 
      /        \
_____/          \ 
\__              )
 \              /
  \____________/
        |   |
        ``  ``";

            string Taubeschüss2 = @"                                    ________________________________________________________________
              (/;                  /                                                                \
       .--..-(/;                  |                           Vielen Dank!                           |
       |    (/;                   |                        Für Ihren Einkauf                         |
     __|====/=|__                /                                                                   |
    (____________)              /                                                                    |
      / o __ o \  _______      /                                                                     |
      \   \/   / /     ___>   /_____                                                                 |
      /        \/      ____>        \                                                                |
_____/          \    ___>            \______________________________________________________________/
\__              )  /
 \              /__/
  \____________/
        |   |
        ``  ``";
            
            Console.WriteLine(TaubeTschüss);
            Thread.Sleep(400);
            Console.Clear();
            Console.WriteLine(Taubeschüss2);
            Thread.Sleep(1500);


            return spieler;
        }
    }
}
