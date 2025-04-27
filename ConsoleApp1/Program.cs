using System;
using System.IO;

namespace PracticalWotkI
{
    public class Program
    {
        //Main method. Entery point of the program
        public static void Main()
        {
            try
            {
                //The menu is started
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("||||||||||||||| Air UFV ||||||||||||||");
                Menu menu = new Menu();

                int option = menu.PrintOptions();

                //If the input of the user is out of the bounds, the program ends
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