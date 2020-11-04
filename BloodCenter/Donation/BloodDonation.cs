using BloodCenter.Blood;
using BloodCenter.Employees;
using BloodCenter.Persons;
using BloodCenter.Persons.Donors;
using System;

namespace BloodCenter.Donation
{
    public class BloodDonation : IReviewable
    {
        private int _blockTimeInDays;
        private string _blockReason;
        private bool _wasBlocked;

        public BloodDonation(int id, Donor donor)
        {
            Id = id;
            Donor = donor;
            DonationDate = DateTimeOffset.Now;
        }

        public int Id { get; }
        public BloodBag BloodBag { get; private set; }
        public DateTimeOffset DonationDate { get; }
        public Donor Donor { get; }
        public HealthDeclaration HealthDeclaration { get; private set; }
        public Nurse ResponsibleNurse { get; private set; }
        public int Hemaglobin { get; private set; }

        public string BlockReason => HealthDeclaration.BlockReason + " " + _blockReason;
        public int BlockTimeInDays => Math.Max(HealthDeclaration.BlockTimeInDays, _blockTimeInDays);
        public bool IsBlocked => HealthDeclaration.IsBlocked || !_wasBlocked;

        public bool Reviewed { get; private set; }

        public Nurse ReviewBy { get; private set; }

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

        public void AddHealthDeclaration(HealthDeclaration healthDeclaration)
        {
            HealthDeclaration = healthDeclaration;
        }

        public void AddHeameglobin(int heameglobin)
        {
            Hemaglobin = heameglobin;
        }

        private void BlockBasedOnSex()
        {
            if (Donor.SexIsMale)
            {
                Donor.Block(1);
            }
            else
            {
                Donor.Block(61);
            }
        }

        public void Approve(Nurse nurse)
        {
            Reviewed = true;
            ReviewBy = nurse;
        }

        public void Block(Nurse nurse, string reason, int blockTimeInDays)
        {
            Reviewed = false;
            ReviewBy = nurse;
            _wasBlocked = true;
            _blockReason = reason;
            _blockTimeInDays = blockTimeInDays;
        }
    }
}