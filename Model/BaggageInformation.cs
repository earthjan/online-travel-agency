using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace OTA.Model
{
    [Table("baggage_information")]
    [Index(nameof(PassengerId), Name = "passenger_ID")]
    public partial class BaggageInformation
    {
        public BaggageInformation()
        {
            BillBaggages = new HashSet<BillBaggage>();
        }

        [Key]
        [Column("BI_ID")]
        public int BiId { get; set; }
        [Column("passenger_ID")]
        public int PassengerId { get; set; }
        [Column("cabin_bag_count")]
        public int? CabinBagCount { get; set; }
        [Column("checked_bag_count")]
        public int? CheckedBagCount { get; set; }

        [ForeignKey(nameof(PassengerId))]
        [InverseProperty(nameof(FlightServicePassenger.BaggageInformations))]
        public virtual FlightServicePassenger Passenger { get; set; }
        [InverseProperty(nameof(BillBaggage.Bi))]
        public virtual ICollection<BillBaggage> BillBaggages { get; set; }
    }
}
