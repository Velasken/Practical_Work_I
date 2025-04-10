using System;


//Como podemos implementar??
//Aquí ponemos lo que hace el Advance.Tick

namespace PracticalWotkI
{
    public class TickSystem
    {
        public void Advancetick()
        {
            
        }
        public void Run()
        {
            int tick = 1;
            bool running = true;
            Console.WriteLine("Press ENTER to continue or type 'exit' to end the program:");

            while (running)
            {
                if(tick == 1)
                {
                    Console.WriteLine("--- Begining ---");

                    string? input = Console.ReadLine();
                    if (input.ToLower() == "exit")
                    {
                        running = false;
                    }
                }else
                {
                    Advancetick();

                    Console.WriteLine("--- 15 minutes ---");

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

