using SecureFileVault.Application;
using SecureFileVault.Services;
using SecureFileVault.Infrastructure;
using SecureFileVault.Domain;
namespace SecureFileVault
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            IRepository<User> userRepo = new JsonUserRepository();
            IRepository<FileMetadata> fileRepo = new JsonFileRepository();
            IRepository<FilePermission> permRepo = new JsonPermissionRepository();

            var incident = new IncidentDetector(3);
            var authService = new AuthenticationService(incident, userRepo);
            var permissionService = new PermissionService(permRepo);
            var accessService = new AccessControlService(permissionService);

            var keyManager = new MasterKeyManager("data/master.key");
            byte[] key;

            if (keyManager.KeyExists())
            {
                key = keyManager.LoadKey();
            }
            else
            {
                key = keyManager.GenerateAndSaveKey();
            }

            var tempFileManager = new TempFileManager("temp");
            tempFileManager.Cleanup();
            System.Windows.Forms.Application.ApplicationExit += (s, e) =>
            {
                tempFileManager.Cleanup();
            };

            var controller = new VaultController(
                authService,
                accessService,
                permissionService,
                new FileStorageService("storage", key),
                 tempFileManager,
                fileRepo
            );

            if (!authService.AdminExists())
            {
               using (var createAdminForm = new CreateAdminForm(authService))
               {
                   var result = createAdminForm.ShowDialog();
                   if (result != System.Windows.Forms.DialogResult.OK)
                   {
                       return;
                   }
               }
            }    

            System.Windows.Forms.Application.Run(new LoginForm(authService, controller));
        }
    }
}