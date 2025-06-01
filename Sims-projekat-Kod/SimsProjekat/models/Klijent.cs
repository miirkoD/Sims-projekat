using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SismProjekat.models
{
    public class Klijent:Korisnik
    {
        private string adresaQrKoda { get; }

        public Klijent(string ime, string prezime, string email, string brojTelefona) : base(ime, prezime, email, brojTelefona)
        {
        }

        public void platiClanarinu()
        {
            Console.WriteLine("Članarina je plaćena.");
        }

        public void prijavaZaTrening(string imeTrenera, Trening trening)
        {
            if (trening != null && !string.IsNullOrEmpty(imeTrenera))
            {
                Console.WriteLine($"Klijent {ime} {prezime} se prijavio za trening sa trenerom {imeTrenera}.");
            }
            else
            {
                Console.WriteLine("Greška pri prijavi na trening. Proverite podatke.");
            }
        }
    }
}
