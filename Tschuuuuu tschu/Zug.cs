using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Tschuuuuu_tschu
{
    [Serializable]
    public class Zug
    {
        private string name;
        private Motor motor;
        private List<Wagon> wagons = new List<Wagon>(); 
        private Zugtyp zugtyp;
        private bool amfahren;
        private string fahrzeit;
        private string nameBahnhoffahrt;

        public string Name { get { return name; } set { name = value; } }
        public List<Wagon> Zug_Wagons { get { return wagons; } set { wagons = value; } }
        public Motor Zug_Motor { get { return motor; } set { motor= value; } }
        public Zugtyp Zug_Zugtyp { get { return zugtyp; } set { zugtyp = value; } }
        public bool Amfahren  { get { return amfahren; } set { amfahren= value; } }
        public string Fahrzeit{ get { return fahrzeit; } set { fahrzeit= value; } }
        public string NameBahnhoffahrt { get { return nameBahnhoffahrt; } set { nameBahnhoffahrt= value; } }


        public Zug()
        {

        }
        public Zug( int i)
        {
            
            fahrzeit = "0";
        }
        public int[] DisplayPersonen() 
        {
            int x = 0;
            int[] count = new int[x];
            foreach (Personwagen pwagen in wagons)
            {
                count[x] = pwagen.Personenanzahl;
                x++;
            }
            return count;
        }
        public string[] DisplayGüter()
        {
            int i = 0;
            string[] g = new string[i];
          foreach(Güterwagon gwagon in wagons)
            {
                g[i] = gwagon.Güter;
                i++;
            }
            return g;
        }

        public int DisplayVerdienst()
        {
            Random r = new Random();
            string[] FahrzeitSplit = fahrzeit.Split(":");
            
            Bistrowagon bw = new Bistrowagon();
            var pw = new List<Personwagen>();
            var gw = new List<Güterwagon>();
            foreach (Wagon w in wagons)
            {
                if (w.GetType() == typeof(Bistrowagon))
                {
                    bw = (Bistrowagon)w;
                }
                else if (w.GetType() == typeof(Personwagen))
                {
                    pw.Add((Personwagen)w);
                }
                else if (w.GetType() == typeof(Güterwagon))
                {
                    gw.Add((Güterwagon)w);
                }
            }
            int mp = 0;
            foreach (Personwagen p in pw)
            {
                mp += p.MaxPersonen;
            }
            foreach (Güterwagon g in gw)
            {
                switch (g.Güter)
                {
                    case "Kohle":
                        mp += r.Next(50,100);
                        break;
                    case "Gas":
                        mp += r.Next(100, 150);
                        break;
                    case "Teddy":
                        mp += r.Next(200,250);
                        break;
                }
            }
            mp = (mp * bw.Bonus)/ 100;
            mp = (mp * Convert.ToInt32(FahrzeitSplit[2]) * 2) / 10; 
            return mp;
        }


        public void Fahren(Bahnhof _b,int Fahrzeit)
        {
            nameBahnhoffahrt = _b.Name;
            string Fahrtfertig;

            string Date = DateTime.Now.ToString("H:mm");
            Console.WriteLine(Date);
            string[] date = Date.Split(":");
            int a = Convert.ToInt32(date[1]);
            int b = Convert.ToInt32(date[0]);
            if (a + Fahrzeit >= 60)
            {
                a = (a + Fahrzeit) - 60;
                b++;
            }
            else
            {
                a = a + Fahrzeit;
            }
            if (a < 10)
            {
                string string_a = "0" + Convert.ToString(a);
                Fahrtfertig = Convert.ToString(b) + ":" + string_a+ ":" + Convert.ToString(Fahrzeit);
            }
            else
            {
                Fahrtfertig = Convert.ToString(b) + ":" + Convert.ToString(a) + ":" + Convert.ToString(Fahrzeit);
            }

            fahrzeit = Fahrtfertig;
            Amfahren = true;
        }
    }
}
