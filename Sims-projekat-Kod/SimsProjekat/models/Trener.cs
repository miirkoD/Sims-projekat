using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SismProjekat.models
{
    internal class Trener:Korisnik
    {
        private int dnevniBrojKlijenata;
        private List<Trening> treninzi = new List<Trening>();
        private List<Klijent> klijenti = new List<Klijent>();

        public Trener(string ime, string prezime, int dnevniBrojKlijenata,string email, string brojTelefona) : base(ime, prezime, email, brojTelefona)
        {
            this.dnevniBrojKlijenata = dnevniBrojKlijenata;

        }
        public Trener() : base()
        {
            // Prazan konstruktor za inicijalizaciju bez parametara
        }

        public void zakaziTrening(Trening trening)
        {
            Console.WriteLine("Trening je zakazan.");
            treninzi.Add(trening);
        }

        public Vezba unesiNovuVezbu(Vezba novaVezba)
        {
            Console.WriteLine("Nova vežba je unesena.");
            return novaVezba;
        }

        public void unesiNapredakKlijenta(Klijent klijent, string napredak)
        {
            if (klijent != null && !string.IsNullOrEmpty(napredak))
            {
                Console.WriteLine($"Napredak klijenta {klijent.Ime} {klijent.Prezime} je unesen: {napredak}");
            }
            else
            {
                Console.WriteLine("Greška pri unosu napretka klijenta. Proverite podatke.");
            }
        }

        public void unesiRekordKlijenta(Klijent klijent, string rekord)
        {
            if (klijent != null && !string.IsNullOrEmpty(rekord))
            {
                Console.WriteLine($"Rekord klijenta {klijent.Ime} {klijent.Prezime} je unesen: {rekord}");
            }
            else
            {
                Console.WriteLine("Greška pri unosu rekorda klijenta. Proverite podatke.");
            }
        }
    }
}
