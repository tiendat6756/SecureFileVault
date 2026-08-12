using System;
using System.Collections.Generic;
using System.Text;

namespace SecureFileVault.Domain
{
    public class AdminUser : User
    {
        public AdminUser(string id, string username, byte[] passwordHash, byte[] salt) : base(id, username, passwordHash, salt, "Admin")
        {
        }
    }
}
