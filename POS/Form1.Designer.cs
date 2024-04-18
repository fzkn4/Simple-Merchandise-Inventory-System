namespace POS
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            close = new Guna.UI2.WinForms.Guna2Button();
            guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            password = new Guna.UI2.WinForms.Guna2TextBox();
            username = new Guna.UI2.WinForms.Guna2TextBox();
            pictureBox1 = new PictureBox();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // close
            // 
            close.BackColor = Color.FromArgb(52, 73, 85);
            close.BorderRadius = 10;
            close.CheckedState.FillColor = Color.IndianRed;
            close.CustomizableEdges = customizableEdges1;
            close.DisabledState.BorderColor = Color.DarkGray;
            close.DisabledState.CustomBorderColor = Color.DarkGray;
            close.DisabledState.FillColor = Color.FromArgb(141, 141, 141);
            close.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            close.FillColor = Color.FromArgb(52, 73, 85);
            close.FocusedColor = Color.IndianRed;
            close.Font = new Font("Segoe UI", 9F);
            close.ForeColor = Color.White;
            close.Location = new Point(258, 2);
            close.Name = "close";
            close.ShadowDecoration.CustomizableEdges = customizableEdges2;
            close.Size = new Size(41, 33);
            close.TabIndex = 6;
            close.Text = "x";
            close.Click += close_Click;
            // 
            // guna2ShadowForm1
            // 
            guna2ShadowForm1.ShadowColor = Color.IndianRed;
            guna2ShadowForm1.TargetForm = this;
            // 
            // password
            // 
            password.BorderColor = Color.FromArgb(66, 90, 105);
            password.BorderRadius = 6;
            password.BorderThickness = 2;
            password.CustomizableEdges = customizableEdges9;
            password.DefaultText = "";
            password.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            password.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            password.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            password.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            password.FillColor = Color.FromArgb(66, 90, 105);
            password.FocusedState.BorderColor = Color.IndianRed;
            password.Font = new Font("Segoe UI", 9F);
            password.HoverState.BorderColor = Color.FromArgb(193, 200, 207);
            password.IconLeft = (Image)resources.GetObject("password.IconLeft");
            password.IconLeftOffset = new Point(5, 0);
            password.IconLeftSize = new Size(25, 25);
            password.Location = new Point(51, 190);
            password.Name = "password";
            password.PasswordChar = '●';
            password.PlaceholderText = "";
            password.SelectedText = "";
            password.ShadowDecoration.CustomizableEdges = customizableEdges10;
            password.Size = new Size(202, 45);
            password.TabIndex = 2;
            password.UseSystemPasswordChar = true;
            password.KeyDown += keyDown;
            // 
            // username
            // 
            username.BorderColor = Color.FromArgb(66, 90, 105);
            username.BorderRadius = 6;
            username.BorderThickness = 2;
            username.CustomizableEdges = customizableEdges7;
            username.DefaultText = "";
            username.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            username.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            username.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            username.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            username.FillColor = Color.FromArgb(66, 90, 105);
            username.FocusedState.BorderColor = Color.IndianRed;
            username.Font = new Font("Segoe UI", 9F);
            username.HoverState.BorderColor = Color.FromArgb(193, 200, 207);
            username.IconLeft = (Image)resources.GetObject("username.IconLeft");
            username.IconLeftOffset = new Point(5, 0);
            username.IconLeftSize = new Size(25, 25);
            username.Location = new Point(51, 128);
            username.Name = "username";
            username.PasswordChar = '\0';
            username.PlaceholderText = "";
            username.SelectedText = "";
            username.ShadowDecoration.CustomizableEdges = customizableEdges8;
            username.Size = new Size(202, 45);
            username.TabIndex = 1;
            username.KeyDown += keyDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(94, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(131, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // guna2Button1
            // 
            guna2Button1.BackColor = Color.FromArgb(52, 73, 85);
            guna2Button1.BorderRadius = 6;
            guna2Button1.CustomizableEdges = customizableEdges5;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(66, 90, 105);
            guna2Button1.FocusedColor = Color.IndianRed;
            guna2Button1.Font = new Font("Segoe UI", 9F);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(51, 255);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Button1.Size = new Size(98, 40);
            guna2Button1.TabIndex = 3;
            guna2Button1.Text = "Login";
            guna2Button1.Click += guna2Button1_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            label1.ForeColor = Color.White;
            label1.Location = new Point(156, 270);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 4;
            label1.Text = "Forgot password?";
            // 
            // guna2Button2
            // 
            guna2Button2.BackColor = Color.FromArgb(52, 73, 85);
            guna2Button2.CustomizableEdges = customizableEdges3;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.Dock = DockStyle.Bottom;
            guna2Button2.FillColor = Color.FromArgb(66, 90, 105);
            guna2Button2.FocusedColor = Color.IndianRed;
            guna2Button2.Font = new Font("Segoe UI", 9F);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Location = new Point(0, 313);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button2.Size = new Size(302, 40);
            guna2Button2.TabIndex = 5;
            guna2Button2.Text = "Register";
            guna2Button2.Click += guna2Button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 73, 85);
            ClientSize = new Size(302, 353);
            Controls.Add(guna2Button2);
            Controls.Add(label1);
            Controls.Add(guna2Button1);
            Controls.Add(pictureBox1);
            Controls.Add(username);
            Controls.Add(password);
            Controls.Add(close);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button close;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2TextBox password;
        private Guna.UI2.WinForms.Guna2TextBox username;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}
