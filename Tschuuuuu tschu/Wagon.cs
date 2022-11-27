using System;
using System.Collections.Generic;
using System.Text;

namespace Tschuuuuu_tschu
{
    [Serializable]
    class Wagon: Zugteile
    {
        protected int gewicht;
        private int testc;

        public void SetWeight(int _weight)
        {
            gewicht = _weight;
        }
        public int GetWeight()
        {
            return gewicht;
        }
    }
    [Serializable]
    class Güterwagon : Wagon
    {
        private string güter;

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
    class Personwagen : Wagon
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
    class Bistrowagon : Wagon
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
