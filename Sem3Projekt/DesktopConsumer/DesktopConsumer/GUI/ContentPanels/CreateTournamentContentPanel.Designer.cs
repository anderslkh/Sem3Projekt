using System.Runtime.CompilerServices;

namespace DesktopConsumer.GUI.ContentPanels {
    partial class CreateTournamentContentPanel {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maxParticipants = new System.Windows.Forms.NumericUpDown();
            this.minParticipants = new System.Windows.Forms.NumericUpDown();
            this.registrationDeadline = new System.Windows.Forms.DateTimePicker();
            this.timeOfEvent = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tournamentName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxParticipants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minParticipants)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.maxParticipants);
            this.panel1.Controls.Add(this.minParticipants);
            this.panel1.Controls.Add(this.registrationDeadline);
            this.panel1.Controls.Add(this.timeOfEvent);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tournamentName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "Opret";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Maximum Deltagere:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Minimum Deltagere:";
            // 
            // maxParticipants
            // 
            this.maxParticipants.Location = new System.Drawing.Point(202, 189);
            this.maxParticipants.Name = "maxParticipants";
            this.maxParticipants.Size = new System.Drawing.Size(150, 27);
            this.maxParticipants.TabIndex = 7;
            // 
            // minParticipants
            // 
            this.minParticipants.Location = new System.Drawing.Point(202, 156);
            this.minParticipants.Name = "minParticipants";
            this.minParticipants.Size = new System.Drawing.Size(150, 27);
            this.minParticipants.TabIndex = 6;
            // 
            // registrationDeadline
            // 
            this.registrationDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.registrationDeadline.Location = new System.Drawing.Point(202, 123);
            this.registrationDeadline.Name = "registrationDeadline";
            this.registrationDeadline.Size = new System.Drawing.Size(250, 27);
            this.registrationDeadline.TabIndex = 5;
            this.registrationDeadline.CustomFormat = "MM/dd/yyyy hh:mm";
            // 
            // timeOfEvent
            // 
            this.timeOfEvent.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeOfEvent.Location = new System.Drawing.Point(202, 90);
            this.timeOfEvent.Name = "timeOfEvent";
            this.timeOfEvent.Size = new System.Drawing.Size(250, 27);
            this.timeOfEvent.TabIndex = 4;
            this.timeOfEvent.CustomFormat = "dd/MM/yyyy hh:mm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tilmeldingsfrist:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Afholdelsestidspunkt:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Turneringsnavn:";
            // 
            // tournamentName
            // 
            this.tournamentName.Location = new System.Drawing.Point(202, 57);
            this.tournamentName.Name = "tournamentName";
            this.tournamentName.Size = new System.Drawing.Size(125, 27);
            this.tournamentName.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 352);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 98);
            this.panel2.TabIndex = 1;
            // 
            // CreateTournamentContentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateTournamentContentPanel";
            this.Text = "CreateTournamentContentPanel";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxParticipants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minParticipants)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tournamentName;
        private Panel panel2;
        private Button button1;
        private Label label5;
        private Label label4;
        private NumericUpDown maxParticipants;
        private NumericUpDown minParticipants;
        private DateTimePicker registrationDeadline;
        private DateTimePicker timeOfEvent;
    }
}