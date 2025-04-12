using System;

//Luego lo implementamos aquí como ticksystem.Advancetick()


namespace PracticalWotkI
{
    public class Airport
    {
        private List<Aircraft> aircraft;
        public Airport()
        {
            this.aircraft = new List<Aircraft>();

            this.aircraft.Add(new Commercial_Aircraft("Commercial Aircraft", 5, 5, 5, 5, 5));
            this.aircraft.Add(new Cargo_Aircraft("Cargo Aircraft", 5, 5, 5, 5, 5));
            this.aircraft.Add(new Private_Aircraft("Private Aircraft", 5, 5, 5, 5, ""));
        }

         public int Exit()
        {
            return this.aircraft.Count + 1;
        }

        public int GetAircrafts()
        {
            return this.aircraft.Count;
        }

        public int PrintAircrafts()
        {
            Console.WriteLine("--------------------------------------");

           for (int i = 1; i <= this.aircraft.Count; i++)
           {
                Console.WriteLine($" {i}. {this.aircraft[i - 1].GetID()}");
           }

           Console.WriteLine($" {this.Exit()}. Exit");
           Console.WriteLine("--------------------------------------");

           string? tmp = Console.ReadLine();
           if (tmp == "") return this.GetAircrafts() + 1;

           int option = int.Parse(tmp);

           return (option < 1 || option > this.GetAircrafts()) ? this.GetAircrafts() + 1: option;
        }

        public void AddAircraft(int option)
        {
            
        }
    }
}