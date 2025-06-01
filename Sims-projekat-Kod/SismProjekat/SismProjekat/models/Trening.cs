using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SismProjekat.models
{
    public class Trening
    {
        private DateTime datumTreninga { get; set; }
        private List<Vezba> vezbe { get;}

        public Trening(DateTime datumTreninga)
        {
            this.datumTreninga = datumTreninga;
        }

        public void dodajVezbu(Vezba vezba)
        {
            if (vezba != null)
            {
                vezbe.Add(vezba);
                Console.WriteLine($"Vežba {vezba.naziv} je dodata na trening.");
            }
            else
            {
                Console.WriteLine("Greška pri dodavanju vežbe na trening. Proverite podatke.");
            }
        }

        public void ukloniVezbu(Vezba vezba)
        {
            if (vezbe.Contains(vezba))
            {
                vezbe.Remove(vezba);
                Console.WriteLine($"Vežba {vezba.naziv} je uklonjena sa treninga.");
            }
            else
            {
                Console.WriteLine("Greška pri uklanjanju vežbe sa treninga. Proverite podatke.");
            }
        }

    }
}
