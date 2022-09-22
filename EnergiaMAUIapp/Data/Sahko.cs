using System;
using System.Collections.Generic;

namespace EnergiaBackend.Data
{
    public partial class Sahko
    {
        public int SahkoId { get; set; }
        public string Pvm { get; set; } = null!;
        public decimal Summa { get; set; }
        public decimal Kwh { get; set; }
    }
}
