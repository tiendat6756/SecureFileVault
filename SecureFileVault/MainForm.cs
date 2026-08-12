using SecureFileVault.Application;
using SecureFileVault.Domain;
using SecureFileVault.Infrastructure;
using SecureFileVault.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace SecureFileVault
{
    public partial class MainForm : Form
    {
        private User _currentUser;
        private VaultController _controller;
        private TempFileManager _tempFileManager;
        public MainForm(User user, VaultController controller, TempFileManager tempFileManager)
        {
            InitializeComponent();
            _currentUser = user;
            _controller = controller;
            _tempFileManager = tempFileManager;

            LoadFiles();
            SetupUI();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _tempFileManager.Cleanup();
            base.OnFormClosed(e);
        }

        private void LoadFiles()
        {
            listFiles.Items.Clear();
            var files = _controller.GetFiles(_currentUser);

            foreach (var file in files)
            {
                listFiles.Items.Add(file);
            }
        }

        private void SetupUI()
        {
            if (!(_currentUser is AdminUser))
            {
                btnUpload.Visible = false;
                btnDelete.Visible = false;
                btnGrant.Visible = false;
                btnRegisterViewer.Visible = false;
                btnManagerUsers.Visible = false;
                btnRemoveViewer.Visible = false;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _controller.UploadFile(_currentUser, dialog.FileName);
                LoadFiles();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (listFiles.SelectedItem is FileMetadata file)
            {
                _controller.ViewFile(_currentUser, file.FileId);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (listFiles.SelectedItem is FileMetadata file)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _controller.DownloadFile(_currentUser, file.FileId, dialog.SelectedPath);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listFiles.SelectedItem is FileMetadata file)
            {
                _controller.DeleteFile(_currentUser, file.FileId);
                LoadFiles();
            }
        }

        public static string ShowUserSelection(List<User> users)
        {
            Form form = new Form()
            {
                Width = 300,
                Height = 180,
                Text = "Select User"

            };

            ComboBox comboBox = new ComboBox() { Left = 20, Top = 20, Width = 240, DropDownStyle = ComboBoxStyle.DropDownList };

            comboBox.DataSource = users;

            Button ok = new Button()
            {
                Text = "OK",
                Left = 160,
                Width = 100,
                Top = 60,
                DialogResult = DialogResult.OK,
            };

            form.Controls.Add(comboBox);
            form.Controls.Add(ok);
            form.AcceptButton = ok;

            if (form.ShowDialog() == DialogResult.OK)
            {
                var selectedUser = comboBox.SelectedItem as User;
                return selectedUser?.UserId;
            }
            return null;
        }
        private void btnGrant_Click(object sender, EventArgs e)
        {
            if (listFiles.SelectedItem is FileMetadata file)
            {
                var viewers = _controller.GetViewerUsers();

                string viewerId = ShowUserSelection(viewers);

                if (!string.IsNullOrEmpty(viewerId))
                {
                    _controller.GrantFileAccess(_currentUser, viewerId, file.FileId);
                }
            }
        }

        private void btnRegisterViewer_Click(object sender, EventArgs e)
        {
            string username = Microsoft.VisualBasic.Interaction.InputBox("Enter Viewer Username:");
            string password = Microsoft.VisualBasic.Interaction.InputBox("Enter Viewer Password:");

            _controller.RegisterViewer(_currentUser, username, password);

            MessageBox.Show("Viewer registered !");
        }

        private void btnRemoveViewer_Click(object sender, EventArgs e)
        {
            var viewers = _controller.GetViewerUsers();
            string viewerId = ShowUserSelection(viewers);
            if (!string.IsNullOrEmpty(viewerId))
            {
                _controller.DeleteViewer(_currentUser, viewerId);

                var updatedViewers = _controller.GetViewerUsers();

                if (!updatedViewers.Exists(v => v.UserId == viewerId))
                {
                    MessageBox.Show("Viewer removed !");
                }
                else
                {
                    MessageBox.Show("Failed to remove Viewer !");
                }    
            }

        }

        private void btnManagerUsers_Click(object sender, EventArgs e)
        {
            var users = _controller.GetAllUsers(_currentUser);
            StringBuilder sb = new StringBuilder();

            foreach (var user in users)
            {
                sb.AppendLine($"ID: {user.UserId} - Username: {user.Username} - {(user is AdminUser ? "Admin" : "Viewer")}");
            }

            MessageBox.Show(sb.ToString(), "All Users");
        }
    }
}
