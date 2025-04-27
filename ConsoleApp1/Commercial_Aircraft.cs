using System;
using System.IO;

namespace PracticalWotkI
{
    public class Commercial_Aircraft : Aircraft
    {
        private int passengers;
        public Commercial_Aircraft(string name, string id, int distance, double fuel_capacity, double fuel_consumption, double current_fuel, int passengers) : base(name, id, distance, fuel_capacity, fuel_consumption, current_fuel)
        {
            this.passengers = passengers;
        }
        public int GetPassengers()
        {
            return this.passengers;
        }

        public Status GetStatus()
        {
            return this.status;
        }

        public string GetID()
        {
            return this.id;
        }

        public int GetDistance()
        {
            return this.distance;
        }

        public double GetFUelCapacity()
        {
            return this.fuel_capacity;
        }

         public double GetFUelConsumption()
        {
            return this.fuel_consumption;
        }

         public double GetCurrentFuel()
        {
            return this.current_fuel;
        }

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