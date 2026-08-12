using SecureFileVault.Domain;
using SecureFileVault.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
namespace SecureFileVault.Services
{
    public class PermissionService
    {
        private List<FilePermission> _permissions;
        private IRepository<FilePermission> _permissionRepository;

        public PermissionService(IRepository<FilePermission> repo)
        {
            _permissionRepository = repo;
            _permissions = _permissionRepository.Load();
        }

        public void GrantPermission(string userId, string fileId)
        {
            FilePermission tempPermission = new FilePermission(fileId, userId);
            if (!HasPermission(userId, fileId))
            {
                _permissions.Add(tempPermission);
                _permissionRepository.Save(_permissions);
            } 
        }

        public void RevokePermission(string userId, string fileId)
        {
            _permissions.RemoveAll(p => p.UserId == userId && p.FileId == fileId);
            _permissionRepository.Save(_permissions);
        }

        public bool HasPermission(string userId, string fileId)
        {
            foreach (FilePermission permission in _permissions)
            {
                if (permission.UserId == userId && permission.FileId == fileId)
                {
                    return true;
                }
            }
            return false;
        }

        public List<string> GetUserFileIds(string userId)
        {
            List<string> fileIds = new List<string>();
            foreach (FilePermission permission in _permissions)
            {
                if (permission.UserId == userId)
                {
                    fileIds.Add(permission.FileId);
                }
            }
            return fileIds;
        }

        public void RemovePermissionsByFile(string fileId)
        {
            _permissions.RemoveAll(p => p.FileId == fileId);
            _permissionRepository.Save(_permissions);
        }
    }
}
