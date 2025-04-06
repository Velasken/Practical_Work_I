using System;

namespace PracticalWotkI
{
    public class TickSystem
    {
        public void Run()
        {
            int tick = 1;
            bool running = true;
            Console.WriteLine("Presiona ENTER para continuar o escribe 'salir' para terminar:");

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

