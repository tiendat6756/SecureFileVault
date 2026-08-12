using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using SecureFileVault.Domain;

namespace SecureFileVault.Infrastructure
{
    public class JsonFileRepository : IRepository<FileMetadata>
    {
        private readonly string _path = "data/file.json";

        public List<FileMetadata> Load()
        {
            if (!File.Exists(_path))
            {
                return new List<FileMetadata>();
            }
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<FileMetadata>>(json) ?? new List<FileMetadata>();
        }

        public void Save(List<FileMetadata> files)
        {
            Directory.CreateDirectory("data");
            var json = JsonSerializer.Serialize(files);
            File.WriteAllText(_path, json);
        }
    }
}
