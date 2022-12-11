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
        public Zugtyp()
        {

        }
        public Zugtyp(string zugtyp)
        {
            if (zugtyp == "Dampf")
            {
                string Dampf = @"                    _,-'`-._           _,-'```-._                 
                    `-.___,-'. .-.-.-. .`-.___,-'
      ====          --=========================--
      |  |            |]||[]|   [___]   |[]||[|
    >_|  |_-----------| ||  |   07802   |  || |-----------______<
  |_|    ==   ==___== | ||__| =   =   = |__|| | ==___==   ==    |_|
 >|_|-------__(-)-(-)__--|__|-----------|__|--__(-)-(-)__-------|_|<
[=|_|__| *_/__\_(o)_/__\__/_ \ |_|=|_| / _\__/__\_(o)_/__\_* | ||_|=]
   / (*)   \__/ ~~~ \__/  \__/   _=_   \__/  \__/ ~~~ \__/   (*) \
";
                sprite = Dampf;
                name = "Dampflock";
                zugtype = "Dampf";
            }
            if (zugtyp == "Diesel")
            {
                string Diesel = @"                                                        \  /
                  __                                     \/
     _   ---===##===---_________________________--------------  _
    [ ~~~=================###=###=###=###=###=================~~ ]
    /  ||  | |~\  ;;;;     PKP    ;;;  ET22-689  ;;;;  /~| |  ||  \
   /___||__| |  \ ;;;;            [_]            ;;;; /  | |__||___\
   [\        |__| ;;;;  ;;;; ;;;; ;;; ;;;; ;;;;  ;;;; |__|        /]
  (=|    ____[-]_______________________________________[-]____Kraq|=)
  /  /___/|#(__)=o########o=(__)#||___|#(__)=o#########o=(__)#|\___\
 _________-=\__/=--=\__/=--=\__/=-_____-=\__/=--=\__/=--=\__/=-______
";
                sprite = Diesel;
                name = "Diesellock";
                Zugtype = "Diesel";
            }
            if (zugtyp == "Elektro")
            {
                string Elektro = @"                                          __   __
                                          /'   `\
                                         Y.     .Y
                               _______    \`. .'/
                ,-------------'=======--```` - ````-- -.
           __,= +'-------------------------------------|p
      .-/ __ | _]_]  :`/:°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°|'
   ,-'__________[];/_;_____________________T G V_______|
 ,`.../_|______________________________________________|
(_ >        , -------.                     , -------.  |
 `-._____.`(_)`=`(_)\_7___7___7___7__7_.`(_)`=`(_)\_ /
";
                sprite = Elektro;
                name = "Elektrolock";
                Zugtype = "Elektro";
            }
        }
        public override void ShowAllStats()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Preis: {0}", Preis);
            Console.WriteLine("Zugtyp: {0}", Zugtype);
        }
    }
}
