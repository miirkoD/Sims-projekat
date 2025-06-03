using SimsProjekat.controller;
using SismProjekat.models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SismProjekat.views
{
    public partial class KlijentPanel:UserControl
    {
        private TreninziController treninziController = new TreninziController();

        private TextBox imeInput;
        private ListBox personalniList;
        private ListBox grupniList;
        public KlijentPanel()
        {

            InitializeUI();
        }

        private void InitializeUI()
        {
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(20);

            TableLayoutPanel layout = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 5,
                Dock = DockStyle.Fill,
                AutoSize=true
            };
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute,120));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute,120));

            FlowLayoutPanel unosLayout = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                Padding = new Padding(5),
                Margin = new Padding(0,0,0,10)
            };

            Label imeLabel = new Label { Text = "Unesi ime kljienta:",AutoSize= true,Font=new Font("Segoe UI",10)};

            imeInput = new TextBox { Width = 200, Font = new Font("Segoe UI", 10) };

            Button pretragaBtn = new Button { Text = "Pretrazi", Width = 100, Font = new Font("Segoe UI", 10) };



            unosLayout.Controls.Add(imeLabel);
            unosLayout.Controls.Add(imeInput);
            unosLayout.Controls.Add(pretragaBtn);

            //personalni trening

            Label personalniLabel=new Label
            {
                Text = "Personalni treninzi:",
                Font = new Font("Segoe UI", 10,FontStyle.Bold),
                AutoSize = true
            };

            personalniList = new ListBox
            {
                Height=120,
                Width=400,
                Font = new Font("Segoe UI", 10)
            };

            //grupni trening
            Label grupniLabel = new Label
            {
                Text = "Grupni treninzi:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true
            };

            grupniList = new ListBox
            {
                Height = 120,
                Width = 400,
                Font = new Font("Segoe UI", 10)
            };


            layout.Controls.Add(unosLayout);
            layout.Controls.Add(personalniLabel);
            layout.Controls.Add(personalniList);
            layout.Controls.Add(grupniLabel);
            layout.Controls.Add(grupniList);

            //personalniList.Items.Add("test trening");
            //grupniList.Items.Add("test grupni trening");

            this.Controls.Add(layout);

            pretragaBtn.Click += PretragaBtn_CLick;

        }

        private void PretragaBtn_CLick(object sender, EventArgs e)
        {
            string ime = imeInput.Text.Trim();
            if (string.IsNullOrEmpty(ime))
            {
                MessageBox.Show("Unesite ime klijenta");
            }
            personalniList.Items.Clear();
            grupniList.Items.Clear();

            var sviTreninzi = treninziController.DobaviSveTreninge();

            Console.WriteLine("ime klijenta: " + ime);

            foreach (var trening in sviTreninzi)
            {
                if(trening is PersonalniTrening pt && pt.ImeIPrezimeKlijenta.Equals(ime, StringComparison.OrdinalIgnoreCase))
                {
                    personalniList.Items.Add($"Personalni - {pt.DatumTreninga:g}");
                }else if(trening is GrupniTrening gt && gt.BrojUcesnika < gt.MaksimalanBrojUcesnika)
                {
                    grupniList.Items.Add($"Grupni ({gt.BrojUcesnika}/{gt.MaksimalanBrojUcesnika}) - {gt.DatumTreninga:g}");
                }
            }

            if (personalniList.Items.Count == 0)
            {
                personalniList.Items.Add("Nema personalnih treninga za ovog klijenta.");
            }

            if (grupniList.Items.Count == 0)
            {
                grupniList.Items.Add("Nema grupnih treninga sa slobodnim mestima.");
            }
        }
    }
}
