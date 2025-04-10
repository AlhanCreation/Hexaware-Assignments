using cars.dao;
using cars.entity;
using Microsoft.Identity.Client;
using NUnit.Framework;
using NUnit.Framework.Legacy;


namespace CarsTest.test
{   
    public class Tests
    {   
        ICrimeAnalysisService service;
        Incidents incident;
        [SetUp]
        public void Setup()
        {   
            service = new CrimeAnalysisServiceImp();
        }

        [Test]
        public void Test1()
        {

            incident = new Incidents()
            {

                IncidentType = "Theft",
                Location = "New York",
                Description = "Stolen car",
                IncidentDate = DateTime.Now,
                SuspectId = 1,
                VictimId = 1,

            };

            bool result = service.CreateIncident(incident);

            Assert.Equals(result, true);
        }

        
        [TestCase(3, "Resolved")]
        [TestCase(4, "Open")]
        public void Test2(int incidentId, string status)
        {
            bool result = service.UpdateIncidentStatus(status, incidentId);
            Assert.That(result, Is.True); 
        }



    }
}