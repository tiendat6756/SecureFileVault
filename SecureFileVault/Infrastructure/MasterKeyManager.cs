using SecureFileVault.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SecureFileVault.Infrastructure
{
    public class MasterKeyManager
    {
        private string _keyFilePath;

        public MasterKeyManager(string keyFilePath)
        {
            _keyFilePath = keyFilePath;
        }

        public bool KeyExists()
        { 
            return File.Exists(_keyFilePath);
        }

        public byte[] GenerateAndSaveKey()
        {
            byte[] key = new byte[32];
            string dir = Path.GetDirectoryName(_keyFilePath);

            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                rng.GetBytes(key);
            }   

            File.WriteAllBytes(_keyFilePath, key);
            return key;
        }

        public byte[] LoadKey()
        {
            if (!File.Exists(_keyFilePath))
            {
                throw new FileStorageException("Master key file not found");
            }
            return File.ReadAllBytes(_keyFilePath);
        }
    }
}