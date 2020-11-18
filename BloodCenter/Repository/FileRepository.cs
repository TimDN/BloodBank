using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BloodCenter.Repository
{
    public abstract class FileRepository<T>
    {
        protected readonly string _path;
        private readonly string _appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public FileRepository(string directoryName, string fileName)
        {
            var directory = Path.Combine(_appData, directoryName);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var path = Path.Combine(directory, fileName);
            if (!File.Exists(path))
            {
                using (File.Create(path)) { }
            }
            _path = path;
        }

        protected List<T> LoadObjects()
        {
            var list = new List<T>();
            var content = File.ReadAllText(_path);
            var loadedObjects = JsonConvert.DeserializeObject<List<T>>(content);
            if (!(loadedObjects is null))
            {
                list = loadedObjects;
            }
            return list;
        }

        protected void SaveObjects(List<T> objects)
        {
            var content = JsonConvert.SerializeObject(objects);
            File.WriteAllText(_path, content);
        }
    }
}
