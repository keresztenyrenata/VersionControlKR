using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();

            lblLastName.Text = Resource1.FullName;
            
            //lblFirstName.Text = Resource1.FirstName;
            btnAdd.Text = Resource1.Add;
            btnSave.Text = Resource1.Felirat;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                //LastName = txtLastName.Text,
                //FirstName = txtFirstName.Text,
                FullName = txtLastName.Text
            };
            users.Add(u);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "Comma Seperated Values (*.csv)|*.csv";
            sfd.DefaultExt = "csv";
            sfd.AddExtension = true;

            if (sfd.ShowDialog() != DialogResult.OK) return;

            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {

                sw.Write("ID:");
                sw.Write(";");
                sw.Write("Fullname:");
                sw.WriteLine();

                foreach (User u in listUsers.Items) sw.WriteLine(string.Format("{0};{1}", u.ID, u.FullName));

            }

            MessageBox.Show("A fájlba írás megtörtént");

            Application.Exit();
        }
    }
}
