using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SismProjekat.models
{
    public class PersonalniTrening: Trening
    {
        public string ImeIPrezimeKlijenta { get; set; }

        public PersonalniTrening(DateTime datumTreninga, string imeIPrezimeKlijenta) : base(datumTreninga)
        {
            this.ImeIPrezimeKlijenta = imeIPrezimeKlijenta;
        }

        [JsonConstructor]
        public PersonalniTrening(DateTime datumTreninga) : base(datumTreninga) { }
        
    }
}
