using BloodCenter.Employees;
using BloodCenter.Persons;
using System;

namespace BloodCenter.Donation
{
    public class BloodDonationBuilder
    {
        private HealthDeclaration _healthDeclaration;

        private Nurse _nurse;

        private int _heamaglobin;

        public BloodDonationBuilder(Donor donor)
        {
            Donor = donor;
        }

        public Donor Donor { get; private set; }

        public void AddHealthDeclaration(HealthDeclaration healthDeclaration)
        {
            _healthDeclaration = healthDeclaration;
        }

        public void AddNurse(Nurse nurse)
        {
            _nurse = nurse;
        }

        public void AddHeamaglobin(int heamaglobin)
        {
            _heamaglobin = heamaglobin;
        }

        public BloodDonation StartBloodDonation()
        {
            return new BloodDonation(0, Donor, _nurse, _healthDeclaration, _heamaglobin);
        }
    }
}