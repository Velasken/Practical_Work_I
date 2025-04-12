using System;

namespace PracticalWotkI
{
   public class Private_Aircraft : Aircraft
    {
        private string owner;
        public Private_Aircraft(string name, string id, int distance, double fuel_capacity, double fuel_consumption, double current_fuel, string owner) : base(name, id, distance, fuel_capacity, fuel_consumption, current_fuel)
        {
            this.owner = owner;
        }

        public string GetOwner()
        {
            return this.owner;
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
            Console.Write("Name of the owner: ");
            this.owner = Console.ReadLine();
        }
    }
}