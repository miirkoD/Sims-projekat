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

        private Label maxKlijenataLbl;
        private NumericUpDown maxKlijenataNumeric;
        private Label imeIPrezimeKlijentaLbl;
        private TextBox imeIPrezimeKlijentaTextBox;

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
            this.Size = new System.Drawing.Size(350, 450);

            datumPicker=new DateTimePicker { Location=new System.Drawing.Point(20,20),Width=280};

            vezbeList = new CheckedListBox { Location = new System.Drawing.Point(20, 60), Width = 280, Height = 100 };

            foreach(var vezba in sveVezbe)
                vezbeList.Items.Add(vezba);

            tipTreningaCombo= new ComboBox { Location=new System.Drawing.Point(20,170),Width=280};
            tipTreningaCombo.Items.AddRange(new string[] { "Grupni Trening", "Personalni Trening" });
            tipTreningaCombo.SelectedIndex = 0;
            tipTreningaCombo.SelectedIndexChanged += TipTreningaCombo_SelectedIndexChanged;

            
            maxKlijenataLbl = new Label { Text = "Maksimalan broj klijenata:", Location = new System.Drawing.Point(20, 210) };
            maxKlijenataNumeric = new NumericUpDown { Location = new System.Drawing.Point(140, 210), Width = 100, Minimum = 1, Maximum = 20, Value = 10 };

            imeIPrezimeKlijentaLbl= new Label { Text = "Ime i prezime klijenta:", Location = new System.Drawing.Point(20, 210) };
            imeIPrezimeKlijentaTextBox=new TextBox { Location = new System.Drawing.Point(140, 210), Width = 160 };

            var tip = tipTreningaCombo.SelectedItem.ToString();
           
            dodajBtn = new Button { Text = "Dodaj", Location = new System.Drawing.Point(140, 270), Width = 80 };
            otkaziBtn = new Button { Text = "Otkazi", Location = new System.Drawing.Point(230, 270), Width = 80 };

            dodajBtn.Click += DodajBtn_Click;
            otkaziBtn.Click += (s, e) => this.Close();

            this.Controls.Add(datumPicker);
            this.Controls.Add(vezbeList);
            this.Controls.Add(tipTreningaCombo);
            this.Controls.Add(dodajBtn);
            this.Controls.Add(otkaziBtn);

            PrikaziPoljaZaGrupni();
        }

        private void PrikaziPoljaZaGrupni()
        {
            this.Controls.Remove(imeIPrezimeKlijentaLbl);
            this.Controls.Remove(imeIPrezimeKlijentaTextBox);

            this.Controls.Add(maxKlijenataLbl);
            this.Controls.Add(maxKlijenataNumeric);
        }

        private void TipTreningaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tip = tipTreningaCombo.SelectedItem.ToString();
            if (tip == "Grupni Trening")
                PrikaziPoljaZaGrupni();
            else
                PrikaziPoljaZaPersonalni();
        }

        private void PrikaziPoljaZaPersonalni()
        {
            this.Controls.Remove(maxKlijenataLbl);
            this.Controls.Remove(maxKlijenataNumeric);

            this.Controls.Add(imeIPrezimeKlijentaLbl);
            this.Controls.Add(imeIPrezimeKlijentaTextBox);
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
            var maxKlijenata = maxKlijenataNumeric.Value;

            Trening noviTrening;

            if(tip=="Grupni Trening")
            {
                if(maxKlijenata<1)
                {
                    MessageBox.Show("Maksimalan broj klijenata mora biti bar 1");
                    return;
                }
                var grupni=new GrupniTrening(datum, (int)maxKlijenata);
                noviTrening = grupni;
            }
            else
            {
                var imeIPrezime= imeIPrezimeKlijentaTextBox.Text.Trim();
                if(string.IsNullOrEmpty(imeIPrezime))
                {
                    MessageBox.Show("Unesite ime i prezime klijenta za personalni trening");
                    return;
                }
                var personalniTrening=new PersonalniTrening(datum, imeIPrezime);
                noviTrening = personalniTrening;
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
            if (stariTrening is GrupniTrening gt)
            {
                tipTreningaCombo.SelectedIndex = 0;
                maxKlijenataNumeric.Value = gt.MaksimalanBrojUcesnika;
            }
            else if(stariTrening is PersonalniTrening pt)
            {
                tipTreningaCombo.SelectedIndex = 1;
                imeIPrezimeKlijentaTextBox.Text = pt.ImeIPrezimeKlijenta;
            }
        }
    }
}
