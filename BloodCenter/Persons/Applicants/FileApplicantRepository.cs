using System;
using System.Collections.Generic;
using System.Text;

namespace BloodCenter.Persons.Applicants
{
    class FileApplicantRepository : IApplicantRepository
    {

        public Applicant GetApplicant(Guid id)
        {
            return null;
        }

        public Applicant GetApplicant(string socialSecurityNumber)
        {
            return null;
        }

        public List<Applicant> GetApplicants()
        {
            return null;
        }

        public List<Applicant> GetPendingApplicants()
        {
            return null;
        }

        public List<Applicant> GetUnfinishedApplicants()
        {
            return null;
        }
    }
}
