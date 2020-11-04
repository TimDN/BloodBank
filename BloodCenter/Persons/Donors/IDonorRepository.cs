using System;
using System.Collections.Generic;
using System.Text;

namespace BloodCenter.Persons.Donors
{
    interface IDonorRepository
    {
        Donor GetDonor(Guid id);
        Donor GetDonor(string socialSecurityNumber);
        List<Donor> GetDonors();
        void AddDonor(Donor applicant);
        void RemoveDonor(Donor applicant);
        void Save();
    }
}
