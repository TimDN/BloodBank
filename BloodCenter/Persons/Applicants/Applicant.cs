using BloodCenter.Blood;
using System;

namespace BloodCenter.Persons.Applicants
{
    public class Applicant : Person
    {
        public Applicant(Guid id, bool sexIsMale, BloodType bloodType)
            : base(id, sexIsMale, bloodType)
        {
        }

        public bool IsCompleted => !(Interview is null) && !(BloodTest is null);
        public string Interview { get; private set; }
        public BloodTest BloodTest { get; private set; }

        public void AddInterview(string interview)
        {
            Interview = interview;
        }

        public void AddBloodTest(BloodTest bloodTest)
        {
            BloodTest = bloodTest;
        }
    }
}