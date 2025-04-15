using System;

//Como podemos asignarr pista??
//Como implementamos el tick?
//Luego lo implementamos aquí como ticksystem.Advancetick()



namespace PracticalWotkI
{
    public class Aircraft
    {
        protected string name;
        protected string id;
        protected int distance;
        protected double fuel_capacity;
        protected double fuel_consumption;
        protected double current_fuel;
        protected Status status;
        protected enum Status
        {
            InFlight,
            Waiting,
            Landing,
            OnGround
        }

        public Aircraft(string name, string id, int distance, double fuel_capacity, double fuel_consumption, double current_fuel)
        {
            this.name = name;
            this.id = id;
            this.distance = distance;
            this.fuel_capacity = fuel_capacity;
            this.fuel_consumption = fuel_consumption;
            this.current_fuel = current_fuel;
        }

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
        public virtual void NewAircraft()
        {

        }
    }
}
//prueba final