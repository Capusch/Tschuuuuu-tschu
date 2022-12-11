using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Tschuuuuu_tschu
{
    [XmlInclude(typeof(Bistrowagon))]
    [XmlInclude(typeof(Güterwagon))]
    [XmlInclude(typeof(Personwagen))]
    [Serializable]
    public class Wagon : Zugteile
    {
        //protected int gewicht;

        public Wagon()
        {

        }

    }
    
   
    [Serializable]
    public class Güterwagon : Wagon
    {
        private string güter;
        public Güterwagon()
        {

        }
        public string Güter { get { return güter; } set { güter = value; } }
        public override void ShowAllStats()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Preis: {0}", Preis);
            Console.WriteLine("Güter: {0}", Güter);
            
        }

    }

    [Serializable]
    public class Personwagen : Wagon
    {
        private int maxperson;
        private int personanzahl;

        public int MaxPersonen { get { return maxperson; } set { maxperson = value; } }
        public int Personenanzahl { get { return personanzahl; } set { personanzahl = value; } }


        public override void ShowAllStats()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Preis: {0}", Preis);
            Console.WriteLine("MaxPersonen: {0}",MaxPersonen);
        }
        
    }
    [Serializable]
    public class Bistrowagon : Wagon
    {
        private int bonus;

        public int Bonus { get { return bonus; } set { bonus= value; } }

        public override void ShowAllStats()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Preis: {0}", Preis);
            Console.WriteLine("BistroBonus: {0}%", Bonus);
        }
    }
}
