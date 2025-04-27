using System;
using System.IO;

namespace PracticalWotkI
{
    //Private_Aircraft class inherits from Aircraft
   public class Private_Aircraft : Aircraft
    {
        //Unique variable of this type of aircraft
        private string owner;

        //Constructor to initialize  this class
        public Private_Aircraft(string name, string id, int distance, double fuel_capacity, double fuel_consumption, double current_fuel, string owner) : base(name, id, distance, fuel_capacity, fuel_consumption, current_fuel)
        {
            this.owner = owner; //Initialize the unique variable
        }

        public string GetOwner()
        {
            return this.owner;
        }

        //Method to create a new private aircraft
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

            Console.Write("Name of the owner: ");
            this.owner = Console.ReadLine();
            if (this.owner == null)
            {
                Console.WriteLine("Name of the owner needed");
                Console.Write("Name of the owner: ");
                this.owner = Console.ReadLine();
            }
        }
    }
}