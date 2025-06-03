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
        public int BrojUcesnika { get; set; } = 0;

        //public GrupniTrening(DateTime datumTreninga, int maksimalanBrojUcesnika) : base(datumTreninga)
        //{
        //    this.MaksimalanBrojUcesnika = maksimalanBrojUcesnika;
        //}
        [JsonConstructor]
        public GrupniTrening(DateTime datumTreninga, int maksimalanBrojUcesnika, int brojUcesnika) : base(datumTreninga)
        {
            this.MaksimalanBrojUcesnika = maksimalanBrojUcesnika;
            this.BrojUcesnika = brojUcesnika;
        }

        //[JsonConstructor]
        //public GrupniTrening(DateTime datumTreninga) : base(datumTreninga)
        //{
           
        //}
    }
}
