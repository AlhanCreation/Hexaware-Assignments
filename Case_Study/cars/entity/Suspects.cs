using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cars.entity
{
    internal class Suspects
    {
        public int SuspectID { get; set; }
        public string  FirstName {get;set;}
        public string  LastName { get; set; }
        public DateTime DateOfBirth {  get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public Suspects(int suspectId, string firstName, string lastName, DateTime dateOfBirth, string gender, string address, string phoneNumber)
        {

            SuspectID = suspectId;
            FirstName = firstName;
            LastName = lastName;
            DateTime DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            PhoneNumber = phoneNumber;

        }
       
    }
}
