using DesktopComsumer.Models;
using DesktopConsumer.Controller;
using DesktopConsumer.GUI.ContentPanels;
using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopConsumer.GUI.MenuPanels
{
    public partial class TournamentMenu : SubBaseMenu
    {
        public TournamentMenu()
        {
            InitializeComponent();
            GenerateButton();
        }

        private void GenerateButton()
        {
            List<Button> buttons = new List<Button>();
            

            Button FindTournamentBtn = new Button();
            FindTournamentBtn.Text = "Find turnering";
            FindTournamentBtn.Click += new System.EventHandler(FindTournamentBtn_Click);
            buttons.Add(FindTournamentBtn);
            InitializeLayout(buttons);
        }
        private async void FindTournamentBtn_Click(object? sender, EventArgs e)
        {
            Form readTournament = UIFactory.ReadTournamentUI();
            Task<Tournament> p = PopulateContentPanel();
            await p;
            if (p.IsCompletedSuccessfully)
            {

                if (readTournament is ReadTournamentContentPanel readTournamentContentPanel)
                {
                    readTournamentContentPanel.Populate(p.Result);
                }

            }
            NavigateTo(readTournament, ContentPanel);
        }
        public async Task<Tournament> PopulateContentPanel()
        {

            return await Task.Run(async () =>
            {
                TournamentController tournamentController = new TournamentController();
                return await tournamentController.GetTournamentById(1);
            });
        }
    }
}
