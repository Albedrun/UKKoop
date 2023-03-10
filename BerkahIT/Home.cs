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
    public partial class Home : Form
    {

        SqlConnection co = new SqlConnection(@"Server=LAPTOP-68ADJVEN\BERKAHIT; Database = Dbkasir; integrated security = true");
        SqlCommand mycommand = new SqlCommand();
        SqlDataAdapter myadapter = new SqlDataAdapter();

        public Home()
        {
            InitializeComponent();
            Bersihkan();
            readData();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        void Bersihkan()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "";
        }

        void readData()
        {
            try
            {
                mycommand.Connection = co;
                myadapter.SelectCommand = mycommand;
                mycommand.CommandText = "select * from Table_Barang";
                DataSet ds = new DataSet();
                if (myadapter.Fill(ds, "Table_Barang") > 0)
                {
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Table_Barang";
                }
                co.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["KodeBarang"].Value.ToString();
                textBox2.Text = row.Cells["NamaBarang"].Value.ToString();
                textBox3.Text = row.Cells["HargaJual"].Value.ToString();
                textBox4.Text = row.Cells["HargaBeli"].Value.ToString();
                textBox5.Text = row.Cells["JumlahBarang"].Value.ToString();
                textBox6.Text = row.Cells["SatuanBarang"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Isi setiap kolom terlebih dahulu");
            }
            else
            {
                try
                {
                    mycommand.Connection = co;
                    myadapter.SelectCommand = mycommand;
                    mycommand.CommandText = "UPDATE Table_Barang Set KodeBarang='" + textBox1.Text + "',NamaBarang='" + textBox2.Text + "',HargaJual='" + textBox3.Text + "',HargaBeli='" + textBox4.Text + "',JumlahBarang='" + textBox5.Text + "',SatuanBarang='" + textBox6.Text + "' where KodeBarang='" + textBox1.Text + "'";
                    DataSet ds = new DataSet();
                    if (myadapter.Fill(ds, "Table_Barang") > 0)
                    {
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "Table_Barang";
                    }
                    MessageBox.Show("Update Data berhasil");
                    readData();
                    Bersihkan();
                    co.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Isi setiap kolom terlebih dahulu");
            }
            else
            {
                try
                {
                    mycommand.Connection = co;
                    myadapter.SelectCommand = mycommand;
                    mycommand.CommandText = "DELETE FROM Table_Barang where KodeBarang='" + textBox1.Text + "'";
                    DataSet ds = new DataSet();
                    if (myadapter.Fill(ds, "Table_Barang") > 0)
                    {
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "Table_Barang";
                    }
                    MessageBox.Show("Delete Data berhasil");
                    readData();
                    Bersihkan();
                    co.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Isi setiap kolom terlebih dahulu");
            }
            else
            {
                try
                {
                    mycommand.Connection = co;
                    myadapter.SelectCommand = mycommand;
                    mycommand.CommandText = "INSERT INTO TABLE_BARANG VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                    DataSet ds = new DataSet();
                    if (myadapter.Fill(ds, "Table_Barang") > 0)
                    {
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "Table_Barang";
                    }
                    MessageBox.Show("Data berhasil di-input");
                    readData();
                    Bersihkan();
                    co.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data Gagal diinput");
                }
            }

        }
    }
}
