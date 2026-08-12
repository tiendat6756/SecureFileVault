using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using SecureFileVault.Domain;
using SecureFileVault.DTOs;

namespace SecureFileVault.Infrastructure
{
    public class JsonUserRepository : IRepository<User>
    {
        private readonly string _path = "data/users.json";

        public List<User> Load()
        {
            if (!File.Exists(_path))
            {
                return new List<User>();
            }    

            var json = File.ReadAllText(_path);

            var dtos = JsonSerializer.Deserialize<List<UserDto>>(json);

            var users = new List<User>();

            foreach (var dto in dtos)
            {
                if (dto.Role == "Admin")
                {
                    users.Add(new AdminUser(dto.UserId, dto.Username, dto.PasswordHash, dto.Salt));
                }
                else if (dto.Role == "Viewer")
                {
                    users.Add(new ViewerUser(dto.UserId, dto.Username, dto.PasswordHash, dto.Salt));
                }
            }

            return users;
        }

        public void Save(List<User> users)
        {
            Directory.CreateDirectory("data");

            var dtos = new List<UserDto>();

            foreach (var user in users)
            {
                dtos.Add(new UserDto
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    PasswordHash = user.PasswordHash,
                    Salt = user.Salt,
                    Role = user is AdminUser ? "Admin" : "Viewer"
                });
            }

            var json = JsonSerializer.Serialize(dtos);
            File.WriteAllText(_path, json);
        }
    }
}
