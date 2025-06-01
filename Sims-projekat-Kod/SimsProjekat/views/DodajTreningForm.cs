using SismProjekat.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimsProjekat.views
{
    internal class DodajTreningForm:Form
    {
        private DateTimePicker datum;
        private CheckedListBox vezbeList;
        private ComboBox tipTreningaCombo;
        private Button dodajBtn;
        private Button otkaziBtn;

        public Trening VraceniTrening { get; private set; }

        private List<Vezba> sveVezbe;

        public DodajTreningForm(List<Vezba> dostupneVezbe)
        {
            this.sveVezbe= dostupneVezbe;
            InitUI();
        }

        private void InitUI()
        {
            this.Text = "Dodavanje Treninga";
            this.Size = new System.Drawing.Size(350, 400);

            datum=new DateTimePicker { Location=new System.Drawing.Point(20,20),Width=280};

            vezbeList = new CheckedListBox { Location = new System.Drawing.Point(20, 60), Width = 280, Height = 120 };
            foreach(var vezba in sveVezbe)
                vezbeList.Items.Add(vezba);

            tipTreningaCombo= new ComboBox { Location=new System.Drawing.Point(20,200),Width=280};
            tipTreningaCombo.Items.AddRange(new string[] { "Grupni Trening", "Personalni Trening" });
            tipTreningaCombo.SelectedIndex = 0;

            dodajBtn = new Button { Text = "Dodaj", Location = new System.Drawing.Point(140, 250), Width = 80 };
            otkaziBtn = new Button { Text = "Otkazi", Location = new System.Drawing.Point(230, 250), Width = 80 };

            dodajBtn.Click += DodajBtn_Click;
            otkaziBtn.Click += (s, e) => this.Close();

            this.Controls.Add(datum);
            this.Controls.Add(vezbeList);
            this.Controls.Add(tipTreningaCombo);
            this.Controls.Add(dodajBtn);
            this.Controls.Add(otkaziBtn);


        }

        private void DodajBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
