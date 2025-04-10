using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cars.entity
{
    internal class Officer
    {
        public int OfficerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BadgeNumber { get; set; }
        public string Rank { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int AgencyID { get; set; }

       
        public Officer(int officerID, string firstName, string lastName, string badgeNumber, string rank, string address, string phoneNumber, int agencyID)
        {
            OfficerID = officerID;
            FirstName = firstName;
            LastName = lastName;
            BadgeNumber = badgeNumber;
            Rank = rank;
            Address = address;
            PhoneNumber = phoneNumber;
            AgencyID = agencyID;
        }
    }

}
