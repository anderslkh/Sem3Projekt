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
using DesktopConsumer.Models;

namespace DesktopConsumer.GUI.ContentPanels {
    public partial class ReadUsersContentPanel : Form {
        public ReadUsersContentPanel() {
            InitializeComponent();
        }

        public void Populate(List<Person> persons)
        {
            if (persons != null)
            {
                foreach (Person person in persons)
                {
                    ListViewItem listItem = new ListViewItem(person.FirstName);
                    listItem.SubItems.Add(person.LastName);
                    listItem.SubItems.Add(person.UserName);
                    listItem.SubItems.Add(person.Email);
                    listItem.SubItems.Add(person.BirthDate.ToString("dd/MM/yyyy"));
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
