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
            btnDelete = new Button();
            label3 = new Label();
            panel1 = new Panel();
            btnUpload = new Button();
            btnManagerUsers = new Button();
            btnRegisterViewer = new Button();
            btnRemoveViewer = new Button();
            btnGrant = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // listFiles
            // 
            listFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listFiles.FormattingEnabled = true;
            listFiles.Location = new Point(9, 119);
            listFiles.Name = "listFiles";
            listFiles.Size = new Size(1509, 349);
            listFiles.TabIndex = 0;
            listFiles.SelectedIndexChanged += listFiles_SelectedIndexChanged;
            // 
            // btnView
            // 
            btnView.Anchor = AnchorStyles.Top;
            btnView.Location = new Point(587, 3);
            btnView.Name = "btnView";
            btnView.Size = new Size(150, 45);
            btnView.TabIndex = 2;
            btnView.Text = "VIEW";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // btnDownload
            // 
            btnDownload.Anchor = AnchorStyles.Top;
            btnDownload.Location = new Point(779, 3);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(150, 45);
            btnDownload.TabIndex = 3;
            btnDownload.Text = "DOWNLOAD";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top;
            btnDelete.Location = new Point(971, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 45);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(9, 25);
            label3.Name = "label3";
            label3.Size = new Size(1509, 45);
            label3.TabIndex = 12;
            label3.Text = "SECURE FILE VAULT";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(btnGrant);
            panel1.Controls.Add(btnUpload);
            panel1.Controls.Add(btnRemoveViewer);
            panel1.Controls.Add(btnView);
            panel1.Controls.Add(btnManagerUsers);
            panel1.Controls.Add(btnDownload);
            panel1.Controls.Add(btnRegisterViewer);
            panel1.Controls.Add(btnDelete);
            panel1.Location = new Point(9, 481);
            panel1.Name = "panel1";
            panel1.Size = new Size(1509, 118);
            panel1.TabIndex = 13;
            // 
            // btnUpload
            // 
            btnUpload.Anchor = AnchorStyles.Top;
            btnUpload.Location = new Point(395, 3);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(150, 45);
            btnUpload.TabIndex = 1;
            btnUpload.Text = "UPLOAD";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnManagerUsers
            // 
            btnManagerUsers.Anchor = AnchorStyles.Top;
            btnManagerUsers.Location = new Point(971, 70);
            btnManagerUsers.Name = "btnManagerUsers";
            btnManagerUsers.Size = new Size(200, 45);
            btnManagerUsers.TabIndex = 8;
            btnManagerUsers.Text = "MANAGE USERS";
            btnManagerUsers.UseVisualStyleBackColor = true;
            btnManagerUsers.Click += btnManagerUsers_Click;
            // 
            // btnRegisterViewer
            // 
            btnRegisterViewer.Anchor = AnchorStyles.Top;
            btnRegisterViewer.Location = new Point(765, 70);
            btnRegisterViewer.Name = "btnRegisterViewer";
            btnRegisterViewer.Size = new Size(200, 45);
            btnRegisterViewer.TabIndex = 7;
            btnRegisterViewer.Text = "REGISTER VIEWER";
            btnRegisterViewer.UseVisualStyleBackColor = true;
            btnRegisterViewer.Click += btnRegisterViewer_Click;
            // 
            // btnRemoveViewer
            // 
            btnRemoveViewer.Anchor = AnchorStyles.Top;
            btnRemoveViewer.Location = new Point(551, 70);
            btnRemoveViewer.Name = "btnRemoveViewer";
            btnRemoveViewer.Size = new Size(200, 45);
            btnRemoveViewer.TabIndex = 9;
            btnRemoveViewer.Text = "REMOVE VIEWER";
            btnRemoveViewer.UseVisualStyleBackColor = true;
            btnRemoveViewer.Click += btnRemoveViewer_Click;
            // 
            // btnGrant
            // 
            btnGrant.Anchor = AnchorStyles.Top;
            btnGrant.Location = new Point(345, 70);
            btnGrant.Name = "btnGrant";
            btnGrant.Size = new Size(200, 45);
            btnGrant.TabIndex = 5;
            btnGrant.Text = "GRANT PERMISSION";
            btnGrant.UseVisualStyleBackColor = true;
            btnGrant.Click += btnGrant_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1533, 611);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(listFiles);
            ForeColor = Color.DarkSlateGray;
            MinimumSize = new Size(1000, 650);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Secure File Vault";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox listFiles;
        private Button btnView;
        private Button btnDownload;
        private Button btnDelete;
        private Label label3;
        private Panel panel1;
        private Button btnGrant;
        private Button btnUpload;
        private Button btnRemoveViewer;
        private Button btnManagerUsers;
        private Button btnRegisterViewer;
    }
}