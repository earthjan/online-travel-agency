using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace OTA.Model
{
    [Table("bill_baggage")]
    [Index(nameof(BiId), Name = "BI_ID")]
    public partial class BillBaggage
    {
        [Key]
        [Column("bill_ID")]
        public int BillId { get; set; }
        [Column("BI_ID")]
        public int BiId { get; set; }
        [Column("cabin_bag_price", TypeName = "decimal(6,2)")]
        public decimal? CabinBagPrice { get; set; }
        [Column("checked_bag_price", TypeName = "decimal(6,2)")]
        public decimal? CheckedBagPrice { get; set; }

        [ForeignKey(nameof(BiId))]
        [InverseProperty(nameof(BaggageInformation.BillBaggages))]
        public virtual BaggageInformation Bi { get; set; }
    }
}
