using System;

namespace BloodCenter.Blood
{
    public class BloodTest
    {
        public BloodTest(int id, BloodType bloodType)
        {
            Id = id;
            BloodType = bloodType;
        }

        public int Id { get; }
        public BloodType BloodType { get; }
        public bool Tested { get; private set; }
        public string BloodStatus { get; private set; }
        public bool BloodIsOk { get; private set; }

        public void SetBloodStatus(string bloodStatus, bool bloodIsOk)
        {
            Tested = true;
            BloodStatus = bloodStatus;
            BloodIsOk = bloodIsOk;
        }
    }
}