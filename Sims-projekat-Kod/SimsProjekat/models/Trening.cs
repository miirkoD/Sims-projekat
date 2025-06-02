using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SismProjekat.models
{
    public class Trening
    {
        public DateTime DatumTreninga { get; set; }
        public List<Vezba> Vezbe { get; set; }

        public Trening(DateTime datumTreninga)
        {
            this.DatumTreninga = datumTreninga;
            this.Vezbe = new List<Vezba>();
        }

        public void dodajVezbu(Vezba vezba)
        {
            if (vezba != null)
            {
                this.Vezbe.Add(vezba);
                Console.WriteLine($"Vežba {vezba.Naziv} je dodata na trening.");
            }
            else
            {
                Console.WriteLine("Greška pri dodavanju vežbe na trening. Proverite podatke.");
            }
        }

        public void ukloniVezbu(Vezba vezba)
        {
            if (this.Vezbe.Contains(vezba))
            {
                this.Vezbe.Remove(vezba);
                Console.WriteLine($"Vežba {vezba.Naziv} je uklonjena sa treninga.");
            }
            else
            {
                Console.WriteLine("Greška pri uklanjanju vežbe sa treninga. Proverite podatke.");
            }
        }

    }
}
