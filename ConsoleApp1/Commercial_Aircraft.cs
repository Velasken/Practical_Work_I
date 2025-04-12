using System;

namespace PracticalWotkI
{
    public class Commercial_Aircraft : Aircraft
    {
        private int passengers;
        public Commercial_Aircraft(string id, int distance, double fuel_capacity, double fuel_consumption, double current_fuel, int passengers) : base(id, distance, fuel_capacity, fuel_consumption, current_fuel)
        {
            this.passengers = passengers;
        }

        public void SetID(string newid)
        {
            this.id = newid;
        }
        public int GetPassengers()
        {
            return this.passengers;
        }
    }
}