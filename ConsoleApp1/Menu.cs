using System;

namespace PracticalWotkI
{
    public class Menu
    {
        private List<Options> options;
        private Airport airport;

       public Menu()
       {
          this.airport = new Airport();
          this.options = new List<Options>();

          this.options.Add(new Load_File("Load flight from file"));
          this.options.Add(new Load_Manual("Load a flight manually"));
          this.options.Add(new Manual_Start("Start simulation (Manual)"));
          this.options.Add(new Atomatic_Start("Start simulation (Automatic)"));
       }

        public int Exit()
        {
            return this.options.Count + 1;
        }

        public int GetOptions()
        {
            return this.options.Count;
        }
       
        public int PrintOptions()
        {
            Console.WriteLine("--------------------------------------");

           for (int i = 1; i <= this.options.Count; i++)
           {
                Console.WriteLine($" {i}. {this.options[i - 1].GetName()}");
           }

           Console.WriteLine($" {this.Exit()}. Exit");
           Console.WriteLine("--------------------------------------");
           Console.WriteLine("||||||||||||||||||||||||||||||||||||||");
           Console.WriteLine("--------------------------------------");

           string? tmp = Console.ReadLine();
           if (tmp == "") return this.GetOptions() + 1;

           int option = int.Parse(tmp);

           return (option < 1 || option > this.GetOptions()) ? this.GetOptions() + 1: option;
        }

        public void Selection(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("Loading aircrafts from file");
                    break;
                case 2:
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
                case 4:
                    Console.WriteLine("Automatic start");
                    break;
            }
        }
    }
}
//prueba