using System;
using System.Collections.Generic;
using System.Text;

namespace Tschuuuuu_tschu
{
    [Serializable]
    class Zugteile
    {
        protected int preis;
        protected string name;

        public void SetPreis(int _preis)
        {
            preis = _preis;
        }
        public int GetPreis()
        {
            return preis;
        }
        public void SetName(string _name)
        {
            name = _name;
        }
        public string GetName()
        {
            return name;
        }
    }

}
