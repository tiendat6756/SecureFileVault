using System;
using System.Collections.Generic;
using System.Text;

namespace SecureFileVault.Domain
{
    public class FilePermission
    {
        private string _fileId;
        private string _userId;

        public FilePermission(string fileId, string userId)
        {
            _fileId = fileId;
            _userId = userId;
        }

        public string FileId
        {
            get
            {
                return _fileId;
            }
        }
        public string UserId
        {
            get
            {
                return _userId;
            }
        }
    }
}
