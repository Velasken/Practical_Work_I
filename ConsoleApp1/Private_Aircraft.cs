using System;

namespace PracticalWotkI
{
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