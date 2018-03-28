using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab3_MVC_.Models
{
    public partial class Settlements
    {
        public int SettlementId { get; set; }
        public int Iddistrict { get; set; }

        [Required]
        [RegularExpression("[A-Za-z]+'?[A-Za-z]*", ErrorMessage = "Only letters could be used")]
        public string Name { get; set; }

        public string Type { get; set; }

        [Required]
        public int Population { get; set; }
    }
}
