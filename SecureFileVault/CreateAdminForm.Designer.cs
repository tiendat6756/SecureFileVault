namespace SecureFileVault
{
    partial class CreateAdminForm
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
            btnCreate = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtConfirmPassword = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.Top;
            btnCreate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreate.Location = new Point(701, 381);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(100, 32);
            btnCreate.TabIndex = 9;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top;
            txtPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(652, 261);
            txtPassword.Name = "txtPassword";
            txtPassword.ShortcutsEnabled = false;
            txtPassword.Size = new Size(200, 25);
            txtPassword.TabIndex = 8;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top;
            txtUsername.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(652, 200);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 25);
            txtUsername.TabIndex = 7;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(652, 243);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 6;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(652, 182);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 5;
            label1.Text = "Username";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(595, 95);
            label3.Name = "label3";
            label3.Size = new Size(311, 45);
            label3.TabIndex = 10;
            label3.Text = "SECURE FILE VAULT";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click_1;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(652, 140);
            label4.Name = "label4";
            label4.Size = new Size(200, 30);
            label4.TabIndex = 11;
            label4.Text = "Create Administrator";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Anchor = AnchorStyles.Top;
            txtConfirmPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassword.Location = new Point(652, 336);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(200, 25);
            txtConfirmPassword.TabIndex = 12;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Location = new Point(652, 318);
            label5.Name = "label5";
            label5.Size = new Size(104, 15);
            label5.TabIndex = 13;
            label5.Text = "Confirm Password";
            // 
            // CreateAdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1517, 791);
            Controls.Add(label5);
            Controls.Add(txtConfirmPassword);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnCreate);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.DarkSlateGray;
            MinimumSize = new Size(600, 450);
            Name = "CreateAdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Administrator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreate;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox txtConfirmPassword;
        private Label label5;
    }
}