using System;
using System.IO;

namespace PracticalWotkI
{
    //Commercial_Aircraft class inherits from Aircraft
    public class Commercial_Aircraft : Aircraft
    {
        //Unique variable of this type of aircraft
        private int passengers;

        //Constructor to initialize  this class
        public Commercial_Aircraft(string name, string id, int distance, double fuel_capacity, double fuel_consumption, double current_fuel, int passengers) : base(name, id, distance, fuel_capacity, fuel_consumption, current_fuel)
        {
            this.passengers = passengers; //Initialize the unique variable
        }
        public int GetPassengers()
        {
            return this.passengers;
        }

        //Method to create a new commercial aircraft
        public override void NewAircraft()
        {
            Console.Write("Aircrafts ID: ");
            this.id = Console.ReadLine();
            if (this.id == "")
            {
               Console.WriteLine("ID needed");
               Console.Write("Aircrafts ID: ");
               this.id = Console.ReadLine(); 
            }

            Console.Write("Aircrafts Distance to the airport: ");
            this.distance = Int32.Parse(Console.ReadLine());
            if (this.distance <= 0)
            {
                Console.Write("Distance can't be 0\n");
                Console.Write("Aircrafts Distance to the airport: ");
                this.distance = Int32.Parse(Console.ReadLine());
            }

            Console.Write("Aircrafts fuel capacity: ");
            this.fuel_capacity = Double.Parse(Console.ReadLine());

            Console.Write("Aircrafts fuel consumption: ");
            this.fuel_consumption = Double.Parse(Console.ReadLine());

            this.current_fuel = this.fuel_capacity;

            Console.Write("Number of passengers: ");
            this.passengers = Int32.Parse(Console.ReadLine());
            if (this.passengers == 0)
            {
                Console.WriteLine("Number of passengers is needed");
                Console.Write("Number of passengers: ");
                this.passengers = Int32.Parse(Console.ReadLine());
            }
        }
    }
}