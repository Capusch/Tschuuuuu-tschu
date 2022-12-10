using System;
using System.Collections.Generic;
using System.Text;

namespace Tschuuuuu_tschu
{
    [Serializable]
    public class Zugteile
    {
        protected int preis;
        protected string name;

        public int Preis { get { return preis; } set { preis= value; } }
        public string Name { get { return name; } set { name= value; } }

        public Zugteile()
        {

        }
        public virtual void ShowAllStats()
        {

        }
    }

}
