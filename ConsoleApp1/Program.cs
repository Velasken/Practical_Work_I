using System;
using System.IO;

namespace PracticalWotkI
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("||||||||||||||| Air UFV ||||||||||||||");
                Menu menu = new Menu();

                int option = menu.PrintOptions();

                while (option >= 1 && option <= menu.GetOptions())
                {
                    Console.Clear();
                    menu.Selection(option);
                    Console.Write("\n");

                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("||||||||||||||| Air UFV ||||||||||||||");
                    option = menu.PrintOptions();
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Wrong type of input");
            }
            catch(OverflowException)
            {
                Console.WriteLine("This number is to large");
            }
        }
    }
}