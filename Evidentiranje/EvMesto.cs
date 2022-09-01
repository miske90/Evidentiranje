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
    public partial class EvMesto : Form
    {
        public EvMesto()
        {
            InitializeComponent();
        }

        private void EvMesto_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SqlConnection con = new SqlConnection("Data Source=PC-PC\\SQLEXPRESS;Initial Catalog=Evidentiranje;Integrated Security=True");
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
                    sqlQuery = @"UPDATE [EvMesto] SET [Naziv] = '" + textBox2.Text + "',[DatumEvakuacije] = '" + textBox3.Text + "',[Status] = '" + status + "'  WHERE [SifEM] = '" + textBox1.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO[dbo].[EvMesto]([SifEM],[Naziv],[DatumEv],[Status])VALUES
               ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + status + "')";
                }

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                LoadData();
                ResetRecords(); 
            }
        }
       
        private bool IfMestoExists(SqlConnection con,string SifEM)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select 1 From [EvMesto] Where SifEM='"+SifEM+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public void LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=PC-PC\\SQLEXPRESS;Initial Catalog=Evidentiranje;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [dbo].[EvMesto]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["SifEM"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Naziv"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["DatumEv"].ToString();
                if ((bool)item["Status"])
                {
                    dataGridView1.Rows[n].Cells[3].Value = "Aktivan";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[3].Value = "Nije Aktivan";
                }

            }
        }


        private void dataGridView1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            button2.Text = "Update";
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "Aktivan")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SqlConnection con = new SqlConnection("Data Source=PC-PC\\SQLEXPRESS;Initial Catalog=Evidentiranje;Integrated Security=True");
                var sqlQuery = "";
                if (IfMestoExists(con, textBox1.Text))
                {
                    con.Open();
                    sqlQuery = @"DELETE FROM [EvMesto] WHERE [SifEM] = '" + textBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Record Not Exists...!");
                }
                LoadData();
                ResetRecords();
            }
        }

        public void ResetRecords()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            button2.Text = "Add";
            textBox1.Focus();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetRecords();
        }

        private bool Validation()
        {
            bool result = false;
            if (!string.IsNullOrEmpty(textBox1.Text)&& !string.IsNullOrEmpty(textBox2.Text)&& !string.IsNullOrEmpty(textBox3.Text)&& comboBox1.SelectedIndex>-1)
            {
                result = true;
            }
            return result;
        }
    }
}
