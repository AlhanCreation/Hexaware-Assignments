using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cars.entity
{
    public class Incidents
    {
        public int IncidentId { get; set; }
        public string? IncidentType { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Location { get; set; }
        public string? Description { get; set; }

        public string? Status { get; set; }

        public int VictimId { get; set; }

        public int SuspectId { get; set; }

        public Incidents() { }
        public Incidents(string incidentType, DateTime incidentDate, string location ,
                     string description, string status, int victimId, int suspectId)
        {
            
            IncidentType = incidentType;
            IncidentDate = incidentDate;
            Location = location;
            Description = description;
            Status = status;
            VictimId = victimId;
            SuspectId = suspectId;
        }

        public Incidents(int incidentId)
        {
            IncidentId = incidentId;
        }
        public Incidents(int incidentId, string incidentType, DateTime incidentDate, string location,
                     string description, string status, int victimId, int suspectId)
        {
            IncidentId = incidentId;
            IncidentType = incidentType;
            IncidentDate = incidentDate;
            Location = location;
            Description = description;
            Status = status;
            VictimId = victimId;
            SuspectId = suspectId;
        }
        public override string ToString()
        {
            return $"Incident ID: {IncidentId}\n" +
                   $"Type: {IncidentType}\n" +
                   $"Date: {IncidentDate.ToShortDateString()}\n" +
                   $"Location: {Location}\n" +
                   $"Description: {Description}\n" +
                   $"Status: {Status}\n" +
                   $"Victim ID: {VictimId}\n" +
                   $"Suspect ID: {SuspectId}\n" +
                   new string('-', 40);
        }
    }
   
}
