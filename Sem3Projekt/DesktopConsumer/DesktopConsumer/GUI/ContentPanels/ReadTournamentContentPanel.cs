using DesktopComsumer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopConsumer.GUI.ContentPanels
{
    public partial class ReadTournamentContentPanel : Form
    {
        public ReadTournamentContentPanel()
        {
            InitializeComponent();
        }
        public void Populate(Tournament tournament)
        {
            txtInsertTournamentName.Text = tournament.TournamentName;
            txtTimeOfEvent.Text = tournament.TimeOfEvent.ToString();
            txtRegistrationDeadline.Text = tournament.RegistrationDeadline.ToString();
            txtMinNoOfParticipant.Text = tournament.MinNoOfParticipants.ToString();
            txtMaxNoOfParticipant.Text = tournament.MaxNoOfParticipants.ToString();
        }
    }
}
