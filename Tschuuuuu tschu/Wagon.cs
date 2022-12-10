using System;
using System.Collections.Generic;
using System.Text;

namespace Tschuuuuu_tschu
{
    [Serializable]
    public class Wagon: Zugteile
    {
        protected int gewicht;

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

        public void SetGüter(string _g)
        {
            güter = _g;
        }
        public string GetGüter() 
        {
            return güter;
        }
    }

    [Serializable]
    public class Personwagen : Wagon
    {
        private int maxperson;
        private int personanzahl;

        public void SetMaxP(int _maxp)
        {
            maxperson = _maxp;
        }
        public void SetPanzahl(int _Panzahl)
        {
            personanzahl = _Panzahl;
        }
        public int GetMaxP()
        {
            return maxperson;
        }
        public int GetPanzahl()
        {
            return personanzahl;
        }
    }
    [Serializable]
    public class Bistrowagon : Wagon
    {
        private int bonus;

        public void SetBonus(int _bonus)
        {
            bonus = _bonus;
        }
        public int GetBonus()
        {
            return bonus;
        }
    }
}
