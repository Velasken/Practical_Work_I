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
    }
}