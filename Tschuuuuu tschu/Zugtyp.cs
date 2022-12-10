using System;
using System.Collections.Generic;
using System.Text;

namespace Tschuuuuu_tschu
{
    [Serializable]
    public class Zugtyp : Zugteile
    {  
        private string zugtyp;
        private int wagonmax;
        private string sprite;

        public override void ShowAllStats()
        {
            Console.WriteLine(name);
            Console.WriteLine(preis);
            Console.WriteLine(zugtyp);
        }
    }
}
