using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SismProjekat.models
{
    public class Vezba
    {
        private string naziv { get; set; }
        private string opis { get; set; }

        public Vezba(string naziv, string opis)
        {
            this.naziv = naziv;
            this.opis = opis;
        }

        public void dodajSliku()
        {
            Console.WriteLine("Slika je dodata za vežbu " + naziv + ".");
        }

    }

}