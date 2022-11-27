using System;
using System.Collections.Generic;
using System.Text;

namespace Tschuuuuu_tschu
{
    [Serializable]
    class Motor : Zugteile 
    {
        private string typ;
        private int leistung;
        private int geschwindigkeit;

        public void SetTyp(string _typ)
        {
            typ = _typ;
        }

        public void SetLeistung(int _l)
        {
            leistung = _l;
        }

        public void SetGeschwindigkeit(int _g)
        {
            geschwindigkeit = _g;
        }
        public string GetTyp()
        {
            return typ;
        }
        public int GetLeistung()
        {
            return leistung;
        }
        public int GetGeschwindigkeit()
        {
            return geschwindigkeit;
        }
    }
}
