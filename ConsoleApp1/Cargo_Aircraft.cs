using System;
using System.IO;

namespace PracticalWotkI
{
    //Cargo_Aircraft class inherits from Aircraft
    public class Cargo_Aircraft : Aircraft
    {
        //Unique variable of this type of aircraft
        private double max_load;

        //Constructor to initialize  this class
        public Cargo_Aircraft(string name, string id, int distance, double fuel_capacity, double fuel_consumption, double current_fuel, double max_load) : base(name, id, distance, fuel_capacity, fuel_consumption, current_fuel)
        {
            this.max_load = max_load; //Initialize the unique variable
        }

        public double GetMaxLoad()
        {
            return this.max_load;
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
            
            Console.Write("Maximum load: ");
            this.max_load = Double.Parse(Console.ReadLine());
            if(this.max_load == 0)
            {
                Console.WriteLine("Maximum load needed");
                Console.Write("Maximum load: ");
                this.max_load = Double.Parse(Console.ReadLine());
            }
        }
    }
}