using DesktopConsumer.Controller;
using DesktopConsumer.GUI.ContentPanels;
using DesktopConsumer.Models;

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
            Button AllTournamentsBtn = new Button();
            Button CreateTournamentBtn = new Button();
            AllTournamentsBtn.Text = "Alle turneringer";
            AllTournamentsBtn.Click += new System.EventHandler(AllTournamentsBtn_Click);
            FindTournamentBtn.Text = "Find turnering";
            FindTournamentBtn.Click += new System.EventHandler(FindTournamentBtn_Click);
            CreateTournamentBtn.Text = "Opret turnering";
            CreateTournamentBtn.Click += new System.EventHandler(CreateTournamentBtn_Click);
            buttons.Add(CreateTournamentBtn);
            buttons.Add(FindTournamentBtn);
            buttons.Add(AllTournamentsBtn);
            InitializeLayout(buttons);
        }

        private void CreateTournamentBtn_Click(object? sender, EventArgs e)
        {
            Form createTournament = UIFactory.CreateTournamentUI();
            NavigateTo(createTournament, ContentPanel);
        }

        private async void AllTournamentsBtn_Click(object? sender, EventArgs e)
        {
            Form allTournaments = UIFactory.ReadTournamentsUI();
            Task<List<Tournament>> p = PopulateAllTournamentsContentPanel();
            await p;
            if (p.IsCompletedSuccessfully)
            {
                if (allTournaments is ReadTournamentsContentPanel readTournamentsContent)
                {
                    readTournamentsContent.Populate(p.Result);
                }
                NavigateTo(allTournaments, ContentPanel);
            }

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

        public async Task<List<Tournament>> PopulateAllTournamentsContentPanel()
        {
            return await Task.Run(async () =>
            {
                TournamentController tournamentController = new TournamentController();
                return await tournamentController.GetAllTournaments();
            });
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
