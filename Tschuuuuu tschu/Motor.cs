using System;
using System.Collections.Generic;
using System.Text;

namespace Tschuuuuu_tschu
{
    [Serializable]
    public class Motor : Zugteile 
    {
        private int leistung;
        private int geschwindigkeit;

        public int Leistung { get { return leistung; } set { leistung= value; } }
        public int Geschwindigkeit{ get { return geschwindigkeit;} set { geschwindigkeit= value; } }

        public override void ShowAllStats()
        {
            Console.WriteLine("Name: {0}",Name);
            Console.WriteLine("Preis: {0}", Preis);
            Console.WriteLine("Leistung: {0}PS", Leistung);
            Console.WriteLine("Geschwindigkeit: {0}", Geschwindigkeit);
        }
    }
}
