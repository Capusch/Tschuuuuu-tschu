using System;
using System.Collections.Generic;
using System.Text;

namespace Tschuuuuu_tschu
{
    [Serializable]
    public class Bahnhof
    {
        private List<Gleis> gleise;
        private string name;

        public List<Gleis> BahnhofGleise { get { return gleise; } set { gleise = value; } }
        public string Name { get { return name; } set { name = value; } }

        public Bahnhof(string[] a, string _n)
        {
            gleise = new List<Gleis>();
            foreach(string _a in a)
            {
                var Gleis = new Gleis();
                Gleis.ErlaubterZugtyp = _a;
                gleise.Add(Gleis);
            }
            name = _n;
        }
        public Bahnhof()
        {

        }
    }
}
