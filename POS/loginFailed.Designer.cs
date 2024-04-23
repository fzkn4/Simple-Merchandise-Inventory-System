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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            close = new Guna.UI2.WinForms.Guna2Button();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            displayMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // close
            // 
            close.BackColor = Color.FromArgb(52, 73, 85);
            close.BorderRadius = 10;
            close.CheckedState.FillColor = Color.IndianRed;
            close.CustomizableEdges = customizableEdges5;
            close.DisabledState.BorderColor = Color.DarkGray;
            close.DisabledState.CustomBorderColor = Color.DarkGray;
            close.DisabledState.FillColor = Color.FromArgb(141, 141, 141);
            close.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            close.FillColor = Color.FromArgb(52, 73, 85);
            close.FocusedColor = Color.IndianRed;
            close.Font = new Font("Segoe UI", 9F);
            close.ForeColor = Color.White;
            close.Location = new Point(156, 3);
            close.Name = "close";
            close.ShadowDecoration.CustomizableEdges = customizableEdges6;
            close.Size = new Size(28, 26);
            close.TabIndex = 7;
            close.Text = "x";
            close.Click += close_Click;
            // 
            // guna2Button1
            // 
            guna2Button1.BackColor = Color.FromArgb(52, 73, 85);
            guna2Button1.BorderRadius = 6;
            guna2Button1.CustomizableEdges = customizableEdges7;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(66, 90, 105);
            guna2Button1.FocusedColor = Color.IndianRed;
            guna2Button1.Font = new Font("Segoe UI", 9F);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(61, 54);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Button1.Size = new Size(64, 24);
            guna2Button1.TabIndex = 8;
            guna2Button1.Text = "Close";
            guna2Button1.Click += guna2Button1_Click;
            guna2Button1.KeyDown += key_down;
            // 
            // displayMessage
            // 
            displayMessage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            displayMessage.AutoSize = false;
            displayMessage.BackColor = Color.Transparent;
            displayMessage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            displayMessage.ForeColor = Color.White;
            displayMessage.Location = new Point(0, 26);
            displayMessage.Name = "displayMessage";
            displayMessage.Size = new Size(184, 22);
            displayMessage.TabIndex = 9;
            displayMessage.Text = "Display Message";
            displayMessage.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // loginFailed
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(52, 73, 85);
            ClientSize = new Size(186, 90);
            Controls.Add(displayMessage);
            Controls.Add(guna2Button1);
            Controls.Add(close);
            FormBorderStyle = FormBorderStyle.None;
            Name = "loginFailed";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "loginFailed";
            Load += loginFailed_Load;
            KeyDown += key_down;
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button close;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2HtmlLabel displayMessage;
    }
}