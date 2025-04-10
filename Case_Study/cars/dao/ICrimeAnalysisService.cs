using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cars.entity;
using System.Collections.Generic;

namespace cars.dao
{
    public interface ICrimeAnalysisService
    {
        // Create a new incident
       public bool CreateIncident(Incidents incident);

       // Update the status of an incident
        bool UpdateIncidentStatus(string status, int incidentID);

        // Get a list of incidents within a date range
        List<Incidents> GetIncidentsInDateRange(DateTime startDate, DateTime endDate);


        // Search for incidents based on various criteria
        List<Incidents> SearchIncidents(string incidentTypeCriteria);

        // Generate incident reports
        Report GenerateIncidentReport(Incidents incident);

        // Create a new case and associate it with incidents
        //Cas CreateCase(string caseDescription, ICollection<Incidents> incidents);

        //// Get details of a specific case
        //Case GetCaseDetails(int caseId);

        //// Update case details
        //bool UpdateCaseDetails(Case caseDetails);

        //// Get a list of all cases
        //ICollection<Case> GetAllCases();
    }
}
