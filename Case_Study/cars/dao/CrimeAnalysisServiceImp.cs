using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cars.entity;
using cars.util;
using System.Data.SqlClient;
using System.Runtime.InteropServices.Marshalling;
using cars.exception;

namespace cars.dao
{
    public class CrimeAnalysisServiceImp : ICrimeAnalysisService
    {
        SqlDataReader dataReader = null;


         bool ICrimeAnalysisService.CreateIncident(Incidents incidents)
        {

            try
            {
                // SQL query to insert incident data
                string query = "INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID) " +
                               "VALUES ( @IncidentType, @IncidentDate, @Location, @Description, @Status, @VictimID, @SuspectID)";

                // Establish connection (outside the 'using' block)
              SqlConnection  conn = DBConnUtil.GetSqlConnection();

                // Create SqlCommand object
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@IncidentType", incidents.IncidentType);
                    cmd.Parameters.AddWithValue("@IncidentDate", incidents.IncidentDate);
                    cmd.Parameters.AddWithValue("@Location", incidents.Location);
                    cmd.Parameters.AddWithValue("@Description", incidents.Description);
                    cmd.Parameters.AddWithValue("@Status", incidents.Status);
                    cmd.Parameters.AddWithValue("@VictimID", incidents.VictimId);
                    cmd.Parameters.AddWithValue("@SuspectID", incidents.SuspectId);

                  
                

                    // Execute the SQL command
                    int result = cmd.ExecuteNonQuery();
                 
                    // Check if the record was successfully inserted
                    if (result > 0)
                    {
                        Console.WriteLine("Incident added successfully.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Failed to insert the incident.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Include full exception information
                throw new Exception("Error occurred during CreateIncident: " + ex.Message);
            }

    }
         
     

      bool ICrimeAnalysisService.UpdateIncidentStatus(string status, int incidentId)
    {
        try
        {
            string query = "UPDATE Incidents SET Status = @status WHERE IncidentID = @incidentId";
            SqlConnection conn = DBConnUtil.GetSqlConnection();

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@incidentId", incidentId);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine("Incident updated to status: *{0}* for IncidentId: *{1}*", status, incidentId);
                    return true;
                }
                else
                {
                        throw new IncidentNumberNotFoundException($"Incident with ID {incidentId} not found.");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred during UpdateIncidentStatus: " + ex.Message);
        }
    }

    List<Incidents> ICrimeAnalysisService.GetIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            List<Incidents> incident = new List<Incidents>();

            using (SqlConnection connection = DBConnUtil.GetSqlConnection())
            {
                string query = @"SELECT * FROM Incidents 
                             WHERE IncidentDate BETWEEN @StartDate AND @EndDate";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            incident.Add(new Incidents
                            {
                                IncidentId = reader.GetInt32(0),
                                IncidentType = reader.GetString(1),
                                IncidentDate = reader.GetDateTime(2),
                                Location = reader.GetString(3),
                                Description = reader.GetString(4),
                                Status = reader.GetString(5),
                                VictimId = reader.GetInt32(6),
                                SuspectId = reader.GetInt32(7)
                            });
                        }
                    }
                }
            }

            return incident;
        }
    
        List<Incidents> ICrimeAnalysisService.SearchIncidents(string incidentTypeCriteria)
        {
            try
            {
                List<Incidents> ListOfIncidents = new List<Incidents>();
                using (SqlConnection conn = DBConnUtil.GetSqlConnection())
                {
                    string query = @"SELECT * FROM Incidents WHERE IncidentType = @incidentTypeCriteria";

                    using (SqlCommand cmd = new SqlCommand(query, conn)) { 
                        cmd.Parameters.AddWithValue("@incidentTypeCriteria", incidentTypeCriteria);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            ListOfIncidents.Add(new Incidents {
                                IncidentId = (int)reader["IncidentID"],
                                IncidentType =(string) reader["IncidentType"],
                                IncidentDate = (DateTime)reader["IncidentDate"],
                                Location = (string)reader["Location"],
                                Description = (string)reader["Description"],
                                Status = (string)reader["Status"],
                                VictimId = (int)reader["VictimId"],
                                SuspectId = (int)reader["SuspectId"]

                            });
                        }
                    }
                }
                return ListOfIncidents;
            } 
            catch (Exception ex)
            { throw new Exception("Error in IncidentType" + ex.Message); }

           
        }
        
        Report ICrimeAnalysisService.GenerateIncidentReport(Incidents incident)
        {
           
            using (SqlConnection conn = DBConnUtil.GetSqlConnection())
            {
                
                string query = @"
                SELECT *  FROM  Reports
                WHERE 
                    IncidentID = @IncidentID
                ORDER BY 
                    ReportDate DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IncidentId",incident.IncidentId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Report report = null;
                    while (reader.Read())
                    {
                        report = new Report
                        {
                            ReportId = (int)reader["ReportID"],
                            IncidentId = (int)reader["IncidentID"],
                            ReportingOfficerId = (int)reader["ReportingOfficerID"],
                            ReportDate = (DateTime)reader["ReportDate"],
                            ReportDetails = (string)reader["ReportDetails"],
                            Status = (string)reader["Status"]
                        };
                    }
                    return report;



                }
            }
            
        }
    }


}
