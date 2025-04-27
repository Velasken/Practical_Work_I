using System;
using System.IO;

namespace PracticalWotkI
{
    //Creating the class aricraft.
    public class Aircraft
    {
        //Delaring the variables.
        protected string name;
        protected string id;
        protected int distance;
        protected double fuel_capacity;
        protected double fuel_consumption;
        protected double current_fuel;
        protected Status status;
        public enum Status
        {
            //Types of status of the aircraft.
            InFlight,
            Waiting,
            Landing,
            OnGround
        }

        public Aircraft(string name, string id, int distance, double fuel_capacity, double fuel_consumption, double current_fuel)
        {
            //We give acces to the variables to edit them.
            this.name = name;
            this.id = id;
            this.distance = distance;
            this.fuel_capacity = fuel_capacity;
            this.fuel_consumption = fuel_consumption;
            this.current_fuel = current_fuel;
            this.status = Status.InFlight; 
        }
        //Some getters to access the variables that we need.
        public string GetName()
        {
            return this.name;
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
        public Status GetStatus()
        {
            return this.status;
        }
        //Method used to update the distance of the airplane.
        public void UpdateDistance()
        {
            if (this.distance > 0)
            {
                this.distance -= 215; //15 mins de vuelo
                if (this.distance <= 0)
                {
                    this.distance = 0;
                    this.status = Status.Waiting;
                }
            }
        }
        //Method used to update the fuel of the airplane.
        public void UpdateFuel()
        {
            this.current_fuel -= this.fuel_consumption; //15 mins
            if (this.current_fuel <= 0)
            {
                this.current_fuel = 0;
                this.status = Status.OnGround; // Aterrizaje forzado
            }
        }
        //Two methods made to update the status of the aircraft.
        public void Land()
        {
            this.status = Status.Landing;
        }
        public void Ground()
        {
            this.status = Status.OnGround;
        }
        
        public virtual void NewAircraft()
        {

        }
    }
}