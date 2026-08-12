using System;
using System.Collections.Generic;
using System.Text;

namespace SecureFileVault.Domain
{
    public abstract class User
    {
        private string _userId;
        private string _username;
        private byte[] _passwordHash;
        private byte[] _salt;
        private AccountState _state;
        private string _role;

        public User(string id, string username, byte[] passwordHash, byte[] salt, string role) {
            _userId = id;
            _username = username;
            _passwordHash = passwordHash;
            _salt = salt;
            _state = AccountState.Active;
            _role = role;
        }
        public string UserId
        {
            get
            {
                return _userId;
            }
        }
        public string Username
        {
            get
            {
                return _username;
            }
        }

        public string Role
        {
            get
            {
                return _role;
            }
        }
        public void LockAccount()
        {
            _state = AccountState.Locked;
        }
        public void UnlockAccount()
        {
            _state = AccountState.Active;
        }
        public bool IsLocked()
        {
            return _state == AccountState.Locked;
        }
        public byte[] PasswordHash
        {
            get
            {
                return _passwordHash;
            }
        }
        public byte[] Salt
        {
            get
            {
                return _salt;
            }
        }

        public override string ToString()
        {
            return $"{Username} {UserId}";
        }
    }
}
