using System;
using System.IO;

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
        

        public Runway(string id, RunwayStatus status,string CurrentAircraft)
        {
            this.id = id;
            this.status = RunwayStatus.Free;
            this.CurrentAircraft = CurrentAircraft;

        }
        string[,] runways = {
                {"Runway_1","Free",""},
                {"Runway_2","Free",""}
            };

        public void RequestRunway(string AircraftId)
        {
            
            for(int i = 0; i<=1; i++)
            {
                if(runways[i,1] == "Free")
                {
                    runways[i,1] = "Occupied";
                    runways[i,2] = AircraftId;
                    i=2;
                }
                
                
            }
            
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