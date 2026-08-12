using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using SecureFileVault.Domain;
using System.Linq;
using SecureFileVault.Infrastructure;
using SecureFileVault.Exceptions;

namespace SecureFileVault.Services
{
    public class AuthenticationService
    {
        private List<User> _users;
        private IncidentDetector _incidentDetector;
        private IRepository<User> _userRepository;

        public AuthenticationService(IncidentDetector incidentDetector, IRepository<User> repo)
        {
            _incidentDetector = incidentDetector;
            _userRepository = repo;
            _users = _userRepository.Load();
            _userRepository.Save(_users);
        }

        public bool AdminExists()
        {
            foreach (var user in _users)
            {
                if (user is AdminUser)
                {
                    return true;
                }
            }
            return false;
        }

        public User RegisterAdmin(string username, string password)
        {
            if (AdminExists())
            {
                throw new UserAlreadyExistsException("Admin already exists.");
            }

            string userId = Guid.NewGuid().ToString();
            byte[] salt = GenerateSalt();
            byte[] hash = HashPassword(password, salt);

            User admin = new AdminUser(userId, username, hash, salt);

            _users.Add(admin);
            _userRepository.Save(_users);
            return admin;
        }

        public User RegisterViewer(string username, string passsword)
        {
            if (_users.Any(u => u.Username == username))
            {
                throw new UserAlreadyExistsException("Viewer already exists.");
            }    
            string userId = Guid.NewGuid().ToString();
            byte[] salt = GenerateSalt();
            byte[] hash = HashPassword(passsword, salt);
            User viewer = new ViewerUser(userId, username, hash, salt);
            _users.Add(viewer);
            _userRepository.Save(_users);
            return viewer;
        }

        public LoginResult Login(string username, string password)
        {
            var user = _users.Find(u => u.Username == username);
            if (user == null)
            {
                return LoginResult.UserNotFound;
            }
            
            if (user.IsLocked())
            {
                return LoginResult.Locked;
            }
            
            bool valid = VerifyPassword(password, user.PasswordHash, user.Salt);
            if (!valid)
            {
                _incidentDetector.RecordViolation(user.UserId);
                if (_incidentDetector.ShouldLock(user.UserId))
                {
                    user.LockAccount();
                }
                return LoginResult.WrongPassword;
            }
            
            _incidentDetector.Reset(user.UserId);
            return LoginResult.Success;
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUser(string username)
        {
            return _users.Find(u => u.Username == username);
        }

        public void DeteleUser(User admin, string userId)
        {
            if (!(admin is AdminUser))
            {
                throw new PermissionDeniedException("Only admin can delete user !!!");
            }
            var user = _users.Find(u => u.UserId == userId);
            if (user != null)
            {
                _users.Remove(user);
                _userRepository.Save(_users);
            }
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            RandomNumberGenerator.Fill(salt);
            return salt;
        }

        private byte[] HashPassword(string password, byte[] salt)
        {
            return Rfc2898DeriveBytes.Pbkdf2(password, salt, 100000, HashAlgorithmName.SHA256, 32);
        }

        private bool VerifyPassword(string input, byte[] storedHash, byte[] storedSalt)
        {
            var hash = HashPassword(input, storedSalt);
            return hash.SequenceEqual(storedHash);

        }
    }
}
