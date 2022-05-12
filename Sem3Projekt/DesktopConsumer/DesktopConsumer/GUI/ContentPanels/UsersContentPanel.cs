using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopConsumer.Models;

namespace DesktopConsumer.GUI.ContentPanels
{
    public partial class UsersContentPanel : Form
    {
        public UsersContentPanel()
        {
            InitializeComponent();
        }

        public void Populate(List<Person> persons) {
            foreach (Person person in persons) {
                listBox1.Items.Add(person.ToString());
            }
        }
    }
}
