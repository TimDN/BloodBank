using BloodCenter.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BloodCenter.Persons.Donors
{
    public class FileDonorRepository : FileRepository<Donor>, IDonorRepository
    {
        private const string _applicationDirectory = "BloodBank";
        private const string _fileName = "Donors.json";
        private readonly List<Donor> _donors = new List<Donor>();

        public FileDonorRepository() : base(_applicationDirectory, _fileName)
        {
            _donors = LoadObjects();
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
            SaveObjects(_donors);
        }
    }
}
