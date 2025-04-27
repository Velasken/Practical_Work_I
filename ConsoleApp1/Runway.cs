using System;
using System.IO;

namespace PracticalWotkI
{
    public class Runway 
    {
        protected string id;
        protected RunwayStatus statusrunway;

        protected string CurrentAircraft;
        protected int TicksAvailability;

        public enum RunwayStatus
        {
            Free,
            Occupied
        }
        

        public Runway(string id, RunwayStatus status,string CurrentAircraft)
        {
            this.id = id;
            this.statusrunway = RunwayStatus.Free;
            this.CurrentAircraft = CurrentAircraft;
            this.TicksAvailability = 3;
        }

        public void RequestRunway(string AircraftId)
        {
            if (this.statusrunway == RunwayStatus.Free)
            {
                this.statusrunway = RunwayStatus.Occupied;
                this.CurrentAircraft = AircraftId;
                Console.WriteLine($"{this.id} assigned to aircraft {AircraftId}");
                
            }
            else
            {
                Console.WriteLine($"{this.id} is not available.");
            }
            
        }

        public void ReleaseRunway(Aircraft aircraft)
        {
            if(this.statusrunway == RunwayStatus.Occupied)
            {
                this.TicksAvailability --;
            }
            if (this.TicksAvailability <= 0)
            {

                this.TicksAvailability = 3;
                this.CurrentAircraft = "";
                this.statusrunway = RunwayStatus.Free;
                aircraft.Ground();
            }
        }

        public string GetID()
        {
            return this.id;
        }

        public RunwayStatus GetStatus()
        {
            return this.statusrunway;
        }
    }
}