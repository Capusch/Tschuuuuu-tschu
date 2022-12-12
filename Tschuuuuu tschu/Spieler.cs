using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Media;


namespace Tschuuuuu_tschu
{
    [Serializable]
    public class Spieler
    {
        //private Attribute
        private Depot depot;
        private int münzen;
        private List<Zugteile> zugteile;

        //public get & set accesor via Properties 
        public Depot Spieler_Depot{get{return depot;}set{depot = value;}}
        public int Münzen { get { return münzen; } set { münzen = value;}}
        public List<Zugteile> Spieler_Zugteile{ get { return zugteile; } set { zugteile = value; } }
        
        //Konstruktor
        public Spieler()
        {

        }
        public Spieler(int i)
        {
            münzen = 0;
            zugteile = new List<Zugteile>();
            depot = new Depot(1);
        }

        //Methoden private
        private Zug ZugKonfigurieren(Zug _zug)
        {

            var KMA = new string[] { "Motor", "Zugtyp", "Einen Wagon","Exit" };
            var KonfigurierMenü = new Menü("Was willst du an deinem Zug verändern?",KMA);
            int Auswahl = 0;
            do
            {
                Auswahl = KonfigurierMenü.Run();
                switch (Auswahl)
                {
                    case 0:
                        //Alle verfügbaren Motoren werden gesucht
                        var GesuchteTeile = new List<Zugteile>();
                        GesuchteTeile = TeilSuche("Motor");
                        var GesuchteMotor = new List<Motor>();
                        var MotorenNamen = new string[GesuchteTeile.Count+1];
                        int i = 0;
                        foreach (Zugteile z in GesuchteTeile)
                        {
                            GesuchteMotor.Add((Motor)z);
                            MotorenNamen[i] = z.Name;
                            i++;
                        }
                        MotorenNamen[GesuchteTeile.Count] = "Exit";
                        //Abfrage welcher Motor verbaut werden soll
                        var MotorMenü = new Menü("Welchen Motor willst du verbauen?",MotorenNamen);
                        int Auswahl1 = 0;
                        do
                        {
                            //Abfrage on user sicher mit tausch
                            Auswahl1 = MotorMenü.Run();
                            if(Auswahl1!= GesuchteMotor.Count)
                            {
                                string Text = "Willst du sicher " + _zug.Zug_Motor.Name + " mit " + GesuchteMotor[Auswahl1].Name + " tauschen?";
                                var Auswahlstring = new string[] { "Ja", "Nein" };
                                var AuswahlMenü = new Menü(Text, Auswahlstring);
                                int Auswah2 = AuswahlMenü.Run();
                                if (Auswah2 == 0)
                                {
                                    //Bei Tausch wird altes in ZugteileListe gelöscht und neues verbaut
                                    Spieler_Zugteile.Add(_zug.Zug_Motor);
                                    _zug.Zug_Motor = GesuchteMotor[Auswahl1];
                                    Spieler_Zugteile.RemoveAt(SpezifischeTeilsuche(GesuchteMotor[Auswahl1]));
                                    Auswahl1 = GesuchteTeile.Count;
                                }
                            }     
                        } while (Auswahl1 != GesuchteTeile.Count);
                        {

                        }
                        
                        break;
                    case 1:
                        //Alle verfügbaren Zugtypen werden gesucht
                        var GesuchteTeile1 = new List<Zugteile>();
                        GesuchteTeile = TeilSuche("Zugtyp");
                        var GesuchteZugtyp = new List<Zugtyp>();
                        var Zugtypnamen = new string[GesuchteTeile.Count + 1];
                        int i1 = 0;
                        foreach (Zugteile z in GesuchteTeile)
                        {
                            GesuchteZugtyp.Add((Zugtyp)z);
                            Zugtypnamen[i1] = z.Name;
                            i1++;
                        }
                        Zugtypnamen[GesuchteTeile.Count] = "Exit";
                        //Abfrage welcher Motor verbaut werden soll
                        var ZugTypMenü = new Menü("Welchen Zugtyp willst du verbauen?", Zugtypnamen);
                        int Auswahla1 = 0;
                        do
                        {
                            //Abfrage on user sicher mit tausch
                            Auswahla1 = ZugTypMenü.Run();
                            if (Auswahla1 != GesuchteZugtyp.Count)
                            {
                                string Text = "Willst du sicher " + _zug.Zug_Zugtyp.Name + " mit " + GesuchteZugtyp[Auswahla1].Name + " tauschen?";
                                var Auswahlstring = new string[] { "Ja", "Nein" };
                                var AuswahlMenü = new Menü(Text, Auswahlstring);
                                int Auswah2 = AuswahlMenü.Run();
                                if (Auswah2 == 0)
                                {
                                    //Bei Tausch wird altes in ZugteileListe gelöscht und neues verbaut
                                    Spieler_Zugteile.Add(_zug.Zug_Zugtyp);
                                    _zug.Zug_Zugtyp = GesuchteZugtyp[Auswahla1];
                                    Spieler_Zugteile.RemoveAt(SpezifischeTeilsuche(GesuchteZugtyp[Auswahla1]));
                                    Auswahla1 = GesuchteTeile.Count;
                                }
                            }
                        } while (Auswahla1 != GesuchteTeile.Count);
                        {

                        }
                        break;
                    case 2:

                        int Auswahlb1 = 0, Auswahlb2 = 0, Auswahlb3 = 0;
                        do
                        {
                            int i3 = 0;
                            var GesuchteTeile2 = new List<Zugteile>();
                            GesuchteTeile2 = TeilSuche("Wagon");
                            var GesuchteWagons = new List<Wagon>();
                            var WagonNamenSpieler = new string[GesuchteTeile2.Count];
                            foreach (Zugteile z in GesuchteTeile2)
                            {
                                GesuchteWagons.Add((Wagon)z);
                                WagonNamenSpieler[i3] = z.Name;
                                i3++;
                            }

                            //Schaut ob Bistro vorhanden und macht Liste von Wagons
                            bool BistroVorhanden = false;
                            var WagonNamen = new string[_zug.Zug_Wagons.Count + 1];
                            int i2 = 0;
                            var KF = new string[] { "Konfigurieren", "Hinzufügen", "Exit" };
                            foreach (Wagon z in _zug.Zug_Wagons)
                            {
                                WagonNamen[i2] = z.Name;
                                if (z.GetType() == typeof(Bistrowagon))
                                {
                                    BistroVorhanden = true;
                                }
                                i2++;
                            }
                            WagonNamen[_zug.Zug_Wagons.Count] = "Exit";
                            //Fragt was der user machen will
                            var WagonMenü = new Menü("Was willst du tun?", KF);
                            




                            //Checkt, ob man nur Konfigurieren kann oder auch Hinzufügen
                            Auswahlb1 = WagonMenü.Run();
                            //Konfiguriert
                            if(Auswahlb1 == 0)
                            {
                                var BauMenü = new Menü("Welchen Wagon willst du austauschen?",WagonNamen);
                                do
                                {
                                    Auswahlb3 = BauMenü.Run();
                                    if(Auswahlb3 != _zug.Zug_Wagons.Count)
                                    {
                                        var BauMenü2 = new Menü("Welchen von deinen Wagons willst du einsetzen?",WagonNamenSpieler);
                                        Auswahlb2 = BauMenü2.Run();
                                        if(BistroVorhanden && _zug.Zug_Wagons[Auswahlb3].GetType() != typeof(Bistrowagon) && GesuchteWagons[Auswahlb2].GetType() == typeof(Bistrowagon))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Man kann nicht mehr als einen Bistrowagon haben!");
                                            Thread.Sleep(2000);
                                        }
                                        else
                                        {
                                            Spieler_Zugteile.Add(_zug.Zug_Wagons[Auswahlb3]);
                                            _zug.Zug_Wagons[Auswahlb3] = GesuchteWagons[Auswahlb2];
                                            Spieler_Zugteile.RemoveAt(SpezifischeTeilsuche(GesuchteWagons[Auswahlb2]));
                                            Auswahlb3 = _zug.Zug_Wagons.Count;
                                        }
                                        

                                    }
                                } while (Auswahlb3 != _zug.Zug_Wagons.Count);
                                {

                                }
                            }
                            else if (Auswahlb1 == 1 && _zug.Zug_Wagons.Count < _zug.Zug_Motor.Leistung / 50)
                            {
                                var BauMenü2 = new Menü("Welchen von deinen Wagons willst du einsetzen?", WagonNamenSpieler);
                                Auswahlb2 = BauMenü2.Run();
                                if (BistroVorhanden && GesuchteWagons[Auswahlb2].GetType() == typeof(Bistrowagon))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Man kann nicht mehr als einen Bistrowagon haben!");
                                    Thread.Sleep(2000);
                                }
                                else
                                {

                                    _zug.Zug_Wagons.Add(GesuchteWagons[Auswahlb2]);
                                    Spieler_Zugteile.RemoveAt(SpezifischeTeilsuche(GesuchteWagons[Auswahlb2]));
                                    
                                }
                            }
                            //Falls user Hinzügen wählt, es aber nicht kann, weil Limit erreicht
                            else if (Auswahlb1 == 1 && _zug.Zug_Wagons.Count == _zug.Zug_Motor.Leistung / 50)
                            {
                                Console.Clear();
                                Console.WriteLine("Maximalanzahl von Wagons erreicht!");
                                Thread.Sleep(2000);

                            }
                        } while (Auswahlb1 != 2);
                        {

                        }
                        
                        
                        
                        break;
                }
            } while (Auswahl != 3); {

            }
            
            return _zug;
        }
        private int SpezifischeTeilsuche(Zugteile _zt)
        {
            int j =-1 , i = 0;
            foreach(Zugteile z in Spieler_Zugteile)
            {
                if(z == _zt)
                {
                    j = i;
                }
                i++;
            }
            return j;
        }
        
        private List<Zugteile> TeilSuche(string _name)
        {
            var GesuchteTeile = new List<Zugteile>();
            if (_name == "Motor")
            {

                foreach(Zugteile m in Spieler_Zugteile)
                {
                    if (m.GetType() == typeof(Motor))
                    {
                        GesuchteTeile.Add(m);
                    }
                }
            }
            else if (_name == "Zugtyp")
            {

                foreach (Zugteile zt in Spieler_Zugteile)
                {
                    if (zt.GetType() == typeof(Zugtyp))
                    {
                        GesuchteTeile.Add(zt);
                    }
                }
                
            }
            else if (_name == "Wagon")
            {
                foreach (Zugteile w in Spieler_Zugteile)
                {
                    if (w.GetType() == typeof(Güterwagon) || w.GetType() == typeof(Personwagen) || w.GetType() == typeof(Bistrowagon))
                    {
                        GesuchteTeile.Add(w);
                    }
                }
                
            }
            return GesuchteTeile; 
        }
        private Zug ZugErstellen(List<Zugteile> _zugteile)
        {
            var GesuchteTeile = new List<Zugteile>();
            GesuchteTeile = TeilSuche("Motor");
            var GesuchteMotor = new List<Motor>();
            var MotorenNamen = new string[GesuchteTeile.Count];
            int i = 0;
            foreach (Zugteile z in GesuchteTeile)
            {
                GesuchteMotor.Add((Motor)z);
                MotorenNamen[i] = z.Name;
                i++;
            }

            var GesuchteTeile1 = new List<Zugteile>();
            GesuchteTeile1 = TeilSuche("Zugtyp");
            var GesuchteZugtyp = new List<Zugtyp>();
            var Zugtypnamen = new string[GesuchteTeile1.Count];
            int i1 = 0;
            foreach (Zugteile z in GesuchteTeile1)
            {
                GesuchteZugtyp.Add((Zugtyp)z);
                Zugtypnamen[i1] = z.Name;
                i1++;
            }

            var GesuchteTeile2 = new List<Zugteile>();
            GesuchteTeile2= TeilSuche("Wagon");
            var GesuchteWagons = new List<Wagon>();
            var WagonNamen = new string[GesuchteTeile2.Count];
            int i2 = 0;
            foreach (Zugteile z in GesuchteTeile2)
            {
                GesuchteWagons.Add((Wagon)z);
                WagonNamen[i2] = z.Name;
                i2++;
            }

            if(GesuchteWagons.Count == 0 ||GesuchteZugtyp.Count == 0 ||GesuchteMotor.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Du hast nicht genügend Teile");
                Thread.Sleep(2000);
                return null; 
            }
            int j = 0,j1 = 0,j2 = 0;
            var NeuerZug = new Zug(1);
            Console.Clear();
            Console.WriteLine("Wie willst du deinen Zug nennen?");
            NeuerZug.Name = Console.ReadLine();
            var ZugtypMenü = new Menü("Welchen Zugtyp willst du haben?", Zugtypnamen);
            j = ZugtypMenü.Run();
            NeuerZug.Zug_Zugtyp = GesuchteZugtyp[j];
            var MotorMenü= new Menü("Welchen Motor willst du haben?", MotorenNamen);
            j1 = MotorMenü.Run();
            NeuerZug.Zug_Motor = GesuchteMotor[j1];
            var WagonMenü = new Menü("Welchen Wagon willst du hinzufügen?", WagonNamen);
            j2 = WagonMenü.Run();
            NeuerZug.Zug_Wagons.Add(GesuchteWagons[j2]);
            Spieler_Zugteile.RemoveAt(SpezifischeTeilsuche(GesuchteZugtyp[j]));
            Spieler_Zugteile.RemoveAt(SpezifischeTeilsuche(GesuchteMotor[j1]));
            Spieler_Zugteile.RemoveAt(SpezifischeTeilsuche(GesuchteWagons[j2]));

            Spieler_Depot.AddZug(NeuerZug);

            return null ;
        }
        private List<Bahnhof[]> Checkzüge(List<Bahnhof[]> Karte)
        {
            string[] Splittedtime = DateTime.Now.ToString("H:mm").Split(":");
            int h = Convert.ToInt32(Splittedtime[0]);
            int mm = Convert.ToInt32(Splittedtime[1]);
            foreach (Zug z in depot.Züge)
            {
                int mmZug = 0, hZug = 0;
                if(z.Fahrzeit != "0")
                {
                    string[] SplittedtimeZug = z.Fahrzeit.Split(":");
                    hZug = Convert.ToInt32(SplittedtimeZug[0]);
                    mmZug = Convert.ToInt32(SplittedtimeZug[1]);
                }
                if (z.Amfahren && (mmZug <= mm || hZug < h))
                {
                    foreach (Bahnhof[] b in Karte)
                    {
                        foreach (Bahnhof _bh in b)
                        {
                            foreach (Gleis g in _bh.BahnhofGleise)
                            {
                                if (!g.Befahren)
                                {

                                }
                                else if (z.NameBahnhoffahrt == g.GleisZug.NameBahnhoffahrt &&z.Name == g.GleisZug.Name)
                                {
                                   int a = z.DisplayVerdienst();
                                    münzen = münzen + z.DisplayVerdienst();
                                    g.GleisZug = null;
                                    g.Befahren = false;
                                    z.Amfahren = false;
                                    z.Fahrzeit = "0";

                                    
                                }
                            }
                        }
                    }
                }

            }
            return Karte;
        }

        //Methoden public
        public List<Bahnhof[]> DisplayDepot(List<Bahnhof[]> Karte)
        {
            string DepotBild = @"            ▓▓▒▒▒▒▒▒        ▓▓▒▒▒▒▒▒▒▒      ▓▓▒▒▒▒▒▒▒▒        ▓▓▒▒▒▒▒▒      ▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒   
            ▓▓▒▒ ▓▓▒▒▒      ▓▓▒▒            ▓▓▒▒   ▓▓▒▒▒     ▓▓▒▒  ▓▓▒▒     ▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒        
            ▓▓▒▒  ▓▓▒▒      ▓▓▒▒            ▓▓▒▒   ▓▓▒▒▒    ▓▓▒▒    ▓▓▒▒           ▓▓▒▒
            ▓▓▒▒   ▓▓▒▒     ▓▓▒▒▒▒▒▒        ▓▓▒▒▒▒▒▒▒▒      ▓▓▒▒    ▓▓▒▒           ▓▓▒▒
            ▓▓▒▒   ▓▓▒▒     ▓▓▒▒            ▓▓▒▒            ▓▓▒▒    ▓▓▒▒           ▓▓▒▒
            ▓▓▒▒  ▓▓▒▒      ▓▓▒▒            ▓▓▒▒            ▓▓▒▒    ▓▓▒▒           ▓▓▒▒
            ▓▓▒▒ ▓▓▒▒▒      ▓▓▒▒            ▓▓▒▒             ▓▓▒▒  ▓▓▒▒            ▓▓▒▒
            ▓▓▒▒▒▒▒▒        ▓▓▒▒▒▒▒▒▒▒      ▓▓▒▒              ▓▓▒▒▒▒▒▒             ▓▓▒▒

                        ▓▓▒▒▒▒▒
                       ▓▓▒▒▒
                      ====          --=========================--
                      |  |     ====   |]||[]|   [___]   |[]||[|
                    >_|  |_----|  |---| ||  |   DEPOT   |  || |-----------______<
                  |_|    ==   ==___== | ||__| =   =   = |__|| | ==___==   ==    |_|
                [=|_|__| *_/__\_(o)_/__\__/_ \ |_|=|_| / _\__/__\_(o)_/__\_* | ||_|=]
                   / (*)   \__/ ~~~ \__/  \__/   _=_   \__/  \__/ ~~~ \__/   (*) \
===========================================================================================================";
            
            
            
            Console.Clear();
            //Checkt, ob Depot Leer ist
            if(Spieler_Depot.Züge.Count == 0)
            {
                Console.WriteLine("Dein Depot ist Leer!");
                Thread.Sleep(2000);
                return Karte;
            }
            //erzeugt string[] Zug.Name für Menü_Depot
            var MenüLen = new string[Spieler_Depot.Züge.Count + 2];
           for(int i = 0;i < Spieler_Depot.Züge.Count; i++)
            {
                MenüLen[i] = Spieler_Depot.Züge[i].Name;
            }
            MenüLen[Spieler_Depot.Züge.Count] = "Zug Erstellen";
            MenüLen[Spieler_Depot.Züge.Count+1] = "Exit";
            var DepotMenü = new Menü(DepotBild+"\nWähle den Zug aus, welchen du Konfigurieren / Ansehen willst.",MenüLen);
            int AuswahlZug = 0;
            do
            {
                Karte = Checkzüge(Karte);
                AuswahlZug = DepotMenü.Run();                
                int A2 = 0;
                if (AuswahlZug < Spieler_Depot.Züge.Count) {
                    do
                    {
                        Karte = Checkzüge(Karte);
                        string fh = "Fahren";
                        if (Spieler_Depot.Züge[AuswahlZug].Amfahren)
                        {
                            fh = fh + "/nicht im Depot";
                        }

                        string ZugMenüTitel = Spieler_Depot.Züge[AuswahlZug].Zug_Zugtyp.Sprite + Spieler_Depot.Züge[AuswahlZug].Name+"\nWas willst du tuen? \n";
                        var ZugAuswahl = new string[] { "Ansehen", "Konfigurieren",fh,"Umbennen","Exit" };
                        var ZugMenü = new Menü(ZugMenüTitel, ZugAuswahl);
                        A2 = ZugMenü.Run();
                        switch (A2)
                        {
                            case 0:
                                //Gibt Daten des Zuges aus
                                Console.Clear();
                                Console.WriteLine("Zugtyp: {0}", Spieler_Depot.Züge[AuswahlZug].Zug_Zugtyp.Name);
                                Console.WriteLine("Wagonanzahl: {0}", Spieler_Depot.Züge[AuswahlZug].Zug_Wagons.Count);
                                Console.WriteLine("Motor: {0}, {1}", Spieler_Depot.Züge[AuswahlZug].Zug_Motor.Name, Spieler_Depot.Züge[AuswahlZug].Zug_Motor.Leistung);
                                if (Spieler_Depot.Züge[AuswahlZug].Amfahren)
                                {
                                    Console.WriteLine("Fahrzeit: {0}", Spieler_Depot.Züge[AuswahlZug].Fahrzeit);

                                    Console.WriteLine("Angefahrender Bahnhof: {0}", Spieler_Depot.Züge[AuswahlZug].NameBahnhoffahrt);
                                }
                                else
                                {
                                    Console.WriteLine("Zug ist nicht am Fahren");
                                }
                                Console.ReadKey();
                                break;
                            case 1:
                                if (!Spieler_Depot.Züge[AuswahlZug].Amfahren)
                                {
                                    Spieler_Depot.Züge[AuswahlZug] = ZugKonfigurieren(Spieler_Depot.Züge[AuswahlZug]);
                                }
                                else
                                {
                                    Console.WriteLine("Zug ist am Fahren. Du kannst nicht Konfigurieren!");
                                    Console.ReadKey();
                                }
                                
                                break;
                            case 2:
                                if (Spieler_Depot.Züge[AuswahlZug].Amfahren)
                                {
                                    Console.WriteLine("Zug ist schon am Fahren!");
                                    Console.ReadKey();

                                }
                                else
                                {
                                    string[] stringBahnhöfe = new string[8];
                                    int i = 0;
                                    foreach (Bahnhof[] _b in Karte)
                                    {
                                       foreach(Bahnhof b in _b)
                                        {
                                            if (b.Name != null)
                                            {
                                                stringBahnhöfe[i] = b.Name;
                                            }
                                            i++;
                                        }
                                    }
                                    var BahnhofMenü = new Menü("Zu welchem Bahnhof willst du fahren?", stringBahnhöfe);
                                    int j = BahnhofMenü.Run();
                                    if (j != 0)
                                    {
                                        int k = j / 4,z = j-k*4;
                                        int Zugindikator = 0, Rundenindikator = 0;
                                        foreach(Gleis g in Karte[k][z].BahnhofGleise)
                                        {
                                            
                                            if (Zugindikator == 1)
                                            {
                                                
                                            }
                                            else if(!g.Befahren && Spieler_Depot.Züge[AuswahlZug].Zug_Zugtyp.Zugtype == g.ErlaubterZugtyp)
                                            {
                                                int Fahrzeit = (k + z) * 10 / 2;
                                                Spieler_Depot.Züge[AuswahlZug].Fahren(Karte[k][z], Fahrzeit);
                                                g.GleisZug = Spieler_Depot.Züge[AuswahlZug];
                                                Zugindikator++;
                                                
                                                g.Befahren = true;

                                                
                                            }
                                            else if (Rundenindikator == Karte[k][z].BahnhofGleise.Count-1 && Zugindikator == 0)
                                            {
                                                Console.WriteLine("Bahnhof ist nicht Befahrbar!");
                                                Thread.Sleep(2000);
                                            }
                                            Rundenindikator++;
                                        }
                                        
                                    }
                                }
                                break;
                            case 3:
                                if (!Spieler_Depot.Züge[AuswahlZug].Amfahren)
                                {
                                    Console.WriteLine("Wie willsr du den Zug Umbennen?");
                                    Spieler_Depot.Züge[AuswahlZug].Name = Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("Zug ist schon am Fahren!");
                                    Console.ReadKey();
                                }

                               
                                break;
                        }
                    } while (A2 != 4);
                    {

                    }
                }
                else if(AuswahlZug == Spieler_Depot.Züge.Count)
                {
                    ZugErstellen(Spieler_Zugteile);
                    return Karte;
                }
                

            } while (AuswahlZug < Spieler_Depot.Züge.Count );
            {
                
            }
            return Karte;
        }
        public void DisplayInventar()
        {
            string BildInventar = @"▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▒▒▒▒▒▒▓  ▓▓▒▒                                                     ▓▓▒▒
▓▓▒▒▓▓▓▓▓▓▓▓▓▓▒▒▓▓▒▓▒▒▒▒▓▒  ▓▓▒▒                                                     ▓▓▒▒
▓▓▓▓▒▒▓▓▓▓▓▓▒▒▓▓▓▓▒▒▓▒▒▓▒▒  ▓▓▒▒                                                     ▓▓▒▒
▓▓▓▓▓▓▒▒▓▓▒▒▓▓▓▓▓▓▒▒▒▓▓▒▒▒  ▓▓▒▒                                                   ▓▓▓▓▓▓▒▒
▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▒▒▒▓▓▒▒▒  ▓▓▒▒  ▓▓▒▓▓▓▓▓▒▒  ▓▓▒▒    ▓▓▒▒  ▓▓▓▓▓▓▓▒▒   ▓▓▒▓▓▓▓▓▒▒   ▓▓▒▒     ▓▓▓▓▓▓▒▒    ▓▓▒▓▓▓▒▒
▓▓▓▓▓▓▒▒▓▓▒▒▓▓▓▓▓▓▒▒▒▓▓▒▒▒  ▓▓▒▒  ▓▓▓▓▒▒ ▓▓▒▒  ▓▓▒▒  ▓▓▒▒  ▓▓▒▒   ▓▓▒▒  ▓▓▓▓▒▒ ▓▓▒▒  ▓▓▒▒    ▓▓▒▒  ▓▓▒▒   ▓▓▓▒▒▓▓▒▒
▓▓▓▓▒▒▓▓▓▓▓▓▒▒▓▓▓▓▒▒▓▒▒▓▒▒  ▓▓▒▒  ▓▓▒▒   ▓▓▒▒   ▓▓▒▒▓▓▒▒   ▓▓▓▓▓▓▓▓▒▒   ▓▓▒▒   ▓▓▒▒  ▓▓▒▒    ▓▓▒▒  ▓▓▒▒   ▓▓▒▒
▓▓▒▒▓▓▓▓▓▓▓▓▓▓▒▒▓▓▒▓▒▒▒▒▓▒  ▓▓▒▒  ▓▓▒▒   ▓▓▒▒    ▓▓▓▓▒▒    ▓▓▒▒         ▓▓▒▒   ▓▓▒▒  ▓▓▒▒    ▓▓▒▒  ▓▓▓▒▒  ▓▓▒▒
▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▒▒▒▒▒▒▓  ▓▓▒▒  ▓▓▒▒   ▓▓▒▒     ▓▓▒▒      ▓▓▓▓▓▓▓▒▒   ▓▓▒▒   ▓▓▒▒   ▓▓▓▓▒▒  ▓▓▓▓▓▓▒▓▓▒▒ ▓▓▒▒";
            
            
            int Auswahl = 0, Auswahl1 = 0;
            var AlleNamenTeile = new string[Spieler_Zugteile.Count + 1];
            AlleNamenTeile[Spieler_Zugteile.Count] = "Exit";
            var AuswahlMöglichkeiten = new string[] { "Alle", "Motoren", "Wagons", "Zugtypen", "Exit" };
            var InventarMenü = new Menü(BildInventar+"\nNach was willst du Suchen", AuswahlMöglichkeiten);
            while(Auswahl != 4)
            {
                var Zugteile = new List<Zugteile>();
                int i = 0;
                Auswahl = InventarMenü.Run();
                switch (Auswahl)
                {
                    case 0:
                        
                        foreach(Zugteile z in Spieler_Zugteile)
                        {
                            AlleNamenTeile[i] = z.Name;
                            i++;
                        }
                        var AlleMenü = new Menü("Alle Teile deines Inventar!", AlleNamenTeile);
                        while(Auswahl1 != AlleNamenTeile.Length - 1)
                        {
                            Auswahl1 = AlleMenü.Run();
                            if(Auswahl1 != AlleNamenTeile.Length-1)
                            {
                                Spieler_Zugteile[Auswahl1].ShowAllStats();
                                Console.ReadKey();
                            }
                        }
                        break;
                    case 1:
                        var GesuchteTeile = new List<Zugteile>();
                        GesuchteTeile = TeilSuche("Motor");
                        var GesuchteMotor = new List<Motor>();
                        var MotorenNamen = new string[GesuchteTeile.Count + 1];
                        MotorenNamen[GesuchteTeile.Count] = "Exit";
                        i = 0;
                        foreach (Zugteile z in GesuchteTeile)
                        {
                            GesuchteMotor.Add((Motor)z);
                            MotorenNamen[i] = z.Name;
                            i++;
                        }

                        var MotorMenü = new Menü("Alle Teile deines Inventar!", MotorenNamen);
                        while (Auswahl1 != MotorenNamen.Length - 1)
                        {
                            Auswahl1 = MotorMenü.Run();
                            if (Auswahl1 != MotorenNamen.Length - 1)
                            {
                                GesuchteMotor[Auswahl1].ShowAllStats();
                                Console.ReadKey();
                            }
                        }
                        break;
                    case 2:
                        GesuchteTeile = new List<Zugteile>();
                        GesuchteTeile = TeilSuche("Wagon");
                        var GesuchteWagons = new List<Wagon>();
                        var WagonNamen = new string[GesuchteTeile.Count + 1];
                        WagonNamen[GesuchteTeile.Count] = "Exit";
                        i = 0;
                        foreach (Zugteile z in GesuchteTeile)
                        {
                            GesuchteWagons.Add((Wagon)z);
                            WagonNamen[i] = z.Name;
                            i++;
                        }

                        var WagonMenü = new Menü("Alle Teile deines Inventar!", WagonNamen);
                        while (Auswahl1 != WagonNamen.Length - 1)
                        {
                            Auswahl1 = WagonMenü.Run();
                            if (Auswahl1 != WagonNamen.Length - 1)
                            {
                                GesuchteWagons[Auswahl1].ShowAllStats();
                                Console.ReadKey();
                            }
                        }
                        break;
                    case 3:
                        GesuchteTeile = new List<Zugteile>();
                        GesuchteTeile = TeilSuche("Zugtyp");
                        var GesuchteZugtyp = new List<Zugtyp>();
                        var ZugtypNamen = new string[GesuchteTeile.Count + 1];
                        ZugtypNamen[GesuchteTeile.Count] = "Exit";
                        i = 0;
                        foreach (Zugteile z in GesuchteTeile)
                        {
                            GesuchteZugtyp.Add((Zugtyp)z);
                            ZugtypNamen[i] = z.Name;
                            i++;
                        }

                        var ZugtypMenü = new Menü("Alle Teile deines Inventar!", ZugtypNamen);
                        while (Auswahl1 != ZugtypNamen.Length - 1)
                        {
                            Auswahl1 = ZugtypMenü.Run();
                            if (Auswahl1 != ZugtypNamen.Length - 1)
                            {
                                GesuchteZugtyp[Auswahl1].ShowAllStats();
                                Console.ReadKey();
                            }
                        }
                        break;
                }
            }
        }

        



    }
}
