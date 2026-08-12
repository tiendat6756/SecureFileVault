namespace SecureFileVault
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listFiles = new ListBox();
            btnView = new Button();
            btnDownload = new Button();
            btnUpload = new Button();
            btnGrant = new Button();
            btnRegisterViewer = new Button();
            btnDelete = new Button();
            btnManagerUsers = new Button();
            btnRemoveViewer = new Button();
            SuspendLayout();
            // 
            // listFiles
            // 
            listFiles.FormattingEnabled = true;
            listFiles.Location = new Point(12, 12);
            listFiles.Name = "listFiles";
            listFiles.Size = new Size(1558, 409);
            listFiles.TabIndex = 0;
            // 
            // btnView
            // 
            btnView.Location = new Point(204, 427);
            btnView.Name = "btnView";
            btnView.Size = new Size(186, 65);
            btnView.TabIndex = 2;
            btnView.Text = "VIEW";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(396, 427);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(186, 65);
            btnDownload.TabIndex = 3;
            btnDownload.Text = "DOWNLOAD";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(12, 427);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(186, 65);
            btnUpload.TabIndex = 1;
            btnUpload.Text = "UPLOAD";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnGrant
            // 
            btnGrant.Location = new Point(808, 427);
            btnGrant.Name = "btnGrant";
            btnGrant.Size = new Size(186, 65);
            btnGrant.TabIndex = 5;
            btnGrant.Text = "GRANT PERMISSION";
            btnGrant.UseVisualStyleBackColor = true;
            btnGrant.Click += btnGrant_Click;
            // 
            // btnRegisterViewer
            // 
            btnRegisterViewer.Location = new Point(1192, 427);
            btnRegisterViewer.Name = "btnRegisterViewer";
            btnRegisterViewer.Size = new Size(186, 65);
            btnRegisterViewer.TabIndex = 7;
            btnRegisterViewer.Text = "REGISTER VIEWER";
            btnRegisterViewer.UseVisualStyleBackColor = true;
            btnRegisterViewer.Click += btnRegisterViewer_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(588, 427);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(186, 65);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnManagerUsers
            // 
            btnManagerUsers.Location = new Point(1384, 427);
            btnManagerUsers.Name = "btnManagerUsers";
            btnManagerUsers.Size = new Size(186, 65);
            btnManagerUsers.TabIndex = 8;
            btnManagerUsers.Text = "MANAGE USERS";
            btnManagerUsers.UseVisualStyleBackColor = true;
            btnManagerUsers.Click += btnManagerUsers_Click;
            // 
            // btnRemoveViewer
            // 
            btnRemoveViewer.Location = new Point(1000, 427);
            btnRemoveViewer.Name = "btnRemoveViewer";
            btnRemoveViewer.Size = new Size(186, 65);
            btnRemoveViewer.TabIndex = 9;
            btnRemoveViewer.Text = "REMOVE VIEWER";
            btnRemoveViewer.UseVisualStyleBackColor = true;
            btnRemoveViewer.Click += btnRemoveViewer_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 504);
            Controls.Add(btnRemoveViewer);
            Controls.Add(btnManagerUsers);
            Controls.Add(btnRegisterViewer);
            Controls.Add(btnGrant);
            Controls.Add(btnDelete);
            Controls.Add(btnDownload);
            Controls.Add(btnView);
            Controls.Add(btnUpload);
            Controls.Add(listFiles);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listFiles;
        private Button btnView;
        private Button btnDownload;
        private Button btnUpload;
        private Button btnGrant;
        private Button btnRegisterViewer;
        private Button btnDelete;
        private Button btnManagerUsers;
        private Button btnRemoveViewer;
    }
}