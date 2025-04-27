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
            //Adding new lists.
            this.templates = new List<Aircraft>();
            this.aircraft = new List<Aircraft>();

            //Adding plane options.
            this.templates.Add(new Commercial_Aircraft("Commercial Aircraft","", 5, 5, 5, 5, 5));
            this.templates.Add(new Cargo_Aircraft("Cargo Aircraft","", 5, 5, 5, 5, 5));
            this.templates.Add(new Private_Aircraft("Private Aircraft","", 5, 5, 5, 5, ""));

            //Creating the runway list.
            this.runways = new List<Runway>();

            //Creating the runways.
            this.runways.Add(new Runway("Runway_1",Runway.RunwayStatus.Free,""));
            this.runways.Add(new Runway("Runway_2",Runway.RunwayStatus.Free,""));
            
        }

        //Method to go back.
        public int GoBack()
        {
            return this.templates.Count + 1;
        }

        //Method to get aircraft.
        public int GetAircrafts()
        {
            return this.templates.Count;
        }

        //Method to print aircrafts.
        public int PrintAircrafts()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("||||||||||||||| Air UFV ||||||||||||||");
            Console.WriteLine("--------------------------------------");

            //Loop to print aircrafts.
           for (int i = 1; i <= this.templates.Count; i++)
           {
                Console.WriteLine($" {i}. {this.templates[i - 1].GetName()}");
           }

           Console.WriteLine($" {this.GoBack()}. Go Back");
           Console.WriteLine("--------------------------------------");
           Console.WriteLine("||||||||||||||||||||||||||||||||||||||");
           Console.WriteLine("--------------------------------------");

            //Reading the user option.
           string? tmp = Console.ReadLine();
           if (tmp == "") return this.GetAircrafts() + 1;

           int option = int.Parse(tmp);

           return (option < 1 || option > this.GetAircrafts()) ? this.GetAircrafts() + 1: option;
        }

        //Depending on the user input, the creation of the aircraft type starts.
        public void AddAircraft(int option)
        {
            Aircraft newAircraft = null; 
            
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

            //When the creeation is finished we add it to the list.
            if (newAircraft != null)
            {
                newAircraft.NewAircraft();
                this.aircraft.Add(newAircraft);
                Console.WriteLine($"New aircraft added: {newAircraft.GetName()}");
                Console.Write("\n");
            }
        }

        //Method to remove an aircraft.
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
        
        //Method to get the number of aircrafts.
        public int GetAircraftsCount()
        {
            return this.aircraft.Count;
        }

        //Method for the use of the tick system in the program.
        public void AdvanceTick()
        {   
            
            foreach (var aircraft in this.aircraft)//For every variable of the aircraft.
            {
                
                if (aircraft.GetStatus() == Aircraft.Status.InFlight) //comparation of the status.
                {
                    //We change the fuel and the distance.
                    aircraft.UpdateDistance();
                    aircraft.UpdateFuel();
                    
                    //We print the aircraft information.
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
                        //comparation of the runway and aircraft status.
                        {
                            runway.RequestRunway(aircraft.GetID());//Request of the runway for the aircradt.
                            aircraft.Land();//We change the status.
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
                        runway.ReleaseRunway(aircraft);//Release of the occupied runway.
                    }
        
                }
               
            }
            RemoveLandedAircraft();//Removes the aircraft.
        }

        //Method to show the status.
        public void ShowStatus()
        {
            foreach (var aircraft in this.aircraft)
            {
                Console.WriteLine($"Aircraft Status: {aircraft.GetStatus()}");//Prints the aircraft status.
            }
            foreach (var runway in runways)
            {
                Console.WriteLine($"{runway.GetID()}: {runway.GetStatus()}");//Prints the runway status.
            }
        }

        //Method to load aircrafts.
        public void LoadFlightsFromFile()
        {
            Console.Write("Enter the file name: ");//We ask the user for a file.
            string fileName = Console.ReadLine();//We read and save the file selected.

            if (fileName == null)//comprobation.
            {
                Console.WriteLine("Invalid file name.");//response in an invalid case
                return;
            }

            try
            {
                
                var path = $"../../../{fileName}";//File path.
                
                if (!File.Exists(path))//Comprobation of the existence of the file.
                {
                    Console.WriteLine("File does not exist.");//Answer in the case it doesn't.
                    return;
                }

                using (StreamReader sr = File.OpenText(path))//We read the file.
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)//We read every line of the file.
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length < 6)
                        {
                            Console.WriteLine($"Invalid format in line: {line}");
                            continue;
                        }//If the lines are less than six, the format is invalid.

                        //every part of the file, we associate it to a variable of the aircraft.
                        string type = parts[0].Trim();
                        string id = parts[1].Trim();
                        int distance = int.Parse(parts[2].Trim());
                        double fuelCapacity = double.Parse(parts[3].Trim());
                        double fuelConsumption = double.Parse(parts[4].Trim());
                        double currentFuel = double.Parse(parts[5].Trim());

                        Aircraft newAircraft = null;

                        switch (type.ToLower())//depending on the aircraft type the sixth data is different.
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
                        }//Adds the aircrafts to the list.
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }//Exception to avoid errors.
        }
        
    }
}
