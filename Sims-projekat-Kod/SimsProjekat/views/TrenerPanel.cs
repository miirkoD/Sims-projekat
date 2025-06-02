using SimsProjekat.controller;
using SimsProjekat.views;
using SismProjekat.models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SismProjekat.views
{
    public partial class TrenerPanel: UserControl
    {
        private VezbaController vezbaController = new VezbaController();
        private TreninziController treningController = new TreninziController();

        ListBox treningList;
        Button updateBtn;
        Button deleteBtn;
        Button addBtn;

        private List<Trening> sviTreninzi;
        public TrenerPanel() 
        {
            InitializeUI();
            UcitajTreningeUI();
        }
        private void InitializeUI()
        {
            this.BackColor=Color.White;
            //primer kako bi trebalo da izgledaju treninzi u listBoxu
            //treningList.Items.Add("Trening 1 - 10.06. 16:00");
            //treningList.Items.Add("Trening 2 - 11.06. 18.00");

            treningList = new ListBox { Dock = DockStyle.Fill };
            updateBtn = new Button { Text = "Izmeni trening", Dock = DockStyle.Bottom };
            deleteBtn = new Button { Text = "Obrisi trening", Dock = DockStyle.Bottom };
            addBtn = new Button { Text = "Dodaj trening", Dock = DockStyle.Bottom };

            this.Controls.Add(updateBtn);
            this.Controls.Add(deleteBtn);
            this.Controls.Add(addBtn);
            this.Controls.Add(treningList);

            updateBtn.Click += UpdateBtn_Click;
            deleteBtn.Click += DeleteBtn_Click;
            addBtn.Click += AddBtn_Click;
               
        }

        private void UcitajTreningeUI()
        {
            sviTreninzi = treningController.DobaviSveTreninge();
            treningList.Items.Clear();

            foreach (var trening in sviTreninzi)
            {
                string prikaz = $"Trening - {trening.DatumTreninga.ToShortDateString()}{trening.DatumTreninga.ToShortTimeString()}";
                treningList.Items.Add(prikaz);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            int selectedIndex = treningList.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Izaberite trening za izmenu");
                return;
            }

            var stariTrening=sviTreninzi[selectedIndex];
            var sveVezbe=vezbaController.DobaviSveVezbe();

            var form = new DodajTreningForm(sveVezbe, stariTrening);
            if(form.ShowDialog() == DialogResult.OK)
            {
                var izmeniTrening = form.VraceniTrening;
                treningController.IzmeniTrening(stariTrening,izmeniTrening);

                UcitajTreningeUI();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            int selectedIndex = treningList.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Izaberite trening za brisanje");
                return;
            }

            var treningZaBrisanje = sviTreninzi[selectedIndex];
            treningController.ObrisiTrening(treningZaBrisanje);

            UcitajTreningeUI();

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            var sveVezbe = vezbaController.DobaviSveVezbe();
            //MessageBox.Show($"Ucitan broj vezbi: {sveVezbe.Count}");
            var form = new DodajTreningForm(sveVezbe);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var noviTrening = form.VraceniTrening;
                treningController.DodajTrening(noviTrening);

                UcitajTreningeUI();
            }
        }

    }
}
