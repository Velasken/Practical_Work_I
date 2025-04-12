using System;

namespace PracticalWotkI
{
    public class Cargo_Aircraft : Aircraft
    {
        private double max_load;
        public Cargo_Aircraft(string name, string id, int distance, double fuel_capacity, double fuel_consumption, double current_fuel, double max_load) : base(name, id, distance, fuel_capacity, fuel_consumption, current_fuel)
        {
            this.max_load = max_load;
        }

        public double GetMaxLoad()
        {
            return this.max_load;
        }

        public override void NewAircraft()
        {
            Console.Write("Aircrafts ID: ");
            this.id = Console.ReadLine();
            Console.Write("Aircrafts Distance to the airport: ");
            this.distance = Int32.Parse(Console.ReadLine());
            Console.Write("Aircrafts fuel capacity: ");
            this.fuel_capacity = Double.Parse(Console.ReadLine());
            Console.Write("Aircrafts fuel consumption: ");
            this.fuel_consumption = Double.Parse(Console.ReadLine());
            this.current_fuel = this.fuel_capacity;
            Console.Write("Number of passengers: ");
            this.max_load = Double.Parse(Console.ReadLine());
        }
    }
}