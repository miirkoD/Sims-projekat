using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SismProjekat.models
{
    public abstract class Korisnik
    {
        private abstract string ime { get; }
        private abstract string prezime { get; }
        private abstract string email { get; }
        private abstract string brojTelefona { get; }

        public Korisnik(string ime, string prezime, string email, string brojTelefona)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.email = email;
            this.brojTelefona = brojTelefona;
        }

        public override string ToString()
        {
            return $"Ime i preizime korisnika ime  {ime} {prezime}, Email: {email}, Telefon: {brojTelefona}";
        }

        public void prijava()
        {
            System.Console.WriteLine("Korisnik se prijavio.");
        }

        public void odjava()
        {
            System.Console.WriteLine("Korisnik se odjavio.");
        }
        public void registracija()
        {
            System.Console.WriteLine("Korisnik se registrovao.");
        }
    }
}
