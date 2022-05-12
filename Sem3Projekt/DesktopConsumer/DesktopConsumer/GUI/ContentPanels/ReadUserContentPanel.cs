using DesktopConsumer.Controller;
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

namespace DesktopConsumer.GUI.ContentPanels
{
    public partial class ReadUserContentPanel : Form
    {
        public ReadUserContentPanel()
        {
            InitializeComponent();
        }
        public void Populate(Person person)
        {
            txtInsertName.Text = person.FirstName + " " + person.LastName;
            txtUsername.Text = person.FirstName;
            txtEmail.Text = person.Email;
            txtBirthdate.Text = person.BirthDate.ToString();
        }
    }
    
}
