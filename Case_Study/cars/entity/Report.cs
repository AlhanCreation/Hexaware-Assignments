using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cars.entity
{
    public class Report
    {
        public int ReportId{ get; set; }
        public int IncidentId { get; set; }
        public int ReportingOfficerId { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportDetails { get; set; }
        public string Status { get; set; }

        public Report() { } 
        public Report(int reportID, int incidentID, int reportingOfficerID, DateTime reportDate,
                      string reportDetails, string status)
        {
            ReportId = reportID;
            IncidentId = incidentID;
            ReportingOfficerId = reportingOfficerID;
            ReportDate = reportDate;
            ReportDetails = reportDetails;
            Status = status;
        }
        public override string ToString()
        {
            return $"Report ID: {ReportId}\n" +
                   $"Incident ID: {IncidentId}\n" +
                   $"Reporting Officer ID: {ReportingOfficerId}\n" +
                   $"Report Date: {ReportDate.ToString("yyyy-MM-dd")}\n" +
                   $"Report Details: {ReportDetails}\n" +
                   $"Status: {Status}";
        }
    }

}
