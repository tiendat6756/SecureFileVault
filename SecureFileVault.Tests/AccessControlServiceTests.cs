using System;
using System.Collections.Generic;
using System.Text;
using SecureFileVault.Services;
using SecureFileVault.Domain;

namespace SecureFileVault.Tests
{
    [TestClass]   
    public class AccessControlServiceTests
    {
        private PermissionService _permissionService;
        private AccessControlService _accessControlService;

        [TestInitialize]
        public void setup()
        {
            _permissionService = new PermissionService();
            _accessControlService = new AccessControlService(_permissionService);
        }

        [TestMethod]
        public void CanAccess_Admin_ShouldReturnTrue()
        {
            var admin = new AdminUser("1", "admin", new byte[0], new byte[0]);

            bool result = _accessControlService.CanAccess(admin, "file1");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanAccess_ViewerWithPermission_ShouldReturnTrue()
        {
            var viewer = new ViewerUser("2", "user", new byte[0], new byte[0]);

            _permissionService.GrantPermission("2", "file1");

            bool result = _accessControlService.CanAccess(viewer, "file1");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanAccess_LockedUser_ShouldReturnFalse()
        {
            var viewer = new ViewerUser("2", "user", new byte[0], new byte[0]);
            viewer.LockAccount();
            _permissionService.GrantPermission("2", "file1");

            bool result = _accessControlService.CanAccess(viewer, "file1");
            Assert.IsFalse(result);
        }
    }
}
