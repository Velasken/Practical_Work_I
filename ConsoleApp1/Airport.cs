using System;

namespace PracticalWotkI
{
    public class Airport
    {
        private List<Aircraft> templates;
        private List<Aircraft> aircraft;
        public Airport()
        {
            this.templates = new List<Aircraft>();
            this.aircraft = new List<Aircraft>();

            this.templates.Add(new Commercial_Aircraft("Commercial Aircraft","", 5, 5, 5, 5, 5));
            this.templates.Add(new Cargo_Aircraft("Cargo Aircraft","", 5, 5, 5, 5, 5));
            this.templates.Add(new Private_Aircraft("Private Aircraft","", 5, 5, 5, 5, ""));
        }

        public int GoBack()
        {
            return this.templates.Count + 1;
        }

        public int GetAircrafts()
        {
            return this.templates.Count;
        }

        public int PrintAircrafts()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("||||||||||||||| Air UFV ||||||||||||||");
            Console.WriteLine("--------------------------------------");

           for (int i = 1; i <= this.templates.Count; i++)
           {
                Console.WriteLine($" {i}. {this.templates[i - 1].GetName()}");
           }
           for (int i = 1; i <= this.aircraft.Count; i++)
           {
                Console.WriteLine($" {i}. {this.aircraft[i - 1].GetName()}");
           }

           Console.WriteLine($" {this.GoBack()}. Go Back");
           Console.WriteLine("--------------------------------------");
           Console.WriteLine("||||||||||||||||||||||||||||||||||||||");
           Console.WriteLine("--------------------------------------");

           string? tmp = Console.ReadLine();
           if (tmp == "") return this.GetAircrafts() + 1;

           int option = int.Parse(tmp);

           return (option < 1 || option > this.GetAircrafts()) ? this.GetAircrafts() + 1: option;
        }

        public void AddAircraft(int option)
        {
            Aircraft newAircraft = null; //we still don't know wich type of aircraft the user is going to sleect, so we declare the new aircraft as null

            if (option == 1)
            {
                newAircraft = new Commercial_Aircraft("Commercial Aircraft", "", 0, 0, 0, 0, 0);
            }
            else if (option == 2)
            {
                newAircraft = new Cargo_Aircraft("Cargo Aircraft", "", 0, 0, 0, 0, 0);
            }
            else if (option == 3)
            {
                newAircraft = new Private_Aircraft("Private Aircraft", "", 0, 0, 0, 0, "");
            }

            if (newAircraft != null)
            {
                newAircraft.NewAircraft();
                this.aircraft.Add(newAircraft);
                Console.WriteLine($"New aircraft added: {newAircraft.GetName()}");
                Console.Write("\n");
            }
        }
        public void RemoveLandedAircraft()
        {                
            for (int i = this.aircraft.Count - 1; i >= 0; i--)
            {                    
                Aircraft currentAircraft = this.aircraft[i];

                if (currentAircraft.GetStatus() == Aircraft.Status.OnGround)
                {
                    this.aircraft.RemoveAt(i);
                }
            }
        }

        public void AdvanceTick()
        {
            for (int i = 1; i <= this.aircraft.Count; i++)
           {
                Console.WriteLine($" {i}. {this.aircraft[i - 1].GetName()}");
           }
            
            foreach (var i in this.aircraft)
            {
                if (i.GetStatus() == Aircraft.Status.InFlight)
                {
                    i.UpdateDistance();
                    i.UpdateFuel();
                    Console.WriteLine(i.GetDistance());
                    Console.WriteLine(i.GetCurrentFuel());
                }
            }

            RemoveLandedAircraft();
        }

        public void ShowStatus()
        {
            foreach (var i in this.aircraft)
            {
                i.GetStatus();
            }
        }
        
    }
}
