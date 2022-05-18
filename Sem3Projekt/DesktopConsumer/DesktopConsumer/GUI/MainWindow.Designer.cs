using System.Configuration;
using DesktopConsumer.Controller;

namespace DesktopConsumer.GUI
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.User_LoggedIn = new System.Windows.Forms.Label();
            this.LoggedIn_Infolbl = new System.Windows.Forms.Label();
            this.UserMnuBtn = new System.Windows.Forms.Button();
            this.TournamentMnuBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContentPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.User_LoggedIn);
            this.panel1.Controls.Add(this.LoggedIn_Infolbl);
            this.panel1.Controls.Add(this.UserMnuBtn);
            this.panel1.Controls.Add(this.TournamentMnuBtn);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 55);
            this.panel1.TabIndex = 0;
            // 
            // User_LoggedIn
            // 
            this.User_LoggedIn.AutoSize = true;
            this.User_LoggedIn.Location = new System.Drawing.Point(935, 21);
            this.User_LoggedIn.Name = "User_LoggedIn";
            this.User_LoggedIn.Size = new System.Drawing.Size(0, 15);
            this.User_LoggedIn.TabIndex = 5;
            // 
            // LoggedIn_Infolbl
            // 
            this.LoggedIn_Infolbl.AutoSize = true;
            this.LoggedIn_Infolbl.Location = new System.Drawing.Point(845, 21);
            this.LoggedIn_Infolbl.Name = "LoggedIn_Infolbl";
            this.LoggedIn_Infolbl.Size = new System.Drawing.Size(77, 15);
            this.LoggedIn_Infolbl.TabIndex = 4;
            this.LoggedIn_Infolbl.Text = "Logged in as:";
            // 
            // UserMnuBtn
            // 
            this.UserMnuBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.UserMnuBtn.Location = new System.Drawing.Point(131, 24);
            this.UserMnuBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserMnuBtn.Name = "UserMnuBtn";
            this.UserMnuBtn.Size = new System.Drawing.Size(131, 31);
            this.UserMnuBtn.TabIndex = 1;
            this.UserMnuBtn.Text = "Brugermenu";
            this.UserMnuBtn.UseVisualStyleBackColor = true;
            this.UserMnuBtn.Click += new System.EventHandler(this.UserMnuBtn_Click);
            // 
            // TournamentMnuBtn
            // 
            this.TournamentMnuBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TournamentMnuBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.TournamentMnuBtn.Location = new System.Drawing.Point(0, 24);
            this.TournamentMnuBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TournamentMnuBtn.Name = "TournamentMnuBtn";
            this.TournamentMnuBtn.Size = new System.Drawing.Size(131, 31);
            this.TournamentMnuBtn.TabIndex = 0;
            this.TournamentMnuBtn.Text = "Turneringsmenu";
            this.TournamentMnuBtn.UseVisualStyleBackColor = false;
            this.TournamentMnuBtn.Click += new System.EventHandler(this.TournamentMnuBtn_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1024, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smtToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingToolStripMenuItem.Text = "Settings";
            // 
            // smtToolStripMenuItem
            // 
            this.smtToolStripMenuItem.Name = "smtToolStripMenuItem";
            this.smtToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.smtToolStripMenuItem.Text = "Login";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // ContentPanel
            // 
            this.ContentPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(5, 59);
            this.ContentPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(1024, 502);
            this.ContentPanel.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 565);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(440, 235);
            this.Name = "MainWindow";
            this.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Text = "Tournament Manager v1";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BindingSource bindingSource1;
        private Panel panel1;
        private Button UserMnuBtn;
        private Button TournamentMnuBtn;
        private Panel ContentPanel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem smtToolStripMenuItem;
        private Label User_LoggedIn;
        private Label LoggedIn_Infolbl;
    }
}