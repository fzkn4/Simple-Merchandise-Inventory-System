namespace POS
{
    partial class errorWindow
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            close = new Guna.UI2.WinForms.Guna2Button();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // close
            // 
            close.BackColor = Color.FromArgb(52, 73, 85);
            close.BorderRadius = 10;
            close.CheckedState.FillColor = Color.IndianRed;
            close.CustomizableEdges = customizableEdges3;
            close.DisabledState.BorderColor = Color.DarkGray;
            close.DisabledState.CustomBorderColor = Color.DarkGray;
            close.DisabledState.FillColor = Color.FromArgb(141, 141, 141);
            close.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            close.FillColor = Color.FromArgb(52, 73, 85);
            close.FocusedColor = Color.IndianRed;
            close.Font = new Font("Segoe UI", 9F);
            close.ForeColor = Color.White;
            close.Location = new Point(213, 5);
            close.Name = "close";
            close.ShadowDecoration.CustomizableEdges = customizableEdges4;
            close.Size = new Size(34, 36);
            close.TabIndex = 8;
            close.Text = "x";
            close.Click += close_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(227, 74);
            panel1.TabIndex = 9;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(206, 74);
            label1.TabIndex = 1;
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(17, 13);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 10;
            label2.Text = "Error";
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
            guna2Button1.Location = new Point(94, 131);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Button1.Size = new Size(64, 24);
            guna2Button1.TabIndex = 11;
            guna2Button1.Text = "Close";
            // 
            // errorWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 73, 85);
            ClientSize = new Size(251, 176);
            Controls.Add(guna2Button1);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(close);
            FormBorderStyle = FormBorderStyle.None;
            Name = "errorWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventory System";
            Load += errorWindow_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button close;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}