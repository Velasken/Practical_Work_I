using System;

namespace PracticalWotkI
{
    class Program
    {
        static void Main()
        {
            /*TickSystem tickSystem = new TickSystem();
            tickSystem.Run();*/
            Airport airport = new Airport();
            int airplanes = airport.PrintAircrafts();
        }
    }
}