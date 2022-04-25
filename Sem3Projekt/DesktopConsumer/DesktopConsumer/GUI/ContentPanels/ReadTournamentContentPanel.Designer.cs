namespace DesktopConsumer.GUI.ContentPanels
{
    partial class ReadTournamentContentPanel
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
            this.txtBirthdate = new System.Windows.Forms.TextBox();
            this.lblMinNoOfParticipant = new System.Windows.Forms.Label();
            this.lblRegristrationDeadline = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTimeOfEvent = new System.Windows.Forms.TextBox();
            this.txtInsertTournamentName = new System.Windows.Forms.TextBox();
            this.lblTimeOfEvent = new System.Windows.Forms.Label();
            this.lblTournamentName = new System.Windows.Forms.Label();
            this.txtMaxNoOfParticipant = new System.Windows.Forms.TextBox();
            this.lblMaxNoOfParticipant = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBirthdate
            // 
            this.txtBirthdate.Location = new System.Drawing.Point(206, 280);
            this.txtBirthdate.Name = "txtBirthdate";
            this.txtBirthdate.ReadOnly = true;
            this.txtBirthdate.Size = new System.Drawing.Size(344, 27);
            this.txtBirthdate.TabIndex = 16;
            // 
            // lblMinNoOfParticipant
            // 
            this.lblMinNoOfParticipant.AutoSize = true;
            this.lblMinNoOfParticipant.Location = new System.Drawing.Point(206, 257);
            this.lblMinNoOfParticipant.Name = "lblMinNoOfParticipant";
            this.lblMinNoOfParticipant.Size = new System.Drawing.Size(127, 20);
            this.lblMinNoOfParticipant.TabIndex = 15;
            this.lblMinNoOfParticipant.Text = "Mininum deltager";
            // 
            // lblRegristrationDeadline
            // 
            this.lblRegristrationDeadline.AutoSize = true;
            this.lblRegristrationDeadline.Location = new System.Drawing.Point(206, 182);
            this.lblRegristrationDeadline.Name = "lblRegristrationDeadline";
            this.lblRegristrationDeadline.Size = new System.Drawing.Size(111, 20);
            this.lblRegristrationDeadline.TabIndex = 14;
            this.lblRegristrationDeadline.Text = "Tilmeldingsfrist";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(206, 205);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(344, 27);
            this.txtEmail.TabIndex = 13;
            // 
            // txtTimeOfEvent
            // 
            this.txtTimeOfEvent.Location = new System.Drawing.Point(206, 131);
            this.txtTimeOfEvent.Name = "txtTimeOfEvent";
            this.txtTimeOfEvent.ReadOnly = true;
            this.txtTimeOfEvent.Size = new System.Drawing.Size(344, 27);
            this.txtTimeOfEvent.TabIndex = 12;
            // 
            // txtInsertTournamentName
            // 
            this.txtInsertTournamentName.Location = new System.Drawing.Point(206, 57);
            this.txtInsertTournamentName.Name = "txtInsertTournamentName";
            this.txtInsertTournamentName.ReadOnly = true;
            this.txtInsertTournamentName.Size = new System.Drawing.Size(344, 27);
            this.txtInsertTournamentName.TabIndex = 11;
            // 
            // lblTimeOfEvent
            // 
            this.lblTimeOfEvent.AutoSize = true;
            this.lblTimeOfEvent.Location = new System.Drawing.Point(206, 108);
            this.lblTimeOfEvent.Name = "lblTimeOfEvent";
            this.lblTimeOfEvent.Size = new System.Drawing.Size(73, 20);
            this.lblTimeOfEvent.TabIndex = 10;
            this.lblTimeOfEvent.Text = "Tidspunkt";
            // 
            // lblTournamentName
            // 
            this.lblTournamentName.AutoSize = true;
            this.lblTournamentName.Location = new System.Drawing.Point(206, 34);
            this.lblTournamentName.Name = "lblTournamentName";
            this.lblTournamentName.Size = new System.Drawing.Size(109, 20);
            this.lblTournamentName.TabIndex = 9;
            this.lblTournamentName.Text = "Turneringsnavn";
            // 
            // txtMaxNoOfParticipant
            // 
            this.txtMaxNoOfParticipant.Location = new System.Drawing.Point(206, 355);
            this.txtMaxNoOfParticipant.Name = "txtMaxNoOfParticipant";
            this.txtMaxNoOfParticipant.ReadOnly = true;
            this.txtMaxNoOfParticipant.Size = new System.Drawing.Size(344, 27);
            this.txtMaxNoOfParticipant.TabIndex = 18;
            // 
            // lblMaxNoOfParticipant
            // 
            this.lblMaxNoOfParticipant.AutoSize = true;
            this.lblMaxNoOfParticipant.Location = new System.Drawing.Point(206, 332);
            this.lblMaxNoOfParticipant.Name = "lblMaxNoOfParticipant";
            this.lblMaxNoOfParticipant.Size = new System.Drawing.Size(135, 20);
            this.lblMaxNoOfParticipant.TabIndex = 17;
            this.lblMaxNoOfParticipant.Text = "Maximum deltager";
            // 
            // ReadTournamentContentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMaxNoOfParticipant);
            this.Controls.Add(this.lblMaxNoOfParticipant);
            this.Controls.Add(this.txtBirthdate);
            this.Controls.Add(this.lblMinNoOfParticipant);
            this.Controls.Add(this.lblRegristrationDeadline);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTimeOfEvent);
            this.Controls.Add(this.txtInsertTournamentName);
            this.Controls.Add(this.lblTimeOfEvent);
            this.Controls.Add(this.lblTournamentName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReadTournamentContentPanel";
            this.Text = "ReadTournamentContentPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtBirthdate;
        private Label lblMinNoOfParticipant;
        private Label lblRegristrationDeadline;
        private TextBox txtEmail;
        private TextBox txtTimeOfEvent;
        private TextBox txtInsertTournamentName;
        private Label lblTimeOfEvent;
        private Label lblTournamentName;
        private TextBox txtMaxNoOfParticipant;
        private Label lblMaxNoOfParticipant;
    }
}