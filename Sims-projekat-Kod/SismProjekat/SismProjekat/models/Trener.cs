using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SismProjekat.models
{
    internal class Trener:Korisnik
    {
        private int dnevniBrojKlijenata;
        private List<Trening> treninzi = new List<Trening>();
        private List<Klijent> klijenti = new List<Klijent>();

        public Trener(string ime, string prezime, string korisnickoIme, string lozinka, int dnevniBrojKlijenata) : base(ime, prezime, korisnickoIme, lozinka)
        {
            this.dnevniBrojKlijenata = dnevniBrojKlijenata;

        }

        public void zakaziTrening(Trening trening)
        {
            Console.WriteLine("Trening je zakazan.");
            treninzi.Add(trening);
        }

        public Vezba unesiNovuVezbu(Vezba novaVezba)
        {
            if(novaVezba.naziv.IsNullOrEmpty && novaVezba.opis.IsNullOrEmpty)
            {
                Console.WriteLine("Nova vežba je unesena.");
                return novaVezba;
            }
            //if else(novaVezba.naziv)
            else
            {
                Console.WriteLine("Greška pri unosu nove vežbe. Proverite podatke.");
                return null;
            }
        }

        public void unesiNapredakKlijenta(Klijent klijent, string napredak)
        {
            if (klijent != null && !string.IsNullOrEmpty(napredak))
            {
                Console.WriteLine($"Napredak klijenta {klijent.ime} {klijent.prezime} je unesen: {napredak}");
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
                Console.WriteLine($"Rekord klijenta {klijent.ime} {klijent.prezime} je unesen: {rekord}");
            }
            else
            {
                Console.WriteLine("Greška pri unosu rekorda klijenta. Proverite podatke.");
            }
        }
    }
}
