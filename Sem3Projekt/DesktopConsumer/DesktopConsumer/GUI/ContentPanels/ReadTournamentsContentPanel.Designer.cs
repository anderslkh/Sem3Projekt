namespace DesktopConsumer.GUI.ContentPanels {
    partial class ReadTournamentsContentPanel {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.TournamentId = new System.Windows.Forms.ColumnHeader();
            this.TournamentName = new System.Windows.Forms.ColumnHeader();
            this.TimeOfEvent = new System.Windows.Forms.ColumnHeader();
            this.RegistrationDeadline = new System.Windows.Forms.ColumnHeader();
            this.EnrolledParticipants = new System.Windows.Forms.ColumnHeader();
            this.MaxParticipants = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 52);
            this.panel1.TabIndex = 0;
            // 
            // searchBar
            // 
            this.searchBar.Location = new System.Drawing.Point(12, 12);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(246, 23);
            this.searchBar.TabIndex = 0;
            this.searchBar.TextChanged += new System.EventHandler(this.searchBar_TextChanged);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TournamentId,
            this.TournamentName,
            this.TimeOfEvent,
            this.RegistrationDeadline,
            this.EnrolledParticipants,
            this.MaxParticipants});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            listViewItem1.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(700, 286);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // TournamentId
            // 
            this.TournamentId.Text = "ID";
            // 
            // TournamentName
            // 
            this.TournamentName.Text = "Turneringsnavn";
            this.TournamentName.Width = 100;
            // 
            // TimeOfEvent
            // 
            this.TimeOfEvent.Text = "Afholdelsestidspunkt";
            this.TimeOfEvent.Width = 130;
            // 
            // RegistrationDeadline
            // 
            this.RegistrationDeadline.Text = "Tilmeldingsfrist";
            this.RegistrationDeadline.Width = 100;
            // 
            // EnrolledParticipants
            // 
            this.EnrolledParticipants.DisplayIndex = 5;
            this.EnrolledParticipants.Text = "Antal tilmeldte";
            this.EnrolledParticipants.Width = 90;
            // 
            // MaxParticipants
            // 
            this.MaxParticipants.DisplayIndex = 4;
            this.MaxParticipants.Text = "Maximum deltagere";
            this.MaxParticipants.Width = 120;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 286);
            this.panel2.TabIndex = 1;
            // 
            // ReadTournamentsContentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReadTournamentsContentPanel";
            this.Text = "ReadTournamentsContentPanel";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private ListView listView1;
        private ColumnHeader TournamentName;
        private ColumnHeader TimeOfEvent;
        private ColumnHeader MaxParticipants;
        private ColumnHeader EnrolledParticipants;
        private ColumnHeader TournamentId;
        private ColumnHeader RegistrationDeadline;
        private TextBox searchBar;
    }
}