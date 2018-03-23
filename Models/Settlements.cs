using System;
using System.Collections.Generic;

namespace Lab3_MVC_.Models
{
    public partial class Settlements
    {
        public int Id { get; set; }
        public int Iddistrict { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Population { get; set; }
    }
}
