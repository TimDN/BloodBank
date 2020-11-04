using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BloodCenter.Persons.Donors
{
    public class FileDonorRepository : IDonorRepository
    {

        private readonly string _appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private readonly string _applicationDirectory = "BloodBank";
        private readonly string _fileName = "Donors.json";
        private readonly string _path;
        private readonly List<Donor> _donors = new List<Donor>();

        public FileDonorRepository()
        {
            var directory = Path.Combine(_appData, _applicationDirectory);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var path = Path.Combine(directory, _fileName);
            if (!File.Exists(path))
            {
                using (File.Create(path)) { }
            }
            _path = path;
            var content = File.ReadAllText(path);
            var donors = JsonConvert.DeserializeObject<List<Donor>>(content);
            if (!(donors is null))
            {
                _donors = donors;
            }
        }

        public void AddDonor(Donor donor)
        {
            _donors.Add(donor);
        }

        public Donor GetDonor(Guid id)
        {
            throw new NotImplementedException();
        }

        public Donor GetDonor(string socialSecurityNumber)
        {
            throw new NotImplementedException();
        }

        public List<Donor> GetDonors()
        {
            return _donors;
        }

        public void RemoveDonor(Donor donor)
        {
            _donors.Remove(donor);
        }

        public void Save()
        {
            var content = JsonConvert.SerializeObject(_donors);
            File.WriteAllText(_path, content);
        }
    }
}
