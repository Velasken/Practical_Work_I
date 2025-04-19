using System;

namespace PracticalWotkI
{
    public class Runway
    {
        protected string id;
        protected RunwayStatus status;

        protected string CurrentAircraft;
        protected int TicksAvailability = 3;

        public enum RunwayStatus
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

        public void RequestRunway(string AircraftId)
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

        public RunwayStatus GetStatus()
        {
            return this.status;
        }
    }
}