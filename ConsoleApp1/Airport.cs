using System;

//Luego lo implementamos aquí como ticksystem.Advancetick()


namespace PracticalWotkI
{
    public class Airport
    {
        private List<Aircraft> aircraft = new List<Aircraft>();
        public Airport()
        {
            this.aircraft = new List<Aircraft>();

            this.aircraft.Add(new Commercial_Aircraft("Commercial Aircraft", 5, 5, 5, 5, 5));
            this.aircraft.Add(new Cargo_Aircraft("Cargo Aircraft", 5, 5, 5, 5, 5));
            this.aircraft.Add(new Private_Aircraft("Private Aircraft", 5, 5, 5, 5, "José"));
        }

        public int PrintAircrafts()
        {
            for (int i = 1; i <= this.aircraft.Count; i++)
           {
                Console.WriteLine($" {i}. {this.aircraft[i - 1].GetID()}");
           }
           return 0;
        }
    }
}