using System;

namespace PracticalWotkI
{
    public class TickSystem : Airport
    {
        private Airport airport;

        public TickSystem(Airport airport)
        {
            this.airport = airport;
        }
        public void Run()
        {
            int tick = 0;
            bool running = true;
            Console.WriteLine("Press ENTER to continue or type 'exit' to end the program:");

            while (running)
            {
                if(tick == 0)
                {
                    Console.WriteLine("--- Begining ---");
                    string? input = Console.ReadLine();
                    if (airport.GetAircraftsCount() == 0)
                    {
                        Console.WriteLine("No aircrafts loaded");
                        running = false;
                    }
                    if (input.ToLower() == "exit")
                    {
                        running = false;
                    }
                }else
                {
                    Console.WriteLine("--- 15 minutes ---");
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
                tick++;
            }
        }
    }
}

