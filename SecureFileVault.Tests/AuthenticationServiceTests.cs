using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureFileVault.Services;
using SecureFileVault.Domain;

namespace SecureFileVault.Tests
{
    [TestClass]
    public class AuthenticationServiceTests
    {
        private AuthenticationService _authenticationService;

        [TestInitialize]
        public void Setup()
        {
            var incidentDetector = new IncidentDetector(3);
            _authenticationService = new AuthenticationService(incidentDetector);
        }

        [TestMethod]
        public void RegisterAdmin_ShouldCreateAdmin()
        {
            var admin = _authenticationService.RegisterAdmin("admin", "123");

            Assert.IsNotNull(admin);
            Assert.IsTrue(admin is AdminUser);
        }

        [TestMethod]
        public void RegisterAdmin_WhenAdminExists_ShouldThrow()
        {
            _authenticationService.RegisterAdmin("admin1", "123");

            var ex = Assert.Throws<Exception>(() =>
            {
                _authenticationService.RegisterAdmin("admin2", "2435");
            });
            Assert.AreEqual("Admin already exists.", ex.Message);
        }

        [TestMethod]
        public void RegisterViewer_ShouldCreateViewer()
        {
            var viewer = _authenticationService.RegisterViewer("viewer", "123");

            Assert.IsNotNull(viewer);
            Assert.IsTrue(viewer is ViewerUser);
        }

        [TestMethod]
        public void RegisterViewer_WhenUsernameExists_ShouldThrow()
        {
            _authenticationService.RegisterViewer("viewer1", "23346");

            var ex = Assert.Throws<Exception>(() =>
            {
                _authenticationService.RegisterViewer("viewer1", "2435");
            });
            Assert.AreEqual("Username already taken.", ex.Message);
        }

        [TestMethod]
        public void Login_WithCorrectPassword_ShouldReturnSuccess()
        {
            _authenticationService.RegisterAdmin("admin", "123");
            var result = _authenticationService.Login("admin", "123");

            Assert.AreEqual(LoginResult.Success, result);
        }

        [TestMethod]
        public void Login_WithWrongPassword_ShouldReturnWrongPassword()
        {
            _authenticationService.RegisterAdmin("admin", "123");
            var result = _authenticationService.Login("admin", "1243");

            Assert.AreEqual(LoginResult.WrongPassword, result);
        }

        [TestMethod]
        public void Login_UserNotFound_ShouldReturnUserNotFound()
        {
            var result = _authenticationService.Login("admin", "1243");

            Assert.AreEqual(LoginResult.UserNotFound, result);
        }

        [TestMethod]
        public void Login_TooManyWrongAttempts_ShouldLockAccount()
        {
            _authenticationService.RegisterAdmin("admin", "123");

            _authenticationService.Login("admin", "wrong");
            _authenticationService.Login("admin", "wrong");
            _authenticationService.Login("admin", "wrong");

            var result = _authenticationService.Login("admin", "123");

            Assert.AreEqual(LoginResult.Locked, result);
        }
    }
}
