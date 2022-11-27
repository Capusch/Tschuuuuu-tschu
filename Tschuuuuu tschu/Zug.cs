using System;
using System.Collections.Generic;
using System.Text;

namespace Tschuuuuu_tschu
{
    [Serializable]
    class Zug
    {
        private Motor motor;
        private List<Wagon> wagons = new List<Wagon>(); 
        private Zugtyp zugtyp;
        private DateTime timer;

        public Zug( Motor _motor, Zugtyp _zugtyp)
        {
            motor = _motor;
            zugtyp = _zugtyp;
        }
        public int[] DisplayPersonen() 
        {
            int x = 0;
            int[] count = new int[x];
            foreach (Personwagen pwagen in wagons)
            {
                count[x]= pwagen.GetPanzahl();
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
                g[i] = gwagon.GetGüter();
                i++;
            }
            return g;
        }
        public int DisplayWeight()
        {
            int y = 0;
            int gw = 0;
            int[] gesamtweight= new int[y];
            foreach(Wagon wagon in wagons)
            {
                gesamtweight[y] = wagon.GetWeight();
                gw += gesamtweight[y];
                y++;
            }
            
            Console.WriteLine(gw);
            return gw;
        }
        public void AddWagon(Wagon _wagon)
        {
            wagons.Add(_wagon); 
        }

        public int DisplayVerdienst()
        {
            int verdienst;
            int b = 0;
            foreach(Bistrowagon bw in wagons)
            {
                b = bw.GetBonus();
            }
            
            return verdienst ;
        }
    }
}
