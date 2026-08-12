using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using SecureFileVault.Exceptions;

namespace SecureFileVault.Infrastructure
{
    public class FileStorageService
    {
        private string _storagePath;
        private byte[] _encryptionKey;

        public FileStorageService(string storagePath, byte[] encryptionKey)
        {
            _storagePath = storagePath;
            _encryptionKey = encryptionKey;

            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }    
        }

        public void Save(string fileId, byte[] data)
        {
            byte[] encryptedData = Encrypt(data);
            
            string filePath = Path.Combine(_storagePath, fileId);
            File.WriteAllBytes(filePath, encryptedData);
        }

        public byte[] Load(string fileId)
        {
            string path = Path.Combine(_storagePath, fileId);

            if(!File.Exists(path))
            {
                throw new FileStorageException("File not found");
            }
            byte[] encryptedData = File.ReadAllBytes(path);

            return Decrypt(encryptedData);
        }

        public void Delete(string fileId)
        {
            string path = Path.Combine(_storagePath, fileId);

            if(File.Exists(path))
            {
                File.Delete(path);
            }    
        }

        public bool Exists(string fileId)
        {
            string path = Path.Combine(_storagePath, fileId);
            return File.Exists(path);
        }

        private byte[] Encrypt(byte[] data)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = _encryptionKey;
                aes.GenerateIV();

                using (var encryptor = aes.CreateEncryptor())
                using (var ms = new MemoryStream())
                { 
                    ms.Write(aes.IV, 0, aes.IV.Length);

                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.FlushFinalBlock();
                    }
                    
                    return ms.ToArray();
                }    
            }    
        }

        private byte[] Decrypt(byte[] encryptedData)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = _encryptionKey;

                byte[] iv = new byte[16];
                Array.Copy(encryptedData, 0, iv, 0, iv.Length);
                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor())
                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(new MemoryStream(encryptedData, 16, encryptedData.Length - 16), decryptor, CryptoStreamMode.Read))
                {
                    cs.CopyTo(ms);
                    return ms.ToArray();
                }    
            }    
        }
    }
}
