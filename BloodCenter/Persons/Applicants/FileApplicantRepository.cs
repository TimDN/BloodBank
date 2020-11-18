using System;
using System.Collections.Generic;
using System.Linq;
using BloodCenter.Repository;

namespace BloodCenter.Persons.Applicants
{
    public class FileApplicantRepository : FileRepository<Applicant>, IApplicantRepository
    {
        private const string _applicationDirectory = "BloodBank";
        private const string _fileName = "Applicants.json";
        private readonly List<Applicant> _applicants;

        public FileApplicantRepository() : base (_applicationDirectory, _fileName)
        {
            _applicants = LoadObjects();
        }

        public void AddApplicant(Applicant applicant)
        {
            _applicants.Add(applicant);
        }

        public Applicant GetApplicant(Guid id)
        {
            return _applicants.Single(e => e.Id == id);
        }

        public Applicant GetApplicant(string socialSecurityNumber)
        {
            return null;
        }

        public List<Applicant> GetApplicants()
        {
            return _applicants;
        }

        public List<Applicant> GetPendingApplicants()
        {
            return null;
        }

        public List<Applicant> GetUnfinishedApplicants()
        {
            return null;
        }

        public void RemoveApplicant(Applicant applicant)
        {
            _applicants.Remove(applicant);
        }

        public void Save()
        {
            SaveObjects(_applicants);
        }
    }
}
