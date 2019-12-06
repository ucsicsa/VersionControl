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
            lblLastName.Text = Resource1.FullName; // label1
            btnAdd.Text = Resource1.Add; // button1
            btnFW.Text = Resource1.FW; // button2
            btnDel.Text = Resource1.DEL; // button3

            // listbox1
            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtLastName.Text
            };
            users.Add(u);
        }

        private void btnFW_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName + ".txt");

                foreach (User u in users)
                {
                    sw.WriteLine(u.ID + "; " + u.FullName);
                }

                sw.Close();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            users.Remove((User)listUsers.SelectedItem);
        }
    }
}
