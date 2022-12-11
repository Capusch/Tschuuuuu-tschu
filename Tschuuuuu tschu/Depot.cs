using System;
using System.Collections.Generic;
using System.Text;

namespace Tschuuuuu_tschu
{
    [Serializable]
    public class Depot
    {
        //private Attribute
        private List<Zug> züge;

        //public get & set accesor via Properties
        public List<Zug> Züge { get { return züge; } set { züge = value; } }
        
        //Konstruktoren
        public Depot()
        {

        }
        public Depot(int i)
        {
            züge = new List<Zug>();
        }
        
        //public Methoden
        public void AddZug(Zug _zug)
        {
            züge.Add(_zug);
        }
        
    }
}
