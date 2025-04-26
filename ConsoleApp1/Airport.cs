using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace PracticalWotkI
{
    public class Menu
    {
        private List<Options> options;
        private Airport airport;
        

       public Menu()
       {
          this.airport = new Airport();
          this.options = new List<Options>();

          this.options.Add(new Load_File("Load flight from file"));
          this.options.Add(new Load_Manual("Load a flight manually"));
          this.options.Add(new Manual_Start("Start simulation (Manual)"));
          this.options.Add(new Atomatic_Start("Start simulation (Automatic)"));
       }

        public int Exit()
        {
            return this.options.Count + 1;
        }

        public int GetOptions()
        {
            return this.options.Count;
        }
       
        public int PrintOptions()
        {
            Console.WriteLine("--------------------------------------");

           for (int i = 1; i <= this.options.Count; i++)
           {
                Console.WriteLine($" {i}. {this.options[i - 1].GetName()}");
           }

           Console.WriteLine($" {this.Exit()}. Exit");
           Console.WriteLine("--------------------------------------");
           Console.WriteLine("||||||||||||||||||||||||||||||||||||||");
           Console.WriteLine("--------------------------------------");

           string? tmp = Console.ReadLine();
           if (tmp == "") return this.GetOptions() + 1;

           int option = int.Parse(tmp);

           return (option < 1 || option > this.GetOptions()) ? this.GetOptions() + 1: option;
        }

        public void Selection(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("Loading aircrafts from file");
                    break;
                case 2:
                    Runway runway;
                    int aircraftOption = airport.PrintAircrafts();

                    while (aircraftOption >= 1 && aircraftOption <= airport.GetAircrafts())
                    {
                        Console.Clear();
                        Console.WriteLine("Enter aircraft details:");

                        airport.AddAircraft(aircraftOption);

                        aircraftOption = airport.PrintAircrafts();
                    };
                    break;
                case 3:
                    TickSystem tickSystem = new TickSystem(airport);
                    tickSystem.Run();
                    break;
                case 4:
                    Console.WriteLine("Automatic start");
                    break;
            }
        }
    }
    public class Airport
    {
        public List<Aircraft> templates;
        public List<Aircraft> aircraft;
        public List<Runway> runways;
        public Airport()
        {
            this.templates = new List<Aircraft>();
            this.aircraft = new List<Aircraft>();

            this.templates.Add(new Commercial_Aircraft("Commercial Aircraft","", 5, 5, 5, 5, 5));
            this.templates.Add(new Cargo_Aircraft("Cargo Aircraft","", 5, 5, 5, 5, 5));
            this.templates.Add(new Private_Aircraft("Private Aircraft","", 5, 5, 5, 5, ""));

            this.runways = new List<Runway>();

            this.runways.Add(new Runway("Runway_1",Runway.RunwayStatus.Free,""));
            this.runways.Add(new Runway("Runway_2",Runway.RunwayStatus.Free,""));
            
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
        
        public int GetAircraftsCount()
        {
            return this.aircraft.Count;
        }

        public void AdvanceTick()
        {   
            foreach (var aircraft in this.aircraft)
            {
                if (aircraft.GetStatus() == Aircraft.Status.InFlight)
                {
                    aircraft.UpdateDistance();
                    aircraft.UpdateFuel();
                    
                    Console.WriteLine($"Aircraft: {aircraft.GetID()}");
                    Console.WriteLine($"Distance to airport: {aircraft.GetDistance()} km");
                    Console.WriteLine($"Current fuel: {aircraft.GetCurrentFuel()} L");
                }else if(aircraft.GetStatus() == Aircraft.Status.Waiting)
                {
                    aircraft.UpdateFuel();

                    Console.WriteLine($"Aircraft: {aircraft.GetID()}");
                    Console.WriteLine($"Distance to airport: 0 km");
                    Console.WriteLine($"Current fuel: {aircraft.GetCurrentFuel()} L");

                    foreach (var runway in this.runways)
                    {
                        if (runway.GetStatus() == Runway.RunwayStatus.Free)
                        {
                            runway.RequestRunway(aircraft.GetID());
                            break;
                        }
                    }

                }else if(aircraft.GetStatus() == Aircraft.Status.Landing)
                {
                    aircraft.UpdateFuel();
                    

                    Console.WriteLine($"Aircraft: {aircraft.GetID()}");
                    Console.WriteLine($"Distance to airport: 0 km");
                    Console.WriteLine($"Current fuel: {aircraft.GetCurrentFuel()} L");
                }
            }
            RemoveLandedAircraft();
        }

        public void ShowStatus()
        {
            foreach (var aircraft in this.aircraft)
            {
                Console.WriteLine($"Aircraft Status: {aircraft.GetStatus()}");
            }
            foreach (Runway runway in runways)
            {
                Console.WriteLine(runway.GetStatus());
            }
        }
        
    }
}
