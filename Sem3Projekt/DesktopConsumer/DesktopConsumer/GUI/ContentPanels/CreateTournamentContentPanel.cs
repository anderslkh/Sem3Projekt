using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopComsumer.Models;
using DesktopConsumer.Controller;

namespace DesktopConsumer.GUI.ContentPanels {
    public partial class CreateTournamentContentPanel : Form {
        public CreateTournamentContentPanel() {
            InitializeComponent();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            TournamentController tournamentController = new TournamentController();
            string tournamentName = this.tournamentName.Text;
            DateTime timeOfEvent = this.timeOfEvent.Value;
            DateTime registrationDeadline = this.registrationDeadline.Value;
            int maxParticipants = (int)this.maxParticipants.Value;
            int minParticpants = (int) this.minParticipants.Value;

            Tournament tournamentToCreate = new Tournament(tournamentName, timeOfEvent, registrationDeadline,
                minParticpants, maxParticipants);

            await tournamentController.CreateTournament(tournamentToCreate);
        }
    }
}
