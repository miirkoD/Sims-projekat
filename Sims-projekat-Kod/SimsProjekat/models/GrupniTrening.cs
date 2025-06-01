using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SismProjekat.models
{
    public class GrupniTrening:Trening
    {
        private int maksimalanBrojUcesnika { get; set; }

        public GrupniTrening(DateTime datumTreninga, int maksimalanBrojUcesnika) : base(datumTreninga)
        {
            this.maksimalanBrojUcesnika = maksimalanBrojUcesnika;
        }
    }
}
