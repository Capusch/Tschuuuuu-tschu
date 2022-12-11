using System;
using System.Collections.Generic;
using System.Text;

namespace Tschuuuuu_tschu
{
    [Serializable]
    public class Zugtyp : Zugteile
    {  
        private string zugtype;
        private string sprite;
        public string Zugtype { get { return zugtype; } set {zugtype = value; } }
        public string Sprite{ get { return sprite; } set { sprite= value; } }

        public override void ShowAllStats()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Preis: {0}", Preis);
            Console.WriteLine("Zugtyp: {0}", Zugtype);
        }
    }
}
