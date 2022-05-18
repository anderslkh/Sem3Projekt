using DesktopConsumer.Controller;
using DesktopConsumer.GUI.ContentPanels;
using DesktopConsumer.Models;
using Button = System.Windows.Forms.Button;

namespace DesktopConsumer.GUI.MenuPanels
{
    public partial class UserMenu : SubBaseMenu
    {
        public UserMenu()
        {
            GenerateComponents();
        }

        private void GenerateComponents()
        {
            Button button1 = new Button();
            button1.Text = "Find bruger";
            button1.Click += new System.EventHandler(button1_Click);
            Button allUsersBtn = new Button();
            allUsersBtn.Text = "Alle brugere";
            allUsersBtn.Click += new System.EventHandler(allUsersBtn_Click);
            Button button2 = new Button();
            button2.Text = "Opret bruger";

            List<Button> buttonList = new List<Button>();
            buttonList.Add(button1);
            buttonList.Add(button2);
            buttonList.Add(allUsersBtn);
            InitializeLayout(buttonList);
        }

        private async void allUsersBtn_Click(object? sender, EventArgs e)
        {
            Form allUsers = UIFactory.ReadAllUsersUI();
            Task<List<Person>> p = PopulateAllTournamentsContentPanel();
            await p;
            if (p.IsCompletedSuccessfully) {
                if (allUsers is ReadUsersContentPanel usersContentPanel) {
                    usersContentPanel.Populate(p.Result);
                }
                NavigateTo(allUsers, ContentPanel);
            }
        }

        public async Task<List<Person>> PopulateAllTournamentsContentPanel() {
            return await Task.Run(async () => {
                PersonController personController = new PersonController();
                return await personController.GetAllPersons();
            });
        }

        private async void button1_Click(object? sender, EventArgs e)
        {
            Form readUser = UIFactory.ReadUserUI();
            Task<Person> p = PopulateContentPanel();
            await p;
            if (p.IsCompletedSuccessfully)
            {
                
                if (readUser is ReadUserContentPanel readUserContentPanel)
                {
                    readUserContentPanel.Populate(p.Result);
                }

            }
            NavigateTo(readUser, ContentPanel);
        }

        public async Task<Person> PopulateContentPanel()
        {

            return await Task.Run( async() =>
            {
                PersonController personController = new PersonController();
                return await personController.GetPersonByEmail("test@test");
            });
        }
    }
}