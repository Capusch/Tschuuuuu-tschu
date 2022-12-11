using System;
using System.IO;


namespace Tschuuuuu_tschu
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var TTSimulator = new Simulator();
            TTSimulator.BahnhofKarte();
            
            TTSimulator.Start();
        }
    }
}
