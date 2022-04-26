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
            foreach (Tournament tournament in tournaments)
            {
                AllTournamentsList.Items.Add(tournament.ToString());
            }
        }
    }
}
