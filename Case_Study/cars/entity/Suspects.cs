using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cars.entity
{
   
    public class Suspects
    {
        public int SuspectID { get; set; }
        public string  FirstName {get;set;}
        public string  LastName { get; set; }
        public DateTime DateOfBirth {  get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public Suspects() { }
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
        public override string ToString()
        {
            return $"SuspectID: {SuspectID} \n, Name: {FirstName} {LastName}\n, DateOfBirth: {DateOfBirth:yyyy-MM-dd}\n, Gender: {Gender}\n, Address: {Address}\n, PhoneNumber: {PhoneNumber}\n"+new string('_',50);
        }

       
    }
}
