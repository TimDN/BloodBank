using BloodCenter.Blood;
using BloodCenter.Persons;
using BloodCenter.Persons.Applicants;
using System;

namespace AdminUI
{
    class Program
    {
        private static IApplicantRepository _applicantRepository;

        static void Main(string[] args)
        {
            _applicantRepository = new FileApplicantRepository();

            try
            {

            }
            finally
            {
                _applicantRepository.Save();
            }
            Console.WriteLine("Hello World!");
        }

        private static void CreateApplicant()
        {
            var applicant = new Applicant(Guid.NewGuid(), true, BloodType.ABn);
            _applicantRepository.AddApplicant(applicant);
        }
    }
}
