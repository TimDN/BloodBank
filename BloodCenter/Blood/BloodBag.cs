using System;

namespace BloodCenter.Blood
{
    public class BloodBag : BloodTest
    {
        public BloodBag(int id, BloodType bloodType) : base(id, bloodType)
        {
        }

        public int AmountInCL { get; private set; }

        public void SetBloodAmount(int amountInCL)
        {
            AmountInCL = amountInCL;
        }
    }
}