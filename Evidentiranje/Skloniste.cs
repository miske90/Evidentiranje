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
    public partial class Skloniste : Form
    {
        public Skloniste()
        {
            InitializeComponent();
        }

        private void Skloniste_Load(object sender, EventArgs e)
        {
            textBox3.Text = "";
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SqlConnection con = new SqlConnection("Data Source=PC-PC\\SQLEXPRESS;Initial Catalog=Evidentiranje;Integrated Security=True");
                con.Open();
                var sqlQuery = "";
                if (IfSklonisteExists(con, textBox1.Text))
                {
                    sqlQuery = @"UPDATE [Skloniste] SET [Naziv] ='" + textBox2.Text + "',[Kapacitet] = '" + textBox3.Text + "' WHERE[SifSk] = '" + textBox1.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO[dbo].[Skloniste] ([SifSk],[Naziv],[Kapacitet])
                        VALUES
               ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                }
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                LoadData();
                ResetRecords(); 
            }
        }

        private bool IfSklonisteExists(SqlConnection con,string SifSk)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select 1 From [Skloniste] Where [SifSk]='" + SifSk+"'", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [Skloniste]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["SifSk"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Naziv"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Kapacitet"].ToString();
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button2.Text = "Update";
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SqlConnection con = new SqlConnection("Data Source=PC-PC\\SQLEXPRESS;Initial Catalog=Evidentiranje;Integrated Security=True");
                var sqlQuery = "";
                if (IfSklonisteExists(con, textBox1.Text))
                {
                    con.Open();
                    sqlQuery = @"DELETE FROM [Skloniste] WHERE[SifSk] = '" + textBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Record Not Exists!....");
                }
                LoadData();
                ResetRecords();
            }
        }

        private void ResetRecords()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
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
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                result = true;
            }
            return result;
        }
    }
}
