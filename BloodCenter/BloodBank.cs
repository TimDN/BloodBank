using BloodCenter.Donation;
using BloodCenter.Employees;
using BloodCenter.Persons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BloodCenter
{
    public class BloodBank
    {
        public List<BloodDonationBuilder> ActiveDonations { get; } = new List<BloodDonationBuilder>();

        public BloodDonationBuilder StartBloodDonation(Donor donor)
        {
            if (donor.IsBlocked())
            {
                throw new ArgumentException();
            }
            var bloodDonation = new BloodDonationBuilder(donor);
            ActiveDonations.Add(bloodDonation);
            return bloodDonation;
        }

        public BloodDonationBuilder CheckoutBloodDonation(Nurse nurse, Donor donor)
        {
            var bloodDonation = ActiveDonations.Single(e => e.Donor == donor);
            ActiveDonations.Remove(bloodDonation);
            bloodDonation.AddNurse(nurse);
            return bloodDonation;
        }

        public List<Donor> ActiveDonors()
        {
            return ActiveDonations.Select(e => e.Donor).ToList();
        }
    }
}