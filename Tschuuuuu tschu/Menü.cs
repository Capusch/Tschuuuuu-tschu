using System;
using System.Collections.Generic;
using System.Text;

namespace Tschuuuuu_tschu
{
    class Menü
    {
        private int index;
        private string[] auswahl;
        private string screen;

        public Menü(string screen_, string[] auswahl_)
        {
            auswahl = auswahl_;
            screen = screen_;
            index = 0;
        }


        private void ShowOptions()
        {
            Console.WriteLine(screen);
            for (int i = 0; i < auswahl.Length; i++)
            {
                string currentoption = auswahl[i];
                string prefix;
                if (i == index)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{prefix} << {currentoption} >>");
            }
            Console.ResetColor();
        }
        public int Run()
        {
            ConsoleKey PressedKey;
            do
            {
                Console.Clear();
                ShowOptions();
                ConsoleKeyInfo InfoKey = Console.ReadKey(true);
                PressedKey = InfoKey.Key;
                if (PressedKey == ConsoleKey.UpArrow)
                {
                    index--;
                    if (index == -1)
                    {
                        index = auswahl.Length - 1;
                    }
                }
                else if (PressedKey == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index == auswahl.Length)
                    {
                        index = 0;
                    }
                }
            } while (PressedKey != ConsoleKey.Enter);

            return index;
        }
    }
}