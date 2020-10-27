using BloodCenter.Blood;
using BloodCenter.Employees;
using BloodCenter.Persons;
using System;

namespace BloodCenter.Donation
{
    public class BloodDonation : IBlockable
    {
        private int _blockTimeInDays;

        private string _blockReason;

        public BloodDonation(int id, Donor donor, Nurse nurse, HealthDeclaration healthDeclaration)
        {
            Id = id;
            Donor = donor;
            ResponsibleNurse = nurse;
            HealthDeclaration = healthDeclaration;
            DonationDate = DateTimeOffset.Now;
        }

        public BloodDonation(int id, Donor donor, Nurse nurse, HealthDeclaration healthDeclaration, int heamaglobin) :
            this(id, donor, nurse, healthDeclaration)
        {
            Hemaglobin = heamaglobin;
        }

        public int Id { get; }
        public BloodBag BloodBag { get; private set; }
        public DateTimeOffset DonationDate { get; }
        public Donor Donor { get; }
        public HealthDeclaration HealthDeclaration { get; }
        public Nurse ResponsibleNurse { get; }
        public int Hemaglobin { get; }

        public string BlockReason => HealthDeclaration.BlockReason + " " + _blockReason;
        public int BlockTimeInDays => Math.Max(HealthDeclaration.BlockTimeInDays, _blockTimeInDays);
        public bool IsBlocked => HealthDeclaration.IsBlocked || !Approved;

        public bool Approved { get; private set; }

        public void Approve()
        {
            Approved = true;
        }

        public void Block(string reason, int blockTimeInDays)
        {
            Approved = false;
            _blockReason = reason;
            _blockTimeInDays = blockTimeInDays;
        }

        public void EndDonation()
        {
            if (!IsBlocked)
            {
                BlockBasedOnSex();
            }
            else
            {
                Donor.Block(BlockTimeInDays);
            }
        }

        private void BlockBasedOnSex()
        {
            if (Donor.SexIsMale)
            {
                Donor.Block(31);
            }
            else
            {
                Donor.Block(61);
            }
        }
    }
}