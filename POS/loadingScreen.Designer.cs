﻿namespace POS
{
    partial class loadingScreen
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loadingScreen));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            progressbar = new Guna.UI2.WinForms.Guna2ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(11, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(213, 218);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 204);
            label1.Name = "label1";
            label1.Size = new Size(213, 18);
            label1.TabIndex = 1;
            label1.Text = "value";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // progressbar
            // 
            progressbar.CustomizableEdges = customizableEdges1;
            progressbar.FillColor = Color.FromArgb(52, 73, 85);
            progressbar.Location = new Point(11, 225);
            progressbar.Name = "progressbar";
            progressbar.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.Solid;
            progressbar.ProgressColor = Color.IndianRed;
            progressbar.ProgressColor2 = Color.IndianRed;
            progressbar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            progressbar.Size = new Size(213, 11);
            progressbar.TabIndex = 2;
            progressbar.Text = "guna2ProgressBar1";
            progressbar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // loadingScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 73, 85);
            ClientSize = new Size(236, 260);
            Controls.Add(label1);
            Controls.Add(progressbar);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "loadingScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "loadingScreen";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2ProgressBar progressbar;
        private System.Windows.Forms.Timer timer1;
    }
}