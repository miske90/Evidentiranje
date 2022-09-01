using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Evidentiranje
{
    public partial class Evidencija : Form
    {
        public Evidencija()
        {
            InitializeComponent();
        }

        bool close = true;

        private void Evidencija_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close)
            {

                DialogResult result = MessageBox.Show("Are You Sure Want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    close = false;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void evMestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EvMesto ev = new EvMesto();
            ev.MdiParent = this;
            ev.StartPosition = FormStartPosition.CenterScreen;
            ev.Show();
        }

        private void evOsobaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EvOsoba evo = new EvOsoba();
            evo.MdiParent = this;
            evo.StartPosition = FormStartPosition.CenterScreen;
            evo.Show();
        }

        private void sklonisteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Skloniste sk = new Skloniste();
            sk.MdiParent = this;
            sk.StartPosition = FormStartPosition.CenterScreen;
            sk.Show();
        }

        private void mestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm.MestoReport mesto = new ReportForm.MestoReport();
            mesto.MdiParent = this;
            mesto.StartPosition = FormStartPosition.CenterScreen;
            mesto.Show();
        }

        private void osobaListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm.Osoba osoba = new ReportForm.Osoba();
            osoba.MdiParent = this;
            osoba.StartPosition = FormStartPosition.CenterScreen;
            osoba.Show();
        }

        private void sklonisteListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm.SklonisteReport skloniste = new ReportForm.SklonisteReport();
            skloniste.MdiParent = this;
            skloniste.StartPosition = FormStartPosition.CenterScreen;
            skloniste.Show();
        }
    }
}
