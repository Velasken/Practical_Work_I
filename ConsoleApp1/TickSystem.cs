using System;

namespace PracticalWotkI
{
    public class TickSystem
    {
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
                    Console.WriteLine("--- 15 minutes ---");
                    AdvanceTick();
                    ShowStatus();

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

