using System;
using System.Collections.Generic;
using System.Text;
using SecureFileVault.Domain;

namespace SecureFileVault.Services
{
    public class AccessControlService
    {
        private PermissionService _permissionService;

        public AccessControlService(PermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public bool CanAccess(User user, string fileId)
        {
            if(user.IsLocked())
            {
                return false;
            }
            if (user is AdminUser)
            {
                return true;
            }
            return _permissionService.HasPermission(user.UserId, fileId);
        }
    }
}
