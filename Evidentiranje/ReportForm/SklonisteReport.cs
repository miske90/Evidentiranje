﻿using CrystalDecisions.CrystalReports.Engine;
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
    public partial class SklonisteReport : Form
    {
        ReportDocument cryrpt = new ReportDocument();
        public SklonisteReport()
        {
            InitializeComponent();
        }

        private void SklonisteReport_Load(object sender, EventArgs e)
        {
            cryrpt.Load(@"C:\Users\PC\source\repos\Evidentiranje\Evidentiranje\Reports\Skloniste.rpt");
            SqlConnection con = new SqlConnection("Data Source=PC-PC\\SQLEXPRESS;Initial Catalog=Evidentiranje;Integrated Security=True");
            con.Open();
            DataSet dst = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [Skloniste]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cryrpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cryrpt;
        }
    }
}
