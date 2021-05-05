using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kursDB
{
    public partial class FormAuthorization : Form
    {
        public FormAuthorization()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Program.login = textBoxLogin.Text;
            Program.password = textBoxPassword.Text;
            Program.connection = @"Data Source=DESKTOP-PN7HNG0;Initial Catalog=lab3;User Id=" + Program.login + ";Password=" + Program.password + ";";
            int j = 1;
            try
            {
                SqlConnection connection = new SqlConnection(Program.connection);
                connection.Open();
                j++;
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Неверные параметры подключения");
            }
            if (j != 1)
            {
                if (textBoxLogin.Text.Contains("administrator"))
                    Program.usergroup = 1;
                else Program.usergroup = 2;
                FormMain fm2 = new FormMain();
                fm2.Show();
                this.Hide();
            }
        }
    }
}
