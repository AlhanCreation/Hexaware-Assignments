using System;
using System.Collections.Generic;
using cars.entity;
using cars.dao;

namespace cars.main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICrimeAnalysisService service = new CrimeAnalysisServiceImp();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== Crime Analysis System ===");
                Console.WriteLine("1. Create Incident");
                Console.WriteLine("2. Update Incident Status");
                Console.WriteLine("3. Get Incidents in Date Range");
                Console.WriteLine("4. Search Incidents by Type");
                Console.WriteLine("5. Generate Incident Report");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice (1-6): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateIncident(service);
                            break;
                        case 2:
                            UpdateIncidentStatus(service);
                            break;
                        case 3:
                            GetIncidentsInDateRange(service);
                            break;
                        case 4:
                            SearchIncidentsByType(service);
                            break;
                        case 5:
                            GenerateIncidentReport(service);
                            break;
                        case 6:
                            exit = true;
                            Console.WriteLine("Exiting the application...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void CreateIncident(ICrimeAnalysisService service)
        {
            Console.WriteLine("\n=== Create New Incident ===");

            Console.Write("Enter Incident Type: ");
            string incidentType = Console.ReadLine();

            Console.Write("Enter Location: ");
            string location = Console.ReadLine();

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Status (Open/Closed): ");
            string status = Console.ReadLine();

            Console.Write("Enter Victim ID: ");
            int victimId = int.Parse(Console.ReadLine());

            Console.Write("Enter Suspect ID: ");
            int suspectId = int.Parse(Console.ReadLine());

            Incidents incident = new Incidents(incidentType, DateTime.Now, location, description, status, victimId, suspectId);
            bool success = service.CreateIncident(incident);

            
        }

        static void UpdateIncidentStatus(ICrimeAnalysisService service)
        {
            Console.WriteLine("\n=== Update Incident Status ===");

            Console.Write("Enter Incident ID: ");
            int incidentId = int.Parse(Console.ReadLine());

            Console.Write("Enter New Status: ");
            string status = Console.ReadLine();

            bool success = service.UpdateIncidentStatus(status, incidentId);

            
        }

        static void GetIncidentsInDateRange(ICrimeAnalysisService service)
        {
            Console.WriteLine("\n=== Get Incidents in Date Range ===");

            Console.Write("Enter start date (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter end date (yyyy-MM-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            List<Incidents> incidents = service.GetIncidentsInDateRange(startDate, endDate);

            Console.WriteLine("\nIncidents found:");
            Console.WriteLine(new string('-', 50));

            foreach (var incident in incidents)
            {
                Console.WriteLine(incident);
            }
        }

        static void SearchIncidentsByType(ICrimeAnalysisService service)
        {
            Console.WriteLine("\n=== Search Incidents by Type ===");

            Console.Write("Enter Incident Type to search: ");
            string incidentType = Console.ReadLine();

            List<Incidents> incidents = service.SearchIncidents(incidentType);

            Console.WriteLine("\nIncidents found:");
            Console.WriteLine(new string('-', 50));

            foreach (var incident in incidents)
            {
                Console.WriteLine(incident);
            }
        }

        static void GenerateIncidentReport(ICrimeAnalysisService service)
        {
            Console.WriteLine("\n=== Generate Incident Report ===");

            Console.Write("Enter Incident ID: ");
            int incidentId = int.Parse(Console.ReadLine());

            Incidents incident = new Incidents { IncidentId = incidentId };
            Report report = service.GenerateIncidentReport(incident);

            if (report != null)
            {
                Console.WriteLine("\n=== Incident Report ===");
                Console.WriteLine(report);
            }
            else
            {
                Console.WriteLine("No report found for the given incident ID.");
            }
        }
    }
}