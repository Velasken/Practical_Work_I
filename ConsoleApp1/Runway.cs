using System;
using System.IO;

namespace PracticalWotkI
{
    //Creation of the class runway
    public class Runway 
    {
        protected string id;
        protected RunwayStatus statusrunway;

        protected string CurrentAircraft;
        protected int TicksAvailability;//number of ticks it will be available.

        //Different status of the runway.
        public enum RunwayStatus
        {
            Free,
            Occupied
        }
        

        public Runway(string id, RunwayStatus status,string CurrentAircraft)
        {
            //We give acces to the variables.
            this.id = id;
            this.statusrunway = RunwayStatus.Free;
            this.CurrentAircraft = CurrentAircraft;
            this.TicksAvailability = 3;
        }

        public void RequestRunway(string AircraftId)//Method to request a runway, and we call the aircraft id for the assignation of the runway.
        {
            if (this.statusrunway == RunwayStatus.Free)//We compare the status of the runway.
            {
                this.statusrunway = RunwayStatus.Occupied;//we change the status.
                this.CurrentAircraft = AircraftId;//Assignation of the aircraft.
                Console.WriteLine($"{this.id} assigned to aircraft {AircraftId}");//Prints the aircrafts that uses that runway.
                
            }
            else
            {
                Console.WriteLine($"{this.id} is not available.");//In case is not available we give a warning.
            }
            
        }

        public void ReleaseRunway(Aircraft aircraft)//A method for the runway release.
        {
            if(this.statusrunway == RunwayStatus.Occupied)
            {
                this.TicksAvailability --;//we decrese the tick counter of the runway.
            }
            if (this.TicksAvailability <= 0)
            {
                //We restart some variables.
                this.TicksAvailability = 3;
                this.CurrentAircraft = "";
                this.statusrunway = RunwayStatus.Free;

                aircraft.Ground();//Change the aircraft status.
            }
        }

        //Some getters for the variables.
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