using System;

//Luego lo implementamos aquí como ticksystem.Advancetick()

namespace PracticalWotkI
{
    public class Runway
    {
        private string id;
        private RunwayStatus status;

        private string CurrentAircraft;
        private int TicksAvailability = 3;

        private enum RunwayStatus
        {
            Free,
            Occupied
        }
        

        public Runway(string id)
        {
            this.id = id;
            this.status = RunwayStatus.Free;
            this.CurrentAircraft = "";

        }

        public void RequestRunway(String AircraftId)
        {
            do{
                if (this.status == 0)
                {
                    CurrentAircraft = AircraftId;
                }
            }while (CurrentAircraft == "");
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