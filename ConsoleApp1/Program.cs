using System;

namespace PracticalWotkI
{
    public class Program
    {
        public static void Main()
        {
            Airport airport = new Airport();

            int option = airport.PrintAircrafts();

            while (option >= 1 && option <= airport.GetAircrafts())
            {
                Console.Clear();
                Console.WriteLine("Enter aircraft details:");

                airport.AddAircraft(option);

                option = airport.PrintAircrafts();
            }
        }
    }
}