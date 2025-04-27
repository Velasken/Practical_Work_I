using System;
using System.IO;

namespace PracticalWotkI
{
    //Creation of the class Menu.
    public class Menu
    {
        //Creation of a list of options.
        private List<Options> options;

        //Creation of the instance of the airport class.
        private Airport airport;
        
        //Initialization of the contructor menu.
       public Menu()
       {
        //Give access to the lists.
          this.airport = new Airport();
          this.options = new List<Options>();
        
          this.options.Add(new Load_File("Load flight from file"));
          this.options.Add(new Load_Manual("Load a flight manually"));
          this.options.Add(new Manual_Start("Start simulation (Manual)"));
          //Adding the options.
       }

        //A method to exit the menu.
        public int Exit()
        {
            return this.options.Count + 1;
        }

        //A method used to get the options.
        public int GetOptions()
        {
            return this.options.Count;
        }

       //A method to print the options.
        public int PrintOptions()
        {
            Console.WriteLine("--------------------------------------");

            //A loop to print the options.
           for (int i = 1; i <= this.options.Count; i++)
           {
                Console.WriteLine($" {i}. {this.options[i - 1].GetName()}");
           }

            //Prints the Exit option.
           Console.WriteLine($" {this.Exit()}. Exit");
           Console.WriteLine("--------------------------------------");
           Console.WriteLine("||||||||||||||||||||||||||||||||||||||");
           Console.WriteLine("--------------------------------------");

            //Reads the users selection.
           string? tmp = Console.ReadLine();
           if (tmp == "") return this.GetOptions() + 1;

           int option = int.Parse(tmp);

           return (option < 1 || option > this.GetOptions()) ? this.GetOptions() + 1: option;
        }
        
        //Depending on the user options one of the next cases executes.
        public void Selection(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("Loading aircrafts from file");
                    airport.LoadFlightsFromFile();
                    break;
                case 2:
                    Runway runway;
                    int aircraftOption = airport.PrintAircrafts();

                    while (aircraftOption >= 1 && aircraftOption <= airport.GetAircrafts())
                    {
                        Console.Clear();
                        Console.WriteLine("Enter aircraft details:");

                        airport.AddAircraft(aircraftOption);

                        aircraftOption = airport.PrintAircrafts();
                    };
                    break;
                case 3:
                    TickSystem tickSystem = new TickSystem(airport);
                    tickSystem.Run();
                    break;
            }
        }
    }
}