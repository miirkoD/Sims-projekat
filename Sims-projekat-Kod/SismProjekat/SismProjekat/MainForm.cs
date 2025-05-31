using SismProjekat.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SismProjekat
{
    public partial class MainForm : Form
    {
        private MenuStrip menuStrip;
        private Panel panelContent;

        public MainForm()
        {
            //InitializeComponent();
            //this.Text = "Sims Projekat";
            InitUI();
        }

        private void InitUI()
        {
            this.Text = "Sistem za upravljanje treninzima";
            this.Size = new Size(800, 600);
            this.BackColor= Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            menuStrip =new MenuStrip();
            var trenerMenu = new ToolStripMenuItem("Trener");
            var klijentMenu = new ToolStripMenuItem("Klijent");


           
            

            menuStrip.Items.AddRange(new[] { trenerMenu, klijentMenu });
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            panelContent = new Panel
            {
                Name = "contentPanel",
                Dock = DockStyle.Fill,
                Padding = new Padding(50)
            };
            this.Controls.Add(panelContent);
            menuStrip.Dock = DockStyle.Top;

            trenerMenu.Click += (s, e) => 
            {
                LoadContent(new TrenerPanel());
            };
            klijentMenu.Click += (s, e) =>
            {
                LoadContent(new KlijentPanel());
            };
        }

        private void LoadContent(UserControl control)
        {
            Panel contentPanel = this.Controls.Find("contentPanel", true).FirstOrDefault() as Panel;
            if (contentPanel != null)
            {
                contentPanel.Controls.Clear();
                control.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(control);
            }
        }

        

    }
}
