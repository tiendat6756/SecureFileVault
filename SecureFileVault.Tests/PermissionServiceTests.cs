using System;
using System.Collections.Generic;
using System.Text;
using SecureFileVault.Services;
using SecureFileVault.Domain;

namespace SecureFileVault.Tests
{
    [TestClass]
    public class PermissionServiceTests
    {
        private PermissionService _permissionService;

        [TestInitialize]
        public void setup()
        {
            _permissionService = new PermissionService();
        }

        [TestMethod]
        public void GrantPermission_ShouldAddPermission()
        {
            _permissionService.GrantPermission("user1", "file1");

            Assert.IsTrue(_permissionService.HasPermission("user1", "file1"));
        }

        [TestMethod]
        public void GrantPermission_ShouldNotDuplicate()
        {
            _permissionService.GrantPermission("user1", "file1");
            _permissionService.GrantPermission("user1", "file1");

            var files = _permissionService.GetUserFileIds("user1");

            Assert.AreEqual(1, files.Count);
        }

        [TestMethod]
        public void RevokePermission_ShouldRemovePermission()
        {
            _permissionService.GrantPermission("user1", "file1");
            _permissionService.RevokePermission("user1", "file1");

            Assert.IsFalse(_permissionService.HasPermission("user1", "file1"));
        }

        [TestMethod]
        public void GetUserFileIds_ShouldReturnCorrectFiles()
        {
            _permissionService.GrantPermission("user1", "file1");
            _permissionService.GrantPermission("user1", "file2");

            var files = _permissionService.GetUserFileIds("user1");
            Assert.AreEqual(2, files.Count);
        }

        [TestMethod]
        public void RemovePermissionByFile_ShouldRemoveAll()
        {
            _permissionService.GrantPermission("user1", "file1");
            _permissionService.GrantPermission("user2", "file1");

            _permissionService.RemovePermissionsByFile("file1");

            Assert.IsFalse(_permissionService.HasPermission("user1", "file1"));
            Assert.IsFalse(_permissionService.HasPermission("user2", "file1"));
        }

    }
}
