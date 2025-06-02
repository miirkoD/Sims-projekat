using System;

namespace SismProjekat.models
{
    public class Vezba
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public string PathSlike {  get; set; }

        public Vezba() { }

        public Vezba(string naziv, string opis)
        {
            this.Naziv = naziv;
            this.Opis = opis;
        }

        public void dodajSliku()
        {
            Console.WriteLine("Slika je dodata");
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}