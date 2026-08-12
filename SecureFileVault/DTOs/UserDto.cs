using System;
using System.Collections.Generic;
using System.Text;

namespace SecureFileVault.DTOs
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash {  get; set; }
        public byte[] Salt { get; set; }
        public string Role { get; set; }
    }
}
