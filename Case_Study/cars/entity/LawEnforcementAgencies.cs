using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cars.entity
{
    internal class LawEnforcementAgencies
    {
        int AgencyID { get; set; }
        string AgencyName { get; set; }
        string Jurisdiction { get; set; }
        string Address { get; set; }
        string PhoneNumber { get; set; }


        public LawEnforcementAgencies(int agencyID , string agencyName , string jurisdiction, string address, string phoneNumber)
        {
            AgencyID = agencyID;
            AgencyName = agencyName;
            Jurisdiction = jurisdiction;
            Address = address;
            PhoneNumber = phoneNumber;

        }

    }

    
}
