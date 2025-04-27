using System;
using System.IO;

namespace PracticalWotkI
{
    //Creating the class Ticksystem.
    public class TickSystem : Airport
    {
        private Airport airport;

        //Initialize TickSystem with a given Airport
        public TickSystem(Airport airport)
        {
            this.airport = airport;
        }

        //Method to the run the tick system
        public void Run()
        {
            int tick = 0; //Counter of ticks
            bool running = true; //boolean variable which will make the simulation run 

            Console.WriteLine("Press ENTER to continue or type 'exit' to end the program:");

            //Simulation loop
            while (running)
            {
                //Beginning of the simulation
                if(tick == 0)
                {
                    Console.WriteLine("--- Begining ---");

                    //Read users input
                    string? input = Console.ReadLine();

                    //If there were no aircrafts loaded to the list, the simulation ends 
                    if (airport.GetAircraftsCount() == 0)
                    {
                        Console.WriteLine("No aircrafts loaded");
                        running = false;
                    }

                    //If the user types exit, the simulation ends
                    if (input.ToLower() == "exit")
                    {
                        running = false;
                    }

                //If there were aircrafts loaded and the useer didn't type exit, the simulation keep on going
                }else
                {

                    //Time passed
                    Console.WriteLine("--- 15 minutes ---");

                    //If all the aircrafts are on ground, the simulation ends
                    if (airport.GetAircraftsCount() == 0)
                    {
                        Console.WriteLine("No more aircrafts left in the simulation");
                        running = false;
                    }else 
                    {
                        airport.AdvanceTick();
                        airport.ShowStatus();

                        string? input = Console.ReadLine();
                        if (input.ToLower() == "exit")
                        {
                            running = false;
                        }
                    }
                }
                tick++; //Increment tick
            }
        }
    }
}

