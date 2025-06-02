using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SismProjekat.models
{
    public class GrupniTrening:Trening
    {
        public int MaksimalanBrojUcesnika { get; set; }

        public GrupniTrening(DateTime datumTreninga, int maksimalanBrojUcesnika) : base(datumTreninga)
        {
            this.MaksimalanBrojUcesnika = maksimalanBrojUcesnika;
        }

        [JsonConstructor]
        public GrupniTrening(DateTime datumTreninga) : base(datumTreninga)
        {
           
        }
    }
}
