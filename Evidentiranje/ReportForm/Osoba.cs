using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Evidentiranje.ReportForm
{
    public partial class Osoba : Form
    {
        ReportDocument cryrpt = new ReportDocument();
        public Osoba()
        {
            InitializeComponent();
        }

        private void Osoba_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cryrpt.Load(@"C:\Users\PC\source\repos\Evidentiranje\Evidentiranje\Reports\Osoba.rpt");
            SqlConnection con = new SqlConnection("Data Source=PC-PC\\SQLEXPRESS;Initial Catalog=Evidentiranje;Integrated Security=True");
            con.Open();
            DataSet dst = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [EvOsoba] where Cast(DatumEvakuacije as Date) between '"+dateTimePicker1.Value.ToString("MM/dd/yyyy")+"'and '"+dateTimePicker2.Value.ToString("MM/dd/yyyy")+"'",con);
            sda.Fill(dst, "EvOsoba");
            cryrpt.SetDataSource(dst);
            cryrpt.SetParameterValue("@FromDate", dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            cryrpt.SetParameterValue("@ToDate", dateTimePicker2.Value.ToString("dd/MM/yyyy"));
            crystalReportViewer1.ReportSource = cryrpt;
        }
    }
}
