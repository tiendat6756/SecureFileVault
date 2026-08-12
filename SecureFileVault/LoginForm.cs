using SecureFileVault.Services;
using SecureFileVault.Domain;
using SecureFileVault.Application;
using SecureFileVault.Infrastructure;

namespace SecureFileVault
{
    public partial class LoginForm : Form
    {
        private AuthenticationService _authenticationService;
        private VaultController _vaultController;
        private TempFileManager _tempFileManager;
        public LoginForm(AuthenticationService authenticationService, VaultController controller, TempFileManager tempFileManager)
        {
            InitializeComponent();
            _authenticationService = authenticationService;
            _vaultController = controller;
            _tempFileManager = tempFileManager;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var result = _authenticationService.Login(username, password);

            if (result == LoginResult.Success)
            {
                var user = _authenticationService.GetUser(username);

                var mainForm = new MainForm(user, _vaultController, _tempFileManager);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(result.ToString());
            }

        }
    }
}
