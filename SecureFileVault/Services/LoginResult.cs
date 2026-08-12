using System;
using System.Collections.Generic;
using System.Text;

namespace SecureFileVault.Services
{
    public enum LoginResult
    {
        Success,
        WrongPassword,
        UserNotFound,
        Locked
    }
}
