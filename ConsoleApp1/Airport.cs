using System;
using System.IO;

namespace PracticalWotkI
{
    //Creation of the airport class.
    public class Airport
    {
        //Lists that airport will use.
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
                        if (runway.GetStatus() == Runway.RunwayStatus.Free && aircraft.GetStatus() == Aircraft.Status.Waiting)
                        {
                            runway.RequestRunway(aircraft.GetID());
                            aircraft.Land();
                        }
                    }

                }else if(aircraft.GetStatus() == Aircraft.Status.Landing)
                {
                    aircraft.UpdateFuel();
                    

                    Console.WriteLine($"Aircraft: {aircraft.GetID()}");
                    Console.WriteLine($"Distance to airport: 0 km");
                    Console.WriteLine($"Current fuel: {aircraft.GetCurrentFuel()} L");
                    foreach (var runway in this.runways)
                    {
                        runway.ReleaseRunway(aircraft);
                    }
        
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
            foreach (var runway in runways)
            {
                Console.WriteLine($"{runway.GetID()}: {runway.GetStatus()}");
            }
        }
        public void LoadFlightsFromFile()
        {
            Console.Write("Enter the file name: ");
            string fileName = Console.ReadLine();

            if (fileName == null)
            {
                Console.WriteLine("Invalid file name.");
                return;
            }

            try
            {
                
                var path = $"../../../{fileName}";
                
                if (!File.Exists(path))
                {
                    Console.WriteLine("File does not exist.");
                    return;
                }

                using (StreamReader sr = File.OpenText(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length < 6)
                        {
                            Console.WriteLine($"Invalid format in line: {line}");
                            continue;
                        }

                        string type = parts[0].Trim();
                        string id = parts[1].Trim();
                        int distance = int.Parse(parts[2].Trim());
                        double fuelCapacity = double.Parse(parts[3].Trim());
                        double fuelConsumption = double.Parse(parts[4].Trim());
                        double currentFuel = double.Parse(parts[5].Trim());

                        Aircraft newAircraft = null;

                        switch (type.ToLower())
                        {
                            case "commercial":
                                int passengers = int.Parse(parts[6].Trim());
                                newAircraft = new Commercial_Aircraft("Commercial Aircraft", id, distance, fuelCapacity, 
                                    fuelConsumption, currentFuel, passengers);
                                break;

                            case "cargo":
                                double maxLoad = double.Parse(parts[6].Trim());
                                newAircraft = new Cargo_Aircraft("Cargo Aircraft", id, distance, fuelCapacity, 
                                    fuelConsumption, currentFuel, maxLoad);
                                break;

                            case "private":
                                string owner = parts[6].Trim();
                                newAircraft = new Private_Aircraft("Private Aircraft", id, distance, fuelCapacity, 
                                    fuelConsumption, currentFuel, owner);
                                break;

                            default:
                                Console.WriteLine($"Unknown aircraft type in line: {line}");
                                continue;
                        }

                        if (newAircraft != null)
                        {
                            this.aircraft.Add(newAircraft);
                            Console.WriteLine($"Loaded aircraft: {newAircraft.GetName()} (ID: {newAircraft.GetID()})");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
        }
        
    }
}
