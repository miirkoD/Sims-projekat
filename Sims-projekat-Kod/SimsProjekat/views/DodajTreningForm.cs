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
        private DateTimePicker datumPicker;
        private CheckedListBox vezbeList;
        private ComboBox tipTreningaCombo;
        private Button dodajBtn;
        private Button otkaziBtn;

        public Trening VraceniTrening { get; private set; }

        private List<Vezba> sveVezbe;
        private Trening stariTrening;

        public DodajTreningForm(List<Vezba> dostupneVezbe)
        {
            this.sveVezbe= dostupneVezbe;
            
            InitUI();
        }
        public DodajTreningForm(List<Vezba> dostupneVezbe, Trening treningZaIzmenu)
        {
            this.sveVezbe = dostupneVezbe;
            this.stariTrening = treningZaIzmenu;
            InitUI();
            PopuniPoljaZaIzmenu();
        }
        private void InitUI()
        {
            this.Text = "Dodavanje Treninga";
            this.Size = new System.Drawing.Size(350, 400);

            datumPicker=new DateTimePicker { Location=new System.Drawing.Point(20,20),Width=280};

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

            this.Controls.Add(datumPicker);
            this.Controls.Add(vezbeList);
            this.Controls.Add(tipTreningaCombo);
            this.Controls.Add(dodajBtn);
            this.Controls.Add(otkaziBtn);
        }

        private void DodajBtn_Click(object sender, EventArgs e)
        {
            if (vezbeList.CheckedItems.Count == 0)
            {
                MessageBox.Show("Izaberite barem jednu vezbu");
                return;
            }
            var izabraneVezbe=new List<Vezba>();
            foreach(var item in vezbeList.CheckedItems)
            {
                izabraneVezbe.Add((Vezba)item);
            }
            var datum = datumPicker.Value;
            var tip = tipTreningaCombo.SelectedItem.ToString();

            Trening noviTrening;

            if(tip=="Grupni Trening")
            {
                noviTrening = new GrupniTrening(datum);
            }
            else
            {
                noviTrening = new PersonalniTrening(datum);
            }

            foreach (var v in izabraneVezbe)
                noviTrening.dodajVezbu(v);

            this.VraceniTrening = noviTrening;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
        private void PopuniPoljaZaIzmenu()
        {
            if (stariTrening == null)
            {
                return;
            }

            datumPicker.Value = stariTrening.DatumTreninga;

            for (int i = 0; i < vezbeList.Items.Count; i++)
            {
                var vezba = (Vezba)vezbeList.Items[i];
                if(stariTrening.Vezbe.Any(v=>v.Naziv==vezba.Naziv))
                {
                    vezbeList.SetItemChecked(i, true);
                }
            }
            if (stariTrening is GrupniTrening)
            {
                tipTreningaCombo.SelectedIndex = 0;
            }
            else if(stariTrening is PersonalniTrening)
            {
                tipTreningaCombo.SelectedIndex = 1;
            }
        }
    }
}
