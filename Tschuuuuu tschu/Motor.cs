using System;
using System.Collections.Generic;
using System.Text;

namespace Tschuuuuu_tschu
{
    [Serializable]
    public class Motor : Zugteile 
    {
        private string typ;
        private int leistung;
        private int geschwindigkeit;

        public int Leistung { get { return leistung; } set { leistung= value; } }

        public override void ShowAllStats()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Preis);
            Console.WriteLine(typ);
            Console.WriteLine(leistung);
            Console.WriteLine(geschwindigkeit);
        }
    }
}
