using System;

//Como podemos asignarr pista??
//Como implementamos el tick?

namespace PracticalWotkI
{
    public class Aircraft
    {
        protected string id;
        protected int distance;
        protected double fuel_capacity;
        protected double fuel_consumption;
        protected double current_fuel;

        public Aircraft(string id, int distance, double fuel_capacity, double fuel_consumption, double current_fuel)
        {
            this.id = id;
            this.distance = distance;
            this.fuel_capacity = fuel_capacity;
            this.fuel_consumption = fuel_consumption;
            this.current_fuel = current_fuel;
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

        public void PrintDistance(int distance)
        {
            if(distance > 0)
            {
                Console.Clear();
                Console.WriteLine($"{this.id} in flight {this.distance} km");
                Console.ReadLine();
            }else if (distance == 0)
            {

            }
        }
    }

    public class Commercial_Aircraft : Aircraft
    {
        private int passengers;
        public Commercial_Aircraft(string id, int distance, double fuel_capacity, double fuel_consumption, double current_fuel, int passengers) : base(id, distance, fuel_capacity, fuel_consumption, current_fuel)
        {
            this.passengers = passengers;
        }

        public int GetPassengers()
        {
            return this.passengers;
        }
    }

    public class Cargo_Aircraft : Aircraft
    {
        private double max_load;
        public Cargo_Aircraft(string id, int distance, double fuel_capacity, double fuel_consumption, double current_fuel, double max_load) : base(id, distance, fuel_capacity, fuel_consumption, current_fuel)
        {
            this.max_load = max_load;
        }

        public double GetMaxLoad()
        {
            return this.max_load;
        }
    }

    public class Private_Aircraft : Aircraft
    {
        private string owner;
        public Private_Aircraft(string id, int distance, double fuel_capacity, double fuel_consumption, double current_fuel, string owner) : base(id, distance, fuel_capacity, fuel_consumption, current_fuel)
        {
            this.owner = owner;
        }

        public string GetOwner()
        {
            return this.owner;
        }
    }
}