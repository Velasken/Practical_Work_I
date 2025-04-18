using System;


namespace PracticalWotkI
{
    public class TickSystem
    {
        private Airport airport;

        public TickSystem()
        {
            airport = new Airport();
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
                    if (input.ToLower() == "exit")
                    {
                        running = false;
                    }
                }else
                {
                    airport.AdvanceTick();

                    Console.WriteLine("--- 15 minutes ---");
                    airport.ShowStatus();

                    string? input = Console.ReadLine();
                    if (input.ToLower() == "exit")
                    {
                        running = false;
                    }
                }
                tick++;
            }
        }
    }
}

