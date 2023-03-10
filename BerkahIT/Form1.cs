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

namespace BerkahIT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection koneksi = new SqlConnection(@"Data Source=LAPTOP-68ADJVEN\BERKAHIT;Initial Catalog=LoginBerkahIT;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) from Login where namaUser = '" + txtUser.Text + "' and password = '" + txtPassword.Text + "' ", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Home PANGGIL = new Home();
                PANGGIL.Show();
            }
            else
            {
                MessageBox.Show("Mohon isi user name dan password anda dengan benar", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExitOne_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
