using SecureFileVault.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SecureFileVault.Infrastructure
{
    public class JsonPermissionRepository : IRepository<FilePermission>
    {
        private readonly string _path = "data/permission.json";

        public List<FilePermission> Load()
        {
            if (!File.Exists(_path))
            {
                return new List<FilePermission>();
            }
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<FilePermission>>(json) ?? new List<FilePermission>();
        }

        public void Save(List<FilePermission> permissions)
        {
            Directory.CreateDirectory("data");
            var json = JsonSerializer.Serialize(permissions);
            File.WriteAllText(_path, json);
        }
    }
}
