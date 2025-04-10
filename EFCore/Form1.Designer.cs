namespace EFCore
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            signUpBttn = new Button();
            textBoxPassword = new TextBox();
            textBoxLogin = new TextBox();
            passwordTxt = new Label();
            loginTxt = new Label();
            label1 = new Label();
            signInBttn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(238, 238, 238);
            panel1.Controls.Add(signInBttn);
            panel1.Controls.Add(signUpBttn);
            panel1.Controls.Add(textBoxPassword);
            panel1.Controls.Add(textBoxLogin);
            panel1.Controls.Add(passwordTxt);
            panel1.Controls.Add(loginTxt);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(180, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(473, 514);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // signUpBttn
            // 
            signUpBttn.BackColor = Color.FromArgb(255, 130, 163);
            signUpBttn.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 204);
            signUpBttn.ForeColor = Color.White;
            signUpBttn.Location = new Point(165, 401);
            signUpBttn.Name = "signUpBttn";
            signUpBttn.Size = new Size(145, 61);
            signUpBttn.TabIndex = 5;
            signUpBttn.Text = "sign up";
            signUpBttn.UseVisualStyleBackColor = false;
            signUpBttn.Click += signUpBttn_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(213, 241);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(189, 30);
            textBoxPassword.TabIndex = 4;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(213, 180);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(189, 30);
            textBoxLogin.TabIndex = 3;
            // 
            // passwordTxt
            // 
            passwordTxt.AutoSize = true;
            passwordTxt.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 204);
            passwordTxt.ForeColor = Color.FromArgb(32, 4, 68);
            passwordTxt.Location = new Point(70, 241);
            passwordTxt.Name = "passwordTxt";
            passwordTxt.Size = new Size(105, 30);
            passwordTxt.TabIndex = 2;
            passwordTxt.Text = "password";
            // 
            // loginTxt
            // 
            loginTxt.AutoSize = true;
            loginTxt.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 204);
            loginTxt.ForeColor = Color.FromArgb(32, 4, 68);
            loginTxt.Location = new Point(70, 180);
            loginTxt.Name = "loginTxt";
            loginTxt.Size = new Size(61, 30);
            loginTxt.TabIndex = 1;
            loginTxt.Text = "login";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18.3272724F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.FromArgb(32, 4, 68);
            label1.Location = new Point(117, 52);
            label1.Name = "label1";
            label1.Size = new Size(227, 38);
            label1.TabIndex = 0;
            label1.Text = "Welcome to app";
            label1.Click += label1_Click;
            // 
            // signInBttn
            // 
            signInBttn.BackColor = Color.FromArgb(255, 130, 163);
            signInBttn.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 204);
            signInBttn.ForeColor = Color.White;
            signInBttn.Location = new Point(165, 315);
            signInBttn.Name = "signInBttn";
            signInBttn.Size = new Size(145, 61);
            signInBttn.TabIndex = 6;
            signInBttn.Text = "sign in";
            signInBttn.UseVisualStyleBackColor = false;
            signInBttn.Click += signInBttn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 4, 68);
            ClientSize = new Size(843, 742);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button signUpBttn;
        private TextBox textBoxPassword;
        private TextBox textBoxLogin;
        private Label passwordTxt;
        private Label loginTxt;
        private Button signInBttn;
    }
}
