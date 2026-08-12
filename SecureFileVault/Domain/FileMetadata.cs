using SecureFileVault.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecureFileVault.Domain
{
    public class FileMetadata
    {
        private string _fileId;
        private string _originalFileName;
        private string _ownerId;
        private DateTime _createdAt;

        public FileMetadata(string fileId, string originalFileName, string ownerId, DateTime createdAt)
        {
            _fileId = fileId;
            _originalFileName = originalFileName;
            _ownerId = ownerId;
            _createdAt = createdAt;
        }
        public string FileId
        {
            get
            {
                return _fileId;
            }
        }
        public string OriginalFileName
        {
            get
            {
                return _originalFileName;
            }
        }
        public string OwnerId
        {
            get
            {
                return _ownerId;
            }
        }
        public DateTime CreatedAt
        {
            get
            {
                return _createdAt;
            }
        }
        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new FileMetadataException("New file name cannot be empty.");
            }
            _originalFileName = newName;
        }

        public override string ToString()
        {
            return _originalFileName;
        }
    }
}
