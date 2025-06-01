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
        public TrenerPanel() 
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.BackColor=Color.White;

            ListBox treningList=new ListBox { Dock=DockStyle.Fill};
            Button updateBtn=new Button { Text= "Izmeni trening", Dock=DockStyle.Bottom};
            Button deleteBtn = new Button { Text = "Obrisi trening", Dock = DockStyle.Bottom };
            Button addBtn = new Button { Text = "Dodaj trening", Dock = DockStyle.Bottom };

            treningList.Items.Add("Trening 1 - 10.06. 16:00");
            treningList.Items.Add("Trening 2 - 11.06. 18.00");

            this.Controls.Add(updateBtn);
            this.Controls.Add(deleteBtn);
            this.Controls.Add(addBtn);
            this.Controls.Add(treningList);

            updateBtn.Click += (s, e) => MessageBox.Show("Izmene treninga");
            deleteBtn.Click += (s, e) => MessageBox.Show("Brisanje treninga");
            addBtn.Click += (s, e) => MessageBox.Show("Dodavanje treninga");
        }
    }
}
