using BloodCenter.Blood;
using System;

namespace BloodCenter.Persons
{
    public class Person
    {
        public Person(int id, bool sexIsMale, BloodType bloodType)
        {
            Id = id;
            SexIsMale = sexIsMale;
        }

        public BloodType BloodType { get; }
        public int Id { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool SexIsMale { get; }
    }
}