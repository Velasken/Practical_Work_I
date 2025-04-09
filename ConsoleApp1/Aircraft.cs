using System;

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
    }
}