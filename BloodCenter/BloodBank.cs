using BloodCenter.Donation;
using BloodCenter.Employees;
using BloodCenter.Persons;
using BloodCenter.Persons.Donors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BloodCenter
{
    public class BloodBank
    {
        public List<BloodDonation> ActiveDonations { get; } = new List<BloodDonation>();

        public BloodDonation StartBloodDonation(Donor donor)
        {
            if (donor.IsBlocked())
            {
                throw new ArgumentException();
            }
            var bloodDonation = new BloodDonation(0, donor);
            ActiveDonations.Add(bloodDonation);
            return bloodDonation;
        }

        public void AbortDonation(BloodDonation bloodDonation)
        {
            ActiveDonations.Remove(bloodDonation);
            bloodDonation.EndDonation();
        }

        public BloodDonation CheckoutBloodDonation(Donor donor)
        {
            var bloodDonation = ActiveDonations.Single(e => e.Donor == donor);
            ActiveDonations.Remove(bloodDonation);
            return bloodDonation;
        }

        public List<Donor> ActiveDonors()
        {
            return ActiveDonations.Select(e => e.Donor).ToList();
        }
    }
}