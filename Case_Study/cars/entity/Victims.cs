using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cars.entity
{
    internal class Victims
    {
         public int VictimID  {get; set;} 
         public string FirstName {get; set;}
         public string  LastName {get; set;}
         public DateTime  DateOfBirth {get; set;}
         public string Gender {get; set;} 
         public string Address { get; set;}
         public string   PhoneNumber { get; set;}

        public Victims(int victimId , string firstName , string lastName , DateTime dateOfBirth, string gender , string address, string phoneNumber) { 

            VictimID = victimId;
            FirstName = firstName;
            LastName = lastName;
            DateTime DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            PhoneNumber = phoneNumber;
        
        }
        public override string ToString()

        { 
            return $"VictimID::{VictimID}\n" + $"FirstName::{FirstName}\n" + $"LastName::{LastName}\n" + $"DateOfBirth::{DateOfBirth}\n" + $"Gender::{Gender}\n" + $"Address::{Address}\n" + $"PhoneNumber::{PhoneNumber}\n"+new string('-', 50); 
        }
    }
}
