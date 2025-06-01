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
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute,20));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

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

            this.Controls.Add(layout);

            pretragaBtn.Click += (s, e) =>
            {
                string ime = imeInput.Text.Trim();
                if (!string.IsNullOrEmpty(ime))
                {
                    personalniList.Items.Clear();
                    grupniList.Items.Add(ime);

                    personalniList.Items.Add($"Perosnalni trening za {ime} - 12.06. 17:00");
                    grupniList.Items.Add($"Grupni treninz - 14.06. 18:00");
                }
            };

        }
    }
}
