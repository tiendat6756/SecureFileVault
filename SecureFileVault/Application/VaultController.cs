using SecureFileVault.Domain;
using SecureFileVault.Infrastructure;
using SecureFileVault.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SecureFileVault.Exceptions;
using System.Security.Policy;

namespace SecureFileVault.Application
{
    public class VaultController
    {
        private AuthenticationService _authService;
        private AccessControlService _accessService;
        private PermissionService _permissionService;
        private FileStorageService _storageService;
        private TempFileManager _tempFileManager;

        private List<FileMetadata> _files;
        private IRepository<FileMetadata> _fileRepository;

        public VaultController(AuthenticationService authService, AccessControlService accessService, PermissionService permissionService, FileStorageService storageService, TempFileManager tempFileManager, IRepository<FileMetadata> fileRepository)
        {
            _authService = authService;
            _accessService = accessService;
            _permissionService = permissionService;
            _storageService = storageService;
            _tempFileManager = tempFileManager;
            
            _fileRepository = fileRepository;
            _files = _fileRepository.Load();
        }

        public User RegisterAdmin(string username, string password)
        {
            return _authService.RegisterAdmin(username, password);
        }

        public User RegisterViewer(User admin, string username, string password)
        {
            if (!(admin is AdminUser))
            {
                throw new PermissionDeniedException("Only admin can create viewer !!!");
            }
            return _authService.RegisterViewer(username, password);
        }

        public LoginResult Login(string username, string password)
        {
            return _authService.Login(username, password);
        }

        public List<User> GetAllUsers(User admin)
        {
            if (!(admin is AdminUser))
            {
                throw new PermissionDeniedException("Only admin can view users !!!");
            }
            return _authService.GetAllUsers();
        }

        public void DeleteViewer(User admin, string viewerId)
        {
            if (!(admin is AdminUser))
            {
                throw new PermissionDeniedException("Only admin can delete viewer !!!");
            }
            _authService.DeteleUser(admin, viewerId);
        }


        public void UploadFile(User user, string filePath)
        {
            if(user.IsLocked())
            {
                throw new PermissionDeniedException("Account is locked !");
            }

            string fileId = Guid.NewGuid().ToString();
            byte[] data = File.ReadAllBytes(filePath);

            _storageService.Save(fileId, data);

            var metadata = new FileMetadata(fileId, System.IO.Path.GetFileName(filePath), user.UserId, DateTime.Now);

            _files.Add(metadata);
            _fileRepository.Save(_files);
        }

        public void ViewFile(User user, string fileId)
        {
            var file = _files.Find(f => f.FileId == fileId);

            if(file == null)
            {
                throw new FileStorageException("File not found");
            }

            if(!_accessService.CanAccess(user, fileId))
            {
                throw new AccessControlException("Access denied !!!");
            }

            byte[] data = _storageService.Load(fileId);

            string tempPath = _tempFileManager.CreateTempFile(file.OriginalFileName, data);
            _tempFileManager.OpenFile(tempPath);
        }

        public void DownloadFile(User user, string fileId, string savePath)
        {
            var file = _files.Find(f => f.FileId == fileId);

            if (file == null)
            {
                throw new FileStorageException("File not found");
            }


            if (user.IsLocked())
            { 
                throw new AuthenticationException("User is locked");
            }
            if((!(user is AdminUser)) && (!_accessService.CanAccess(user, fileId)))
            {
                throw new PermissionDeniedException("You do not have the permission");
            }

            byte[] data = _storageService.Load(fileId);

            string fullPath = System.IO.Path.Combine(savePath, file.OriginalFileName);

            System.IO.File.WriteAllBytes(fullPath, data);
        }

        public void DeleteFile(User user, string fileId)
        {
            var file = _files.Find(f => f.FileId == fileId);

            if (file == null)
            {
                throw new FileStorageException("File not found");
            }


            if (user.IsLocked())
            {
                throw new AuthenticationException("User is locked");
            }
            if ((!(user is AdminUser)))
            {
                throw new PermissionDeniedException("You do not have the permission");
            }

            _storageService.Delete(fileId);
            _permissionService.RemovePermissionsByFile(fileId);
            _files.Remove(file);
            _fileRepository.Save(_files);
        }


        public void GrantFileAccess(User admin, string viewerId, string fileId)
        {
            if(!(admin is AdminUser))
            {
                throw new PermissionDeniedException("Only admin can grant access");
            }

            _permissionService.GrantPermission(viewerId, fileId);
        }

        public List<FileMetadata> GetFiles(User user)
        {
            if (user is AdminUser)
            {
                return _files;
            }

            var allowedIds = _permissionService.GetUserFileIds(user.UserId);
            return _files.FindAll(f => allowedIds.Contains(f.FileId));
        }

        public List<User> GetViewerUsers()
        {
            return _authService.GetAllUsers().Where(user => user is ViewerUser).ToList();
        }


        


    }
}
