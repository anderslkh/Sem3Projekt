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

namespace DesktopConsumer.GUI.ContentPanels {
    public partial class ReadTournamentsContentPanel : Form {
        public ReadTournamentsContentPanel() {
            InitializeComponent();
        }

        public void Populate(List<Tournament> tournaments)
        {
            if (tournaments != null)
            {
                foreach (Tournament tournament in tournaments)
                {
                    ListViewItem listItem = new ListViewItem(tournament.TournamentId.ToString());
                    listItem.SubItems.Add(tournament.TournamentName);
                    listItem.SubItems.Add(tournament.TimeOfEvent.ToString());
                    listItem.SubItems.Add(tournament.RegistrationDeadline.ToString());
                    listItem.SubItems.Add(tournament.MaxParticipants.ToString());
                    listItem.SubItems.Add(tournament.EnrolledParticipants.ToString());
                    listView1.Items.Add(listItem);
                }
            }
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            ListViewItem foundItem = listView1.FindItemWithText(searchBar.Text, false, 0, true);
            if (foundItem != null)
            {
                listView1.TopItem = foundItem;
            }
        }
    }
}
