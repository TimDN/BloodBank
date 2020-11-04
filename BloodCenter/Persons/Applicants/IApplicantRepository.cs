using System;
using System.Collections.Generic;

namespace BloodCenter.Persons.Applicants
{
    public interface IApplicantRepository
    {
        Applicant GetApplicant(Guid id);
        Applicant GetApplicant(string socialSecurityNumber);
        List<Applicant> GetApplicants();
        List<Applicant> GetPendingApplicants();
        List<Applicant> GetUnfinishedApplicants();
        void AddApplicant(Applicant applicant);
        void RemoveApplicant(Applicant applicant);
        void Save();
    }
}