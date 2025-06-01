using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SismProjekat.models
{
    public class PersonalniTrening: Trening
    {
        private string imeIPrezimeKlijenta { get; set; }

        public PersonalniTrening(DateTime datumTreninga, string imeIPrezimeKlijenta) : base(datumTreninga)
        {
            this.imeIPrezimeKlijenta = imeIPrezimeKlijenta;
        }
    }
}
