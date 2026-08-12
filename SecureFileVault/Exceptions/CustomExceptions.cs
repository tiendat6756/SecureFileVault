using System;
using System.Collections.Generic;
using System.Text;

namespace SecureFileVault.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string message) : base(message) { }
    }

    public class AccessControlException : Exception
    {
        public AccessControlException(string message) : base(message) { }
    }

    public class PermissionDeniedException : Exception
    {
        public PermissionDeniedException(string message) : base(message) { }
    }

    public class FileStorageException : Exception
    {
        public FileStorageException(string message) : base(message) { }
    }

    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message) : base(message) { }
    }
    public class FileMetadataException : Exception
    {
        public FileMetadataException(string message) : base(message) { }
    }
}
