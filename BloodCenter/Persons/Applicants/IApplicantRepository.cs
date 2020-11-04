using System;
using System.Collections.Generic;

namespace BloodCenter.Persons.Applicants
{
    interface IApplicantRepository
    {
        Applicant GetApplicant(Guid id);
        Applicant GetApplicant(string socialSecurityNumber);
        List<Applicant> GetApplicants();
        List<Applicant> GetPendingApplicants();
        List<Applicant> GetUnfinishedApplicants();
    }
}