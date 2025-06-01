using System;

namespace SismProjekat.models
{
    public class Vezba
    {
        protected string naziv { get; set; }
        protected string opis { get; set; }

        public Vezba() { }

        public Vezba(string naziv, string opis)
        {
            this.naziv = naziv;
            this.opis = opis;
        }

        public void dodajSliku()
        {
            Console.WriteLine("Slika je dodata");
        }

        public string Naziv
        {
            get { return naziv; }
        }
        public string Opis
        {
            get { return opis; }
        }
    }
}