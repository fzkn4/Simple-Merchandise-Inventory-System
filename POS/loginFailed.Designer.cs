namespace POS
{
    partial class loginFailed
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            close = new Guna.UI2.WinForms.Guna2Button();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(49, 23);
            label1.Name = "label1";
            label1.Size = new Size(129, 30);
            label1.TabIndex = 0;
            label1.Text = "Login Failed!";
            label1.Click += label1_Click;
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
            close.Location = new Point(184, 1);
            close.Name = "close";
            close.ShadowDecoration.CustomizableEdges = customizableEdges2;
            close.Size = new Size(41, 33);
            close.TabIndex = 7;
            close.Text = "x";
            close.Click += close_Click;
            // 
            // guna2Button1
            // 
            guna2Button1.BackColor = Color.FromArgb(52, 73, 85);
            guna2Button1.BorderRadius = 6;
            guna2Button1.CustomizableEdges = customizableEdges3;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(66, 90, 105);
            guna2Button1.FocusedColor = Color.IndianRed;
            guna2Button1.Font = new Font("Segoe UI", 9F);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(66, 60);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button1.Size = new Size(90, 31);
            guna2Button1.TabIndex = 8;
            guna2Button1.Text = "Close";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // loginFailed
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 73, 85);
            ClientSize = new Size(227, 115);
            Controls.Add(guna2Button1);
            Controls.Add(close);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "loginFailed";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "loginFailed";
            Load += loginFailed_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2Button close;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}