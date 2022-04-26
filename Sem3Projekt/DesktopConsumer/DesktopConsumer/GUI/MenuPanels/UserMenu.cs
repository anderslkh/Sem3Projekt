using DesktopConsumer.Controller;
using DesktopConsumer.GUI.ContentPanels;
using DesktopConsumer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace GUI
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
            Button button2 = new Button();
            button2.Text = "Opret bruger";

            List<Button> buttonList = new List<Button>();
            buttonList.Add(button1);
            buttonList.Add(button2);
            InitializeLayout(buttonList);
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