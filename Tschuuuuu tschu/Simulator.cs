using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Tschuuuuu_tschu
{
    class Simulator
    {



        public void Start()
        {
            //Laden des Spielstandes
            var Spieler1 = new Spieler();
            if (!File.Exists(@"..\..\..\Spieler.xml")){
                File.Create(@"..\..\..\Spieler.xml");
                var s = new Spieler(1);
                Spieler1 = s;
                SavePlayer(s);
                Console.ReadKey();
            }
            else {                
                Spieler1 = (Spieler)LoadPlayer();
                Spieler1 = TestingSpieler();
            }
            

            //Hauptmenü
            var StEn = new string[] { "Starten", "Beenden" };
            var Hauptmenü = new Menü("Tschuschu",StEn);
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
            var StEn = new string[] { "Depot", "Inventar","Shop","Exit" };
            var SpielerHauptmenü = new Menü("Menü", StEn);
            int Spielen = 0;
            do
            {
                //Spieler ist im Menü & kann entscheiden was er jetzt tut
                Spielen = SpielerHauptmenü.Run();
                switch (Spielen)
                {
                    case 0:
                        _spieler.DisplayDepot();
                        break;
                    case 1:
                        _spieler.DisplayInventar();
                        break;
                }
            } while (Spielen != 3);
            {
                
            }
            

        }
        static object LoadPlayer()
        {
            object o;
            XmlSerializer serializer = new XmlSerializer(typeof(Spieler));
            using (StreamReader reader = new StreamReader(@"..\..\..\Spieler.xml"))
            {
                o = serializer.Deserialize(reader);
            }
            return o;
        }

        public static void SavePlayer(Spieler players)
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
            var zt1 = new Zugtyp();
            zt1.Preis = 200;
            zt1.Name = "Dampflock";
            var zt2 = new Zugtyp();
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
            var Zug1 = new Zug();
            Zug1.Zug_Motor = m;
            Zug1.Zug_Zugtyp = zt1;
            Zug1.Zug_Wagons.Add(Gw);
            Zug1.Zug_Wagons.Add(Bw);
            Zug1.Name = "Megabahn";
            var Zug2 = new Zug();
            Zug2.Zug_Motor = m2;
            Zug2.Zug_Zugtyp = zt2;
            Zug2.Zug_Wagons.Add(Gw);
            Zug2.Zug_Wagons.Add(Pw);
            Zug2.Name = "Superbahn";
            var Spieler1 = new Spieler(1);
            
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
