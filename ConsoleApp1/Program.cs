using System;
//Add a method to get out ones I uploded the info
namespace PracticalWotkI
{
    class Program
    {
        static void Main()
        {
            /*TickSystem tickSystem = new TickSystem();
            tickSystem.Run();*/
            Airport airport = new Airport();

            int option = airport.PrintAircrafts();

            while (option >= 1 && option <= airport.GetAircrafts())
            {
                Console.Clear();
                Console.WriteLine("Enter aircraft details to update:");

                airport.AddAircraft(option);

                option = airport.PrintAircrafts();
            }
            Console.WriteLine("Exited.");
        }
    }
}