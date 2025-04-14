using System;

//Luego lo implementamos aquí como ticksystem.Advancetick()

namespace PracticalWotkI
{
    public class Runway
    {
        private string id;
        private RunwayStatus status;

        private enum RunwayStatus
        {
            Free,
            Occupied
        }
        

        public Runway(string id)
        {
            this.id = id;
            this.status = RunwayStatus.Free;
        }

        public string GetID()
        {
            return this.id;
        }

        public string GetStatus()
        {
            return this.status.ToString();
        }
    }
}