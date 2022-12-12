using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Tschuuuuu_tschu
{
    class Simulator
    {
        private Spieler Spieler1;
        private List<Bahnhof[]> karte;

        //public List<Bahnhof[]> Karte { get { return karte; } }

        public void BahnhofKarte()
        {
            var stringa1 = new string[] { "Dampf", "Diesel", "Elektro" };
            var B_Mörfelden = new Bahnhof(stringa1,"Mörfelden-Bahnhof");

            var stringa2 = new string[] { "Dampf", "Diesel",};
            var B_Evren= new Bahnhof(stringa2, "EvrenDalles-Bahnhof");

            var stringa3 = new string[] { "Diesel"};
            var B_Tizian = new Bahnhof(stringa3, "TizianPlatz-Bahnhog");
            var snull = new string[] { "a" };
            var BahnhofNull = new Bahnhof(snull, "Exit");

            var Karte0 = new Bahnhof[] {BahnhofNull,B_Mörfelden,B_Evren,B_Tizian };

            var stringb1 = new string[] { "Dampf", "Diesel", "Elektro","Diesel","Elektro" };
            var B_GroßGerau = new Bahnhof(stringb1, "Groß-Gerau-Dornberg");

            var stringb2 = new string[] { "Dampf", "Dampf", "Dampf" };
            var B_BSGG = new Bahnhof(stringb2, "BSGG-Bahnhof");

            var stringb3 = new string[] { "Diesel", "Elektro" };
            var B_Marktplatz = new Bahnhof(stringb3, "Marktplatz-Bahnhof");
            
            var stringb4= new string[] { "Elektro" };
            var B_PenenrWeg = new Bahnhof(stringb4, "PennerWeg-Bahnhof");
            
            var Karte1= new Bahnhof[] { B_GroßGerau, B_BSGG, B_Marktplatz, B_PenenrWeg};

            var Liste = new List<Bahnhof[]>();
            Liste.Add(Karte0);
            Liste.Add(Karte1);

            karte = Liste;

            



        }

        public void Start()
        {

            object o;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Bahnhof[]>));
            using (StreamReader reader = new StreamReader(@"..\..\..\Karte.xml"))
            {
                 o = serializer.Deserialize(reader);
            }karte = (List<Bahnhof[]>)o;

            
            Spieler1 = (Spieler)LoadPlayer();
            //Laden des Spielstandes
            Spieler1 = new Spieler();
            if (!File.Exists(@"..\..\..\Spieler.xml")){
                File.Create(@"..\..\..\Spieler.xml");
                Spieler1 = new Spieler(1);
                SavePlayer(Spieler1);
            }
            else {                
                Spieler1 = (Spieler)LoadPlayer();
                

            }
            ;
            string Thomas = @"                    ▓▓▓▓▓▓                                                                                                                     
                  ▓▓▓▓▓▓▓▓▓▓                  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓                                                                                          
                    ▓▓▓▓▓▓                  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓                                                                                        
                    ▓▓▓▓▓▓                ▓▓▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▓▓                                                                                        
                    ▓▓▓▓▓▓                ▓▓▒▒▒▒▓▓  ▒▒▒▒    ▒▒▒▒  ▒▒▓▓    ▒▒      ▓▓                                                                                        
                    ▓▓▓▓▓▓                ▓▓▒▒▒▒▓▓▒▒  ▒▒    ▒▒  ▒▒  ▓▓    ▒▒      ▓▓                                                                                        
                    ▓▓▓▓▓▓                ▓▓▒▒▒▒▓▓  ▒▒▒▒    ▒▒▒▒  ▒▒▓▓    ▒▒      ▓▓                                                                                        
            ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓    ▒▒      ▓▓▓▓▓▓▓▓                                                                                  
        ████      ▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▓▓▒▒▒▒▒▒▒▒  ▒▒▒▒▒▒▒▒▓▓                                                                                  
      ██              ▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓                                                                                  
    ██                  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓                                                                                  
    ██    ████  ████    ▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓                                                                                  
  ██      ████░░████      ▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓                                                                                  
  ██          ░░          ▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓                                                                                  
  ██        ░░            ▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒  ▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓                                            ▒                                     
    ██        ░░        ▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓                                            ▒▒                                    
    ██    ░░      ░░    ▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒  ▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓                                           ▒▒                                     
      ██    ░░░░░░    ▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒  ▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓                   ▒▒▒▒                   ▒▒          ▒                 ▒▒▒     
        ████      ▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒      ▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓                ▒▒▒▒       ▒▒       ▒▒    ▒▒▒▒▒      ▒   ▒            ▒▒▒▒      
            ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓             ▒▒▒▒▒▒       ▒▒       ▒▒     ▒▒   ▒    ▒▒  ▒           ▒▒▒▒▒▒▒       
              ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓           ▒▒▒  ▒▒        ▒▒▒       ▒▒     ▒▒   ▒    ▒▒▒              ▒▒          
        ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▒▒▒▒▒▒▓▓▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓          ▒▒     ▒▒         ▒▒       ▒▒▒    ▒▒  ▒                                 
    ▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓                  ▒▒          ▒                          ▒                        
  ▓▓      ▓▓▓▓    ▓▓▓▓        ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒                 ▒▒▒      ▒▒                           ▒▒▒                      
▓▓        ▓▓▓▓    ▓▓▓▓      ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒                ▒▒▒                ▒▒▒▒▒   ▒▒▒   ▒▒▒     ▒▒▒▒   ▒   ▒
▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒                               ▒▒▒▒▒      ▒     ▒        ▒  ▒    ▒▒  ▒          
▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓▓▓▓▓▒▒▒▒▒▒                             ▒▒▒  ▒▒      ▒▒▒    ▒      ▒▒   ▒    ▒▒▒     
▒▒██████▒▒██████▒▒▒▒██████▒▒▒▒▒▒▒▒▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▓▓▒▒▒▒▒▒        ▒▒▒▒             ▒▒▒▒▒     ▒▒        ▒    ▒▒▒   ▒     ▒                 
▒▒▒▒██▒▒▒▒████▒▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓         ▒▒▒▒▒▒▒▒▒▒        ▒▒▒▒▒        ▒▒     ▒▒                                   
▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓        ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒                                                  
                ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓        ▒▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒                                                
                                ▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░      ▒▒▒▒▒▒▒▒▒        ▒▒▒▒▒▒▒        ▒▒                                                  
                                  ▒▒▒▒▒▒  ▒▒▒▒▒▒  ▒▒▒▒▒▒  ▒▒▒▒▒▒  ▒▒▒▒▒▒  ▒▒▒▒▒▒          ▒▒▒              ▒▒                                                               
                                                                                                                                                                            
                                                                                                                                                                            
                                                                                                                              
      
";
            //Hauptmenü
            var StEn = new string[] { "Starten", "Beenden" };
            var Hauptmenü = new Menü(Thomas,StEn);
            int Start = 1; 
            do
            {
                Start = Hauptmenü.Run();
                if(Start == 0)
                {
                    //Spiel wird geladen
                    SpielstandLaden(Spieler1);
                }
            } while (Start == 0);
            {

            }
        }
        private void SpielstandLaden(Spieler _spieler)
        {
            var StEn = new string[] { "Depot", "Inventar","Shop","Karte","Exit" };
            var SpielerHauptmenü = new Menü("Menü", StEn);
            int Spielen = 0;
            do
            {
                SavePlayer(Spieler1);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Bahnhof[]>));
                using (StreamWriter writer = new StreamWriter(@"..\..\..\Karte.xml"))
                {
                    serializer.Serialize(writer, karte);
                }
                //Spieler ist im Menü & kann entscheiden was er jetzt tut
                Spielen = SpielerHauptmenü.Run();
                switch (Spielen)
                {
                    case 0:
                        karte = _spieler.DisplayDepot(karte);
                        break;
                    case 1:
                        _spieler.DisplayInventar();
                        break;
                    case 2:

                        break;
                    case 3:
                        var KartenNamen = new string[8];
                        int i = 0;
                        foreach(Bahnhof[] Bahnhöfe in karte)
                        {
                            
                            foreach (Bahnhof b in Bahnhöfe)
                            {
                                KartenNamen[i] = b.Name;
                                i++;
                            }
                        }
                        var Kartenmenü = new Menü("Alle verfügbaren Bahnhöfe:", KartenNamen);
                        int Auswahl = -1;
                        while (Auswahl != 0)
                        {
                            Auswahl = Kartenmenü.Run();
                            if (Auswahl ==0)
                            {

                            }
                            else
                            {
                                
                                int k = Auswahl / 4, z = Auswahl - k * 4;
                                int j = 1;
                                foreach (Gleis g in karte[k][z].BahnhofGleise)
                                {
                                    Console.WriteLine("Gleis {0}", j);
                                    Console.WriteLine("Befahren: {0}", Convert.ToString(g.Befahren));
                                    Console.WriteLine("erlaubter Zugtyp: {0}", g.ErlaubterZugtyp);
                                    if (g.Befahren)
                                    {
                                        Console.WriteLine("Zug: {0}", g.GleisZug.Name);
                                    }
                                    j++;
                                    Console.WriteLine();
                                }
                                Console.ReadKey();
                            }
                            
                        }





                        break;

                }
            } while (Spielen != 4);
            {
                
            }
            

        }
        private object LoadPlayer()
        {
            object o;
            XmlSerializer serializer = new XmlSerializer(typeof(Spieler));
            using (StreamReader reader = new StreamReader(@"..\..\..\Spieler.xml"))
            {
                o = serializer.Deserialize(reader);
            }
            return o;
        }

        private void SavePlayer(Spieler players)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Spieler));
            using (StreamWriter writer = new StreamWriter(@"..\..\..\Spieler.xml"))
            {
                serializer.Serialize(writer, players);
            }
        }

        private Spieler TestingSpieler()
        {
            
            var m = new Motor();
            m.Leistung = 100;
            m.Name = "V6";
            m.Preis = 200;
            var m2 = new Motor();
            m2.Leistung = 300;
            m2.Name = "V8";
            m2.Preis = 300;
            var zt1 = new Zugtyp("Dampf");
            zt1.Preis = 200;
            zt1.Name = "Dampflock";
            zt1.Zugtype = "Dampf";
            var zt2 = new Zugtyp("Elektro");
            zt2.Preis = 500;
            zt2.Name = "Elektrolock";
            var Pw = new Personwagen();
            Pw.Name = "Persona";
            Pw.Preis = 2;
            var Gw = new Güterwagon();
            Gw.Name = "Kohlewagon";
            Gw.Preis = 100;
            var Bw = new Bistrowagon();
            Bw.Name = "Bistro";
            Bw.Preis = 22;
            Bw.Bonus = 50;
            var Zug1 = new Zug();
            Zug1.Zug_Motor = m;
            Zug1.Zug_Zugtyp = zt1;
            Zug1.Zug_Wagons.Add(Gw);
            Zug1.Zug_Wagons.Add(Bw);
            Zug1.Fahrzeit = "0";
            Zug1.Name = "Megabahn";
            var Zug2 = new Zug();
            Zug2.Zug_Motor = m2;
            Zug2.Zug_Zugtyp = zt2;
            Zug2.Zug_Wagons.Add(Gw);
            Zug2.Zug_Wagons.Add(Pw);
            Zug2.Name = "Superbahn";
            Zug2.Fahrzeit = "0";
            var Spieler1 = new Spieler(1);
            var zt3 = new Zugtyp("Diesel");

            Spieler1.Spieler_Zugteile.Add(zt3);

            Spieler1.Spieler_Depot.AddZug(Zug1);
            Spieler1.Spieler_Depot.AddZug(Zug2);
            Spieler1.Spieler_Zugteile.Add(m);
            Spieler1.Spieler_Zugteile.Add(m2);
            Spieler1.Spieler_Zugteile.Add(zt1);
            Spieler1.Spieler_Zugteile.Add(zt2);
            Spieler1.Spieler_Zugteile.Add(Pw);
            Spieler1.Spieler_Zugteile.Add(Gw);
            Spieler1.Spieler_Zugteile.Add(Bw);

            return Spieler1;
        }
    }
}
