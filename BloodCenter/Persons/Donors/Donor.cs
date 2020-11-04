using BloodCenter.Blood;
using BloodCenter.Donation;
using System;

namespace BloodCenter.Persons.Donors
{
    public class Donor : Person
    {
        private Block _block;

        public Donor(Guid id, bool sexIsMale, BloodType bloodType)
            : base(id, sexIsMale, bloodType)
        {
        }

        public void Block(int daysBlocked)
        {
            _block = new Block(daysBlocked);
        }

        public bool IsBlocked()
        {
            return _block?.Active ?? false;
        }
    }
}