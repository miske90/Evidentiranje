using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Evidentiranje
{
    public partial class EvOsoba : Form
    {
        public EvOsoba()
        {
            InitializeComponent();
        }

        private void EvOsoba_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            LoadData();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Length > 0)
                {
                    textBox2.Focus();
                }
                else
                {
                    textBox1.Focus();
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox2.Text.Length > 0)
                {
                    textBox3.Focus();
                }
                else
                {
                    textBox2.Focus();
                }
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox3.Text.Length > 0)
                {
                    textBox4.Focus();
                }
                else
                {
                    textBox3.Focus();
                }
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox4.Text.Length > 0)
                {
                    comboBox1.Focus();
                }
                else
                {
                    textBox4.Focus();
                }
            }
        }

        private void comboBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox1.SelectedIndex !=-1)
                {
                    button1.Focus();
                }
                else
                {
                    comboBox1.Focus();
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void ResetRecords()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = -1;
            button1.Text = "Add";
            textBox5.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetRecords();
        }

        private bool Validation()
        {
            bool result = false;

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "SifEO Required");
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Ime Required");
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Prezime Required");
            }
            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox4, "Adresa Required");
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(comboBox1, "Select Status");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }

        private bool IfMestoExists(SqlConnection con, string SifEO)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select 1 From [EvOsoba] WHERE [SifEO]='" + SifEO + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SqlConnection con = Connection.GetConnection();
                con.Open();
                bool status = false;

                if (comboBox1.SelectedIndex == 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                var sqlQuery = "";
                if (IfMestoExists(con, textBox1.Text))
                {
                    sqlQuery = @"UPDATE [EvOsoba] SET [Ime] = '" + textBox2.Text + "',[Prezime] = '" + textBox3.Text + "',[Adresa] = '" + textBox4.Text + "',[DatumEvakuacije]='" + textBox5.Text + "',[Status] = '" + status + "'  WHERE [SifEO] = '" + textBox1.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO EvOsoba (SifEO,Ime,Prezime,Adresa,DatumEvakuacije,Status) VALUES
                 ('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','"+textBox5.Text+"','" + status + "')";
                }

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Saved Successfully!!");
                ResetRecords();
               
            }
        }

        public void LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=PC-PC\\SQLEXPRESS;Initial Catalog=Evidentiranje;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [EvOsoba]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["dgSifEO"].Value = item["SifEO"].ToString();
                dataGridView1.Rows[n].Cells["dgIme"].Value = item["Ime"].ToString();
                dataGridView1.Rows[n].Cells["dgPrezime"].Value = item["Prezime"].ToString();
                dataGridView1.Rows[n].Cells["dgAdresa"].Value = item["Adresa"].ToString();
                dataGridView1.Rows[n].Cells["dgDatumEv"].Value =Convert.ToDateTime(item["DatumEvakuacije"].ToString()).ToString("dd/MM/yyyy");
                if ((bool)item["Status"])
                {
                    dataGridView1.Rows[n].Cells["dgStatus"].Value = "Evakuisan";
                }
                else
                {
                    dataGridView1.Rows[n].Cells["dgStatus"].Value = "Nije Evakuisan";
                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button1.Text = "Update";
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["dgSifEO"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["dgIme"].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells["dgPrezime"].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells["dgAdresa"].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells["dgDatumEv"].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells["dgStatus"].Value.ToString() == "Evakuisan")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you Sure Want ot Delete?", "Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Validation())
                {
                    SqlConnection con = new SqlConnection("Data Source=PC-PC\\SQLEXPRESS;Initial Catalog=Evidentiranje;Integrated Security=True");
                    var sqlQuery = "";
                    if (IfMestoExists(con, textBox1.Text))
                    {
                        con.Open();
                        sqlQuery = @"DELETE FROM [EvOsoba] WHERE [SifEO] = '" + textBox1.Text + "'";
                        SqlCommand cmd = new SqlCommand(sqlQuery, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Record Delete Successfully...!");
                    }
                    else
                    {
                        MessageBox.Show("Record Not Exists...!");
                    }

                    LoadData();
                    ResetRecords();
                }
            }
        }
    }
}
