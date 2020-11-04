using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Newtonsoft.Json;

namespace BloodCenter.Persons.Applicants
{
    public class FileApplicantRepository : IApplicantRepository
    {
        private readonly string _appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private readonly string _applicationDirectory = "BloodBank";
        private  readonly string _fileName = "Applicants.json";
        private readonly string _path;
        private readonly List<Applicant> _applicants = new List<Applicant>();

        public FileApplicantRepository()
        {
            var directory = Path.Combine(_appData, _applicationDirectory);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var path = Path.Combine(directory, _fileName);
            if (!File.Exists(path))
            {
                using (File.Create(path)){ }
            }
            _path = path;
            var content = File.ReadAllText(path);
            var applicants = JsonConvert.DeserializeObject<List<Applicant>>(content);
            if(!(applicants is null))
            {
                _applicants = applicants;
            }
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
            var content = JsonConvert.SerializeObject(_applicants);
            File.WriteAllText(_path, content);
        }
    }
}
