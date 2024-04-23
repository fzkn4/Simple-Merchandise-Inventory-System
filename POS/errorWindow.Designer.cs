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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(errorWindow));
            close = new Guna.UI2.WinForms.Guna2Button();
            panel1 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
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
            close.Location = new Point(219, 5);
            close.Name = "close";
            close.ShadowDecoration.CustomizableEdges = customizableEdges2;
            close.Size = new Size(28, 26);
            close.TabIndex = 8;
            close.Text = "x";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(227, 100);
            panel1.TabIndex = 9;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(224, 130);
            label1.TabIndex = 1;
            label1.Text = resources.GetString("label1.Text");
            // 
            // errorWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 73, 85);
            ClientSize = new Size(251, 176);
            Controls.Add(panel1);
            Controls.Add(close);
            FormBorderStyle = FormBorderStyle.None;
            Name = "errorWindow";
            Text = "errorWindow";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button close;
        private Panel panel1;
        private Label label1;
    }
}