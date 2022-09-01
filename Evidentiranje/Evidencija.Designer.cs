namespace Evidentiranje
{
    partial class Evidencija
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.evMestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evOsobaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sklonisteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izvestajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.osobaListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sklonisteListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evMestoToolStripMenuItem,
            this.evOsobaToolStripMenuItem,
            this.sklonisteToolStripMenuItem,
            this.izvestajToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            
            // 
            // evMestoToolStripMenuItem
            // 
            this.evMestoToolStripMenuItem.Name = "evMestoToolStripMenuItem";
            this.evMestoToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.evMestoToolStripMenuItem.Text = "EvMesto";
            this.evMestoToolStripMenuItem.Click += new System.EventHandler(this.evMestoToolStripMenuItem_Click);
            // 
            // evOsobaToolStripMenuItem
            // 
            this.evOsobaToolStripMenuItem.Name = "evOsobaToolStripMenuItem";
            this.evOsobaToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.evOsobaToolStripMenuItem.Text = "EvOsoba";
            this.evOsobaToolStripMenuItem.Click += new System.EventHandler(this.evOsobaToolStripMenuItem_Click);
            // 
            // sklonisteToolStripMenuItem
            // 
            this.sklonisteToolStripMenuItem.Name = "sklonisteToolStripMenuItem";
            this.sklonisteToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.sklonisteToolStripMenuItem.Text = "Skloniste";
            this.sklonisteToolStripMenuItem.Click += new System.EventHandler(this.sklonisteToolStripMenuItem_Click);
            // 
            // izvestajToolStripMenuItem
            // 
            this.izvestajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mestoToolStripMenuItem,
            this.osobaListToolStripMenuItem,
            this.sklonisteListToolStripMenuItem});
            this.izvestajToolStripMenuItem.Name = "izvestajToolStripMenuItem";
            this.izvestajToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.izvestajToolStripMenuItem.Text = "Izvestaj";
            // 
            // mestoToolStripMenuItem
            // 
            this.mestoToolStripMenuItem.Name = "mestoToolStripMenuItem";
            this.mestoToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.mestoToolStripMenuItem.Text = " Mesto List";
            this.mestoToolStripMenuItem.Click += new System.EventHandler(this.mestoToolStripMenuItem_Click);
            // 
            // osobaListToolStripMenuItem
            // 
            this.osobaListToolStripMenuItem.Name = "osobaListToolStripMenuItem";
            this.osobaListToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.osobaListToolStripMenuItem.Text = "Osoba List";
            this.osobaListToolStripMenuItem.Click += new System.EventHandler(this.osobaListToolStripMenuItem_Click);
            // 
            // sklonisteListToolStripMenuItem
            // 
            this.sklonisteListToolStripMenuItem.Name = "sklonisteListToolStripMenuItem";
            this.sklonisteListToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.sklonisteListToolStripMenuItem.Text = "Skloniste List";
            this.sklonisteListToolStripMenuItem.Click += new System.EventHandler(this.sklonisteListToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // Evidencija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Evidencija";
            this.Text = "Evidencija";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Evidencija_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem evMestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evOsobaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sklonisteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izvestajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem osobaListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sklonisteListToolStripMenuItem;
    }
}



