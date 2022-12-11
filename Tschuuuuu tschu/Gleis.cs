using System;
using System.Collections.Generic;
using System.Text;

namespace Tschuuuuu_tschu
{
    [Serializable]
    public class Gleis
    {
        private Zug zug;
        private string zugtypen;
        private bool befahren;

        public Zug GleisZug { get { return zug; } set { zug = value; } }
        public string ErlaubterZugtyp { get { return zugtypen; } set { zugtypen= value; } }
        public bool Befahren { get { return befahren; } set { befahren= value; } }

        public Gleis()
        {

        }
    }
}
