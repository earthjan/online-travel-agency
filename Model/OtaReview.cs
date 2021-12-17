using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace OTA.Model
{
    [Table("ota_review")]
    [Index(nameof(PassengerId), Name = "passenger_ID")]
    public partial class OtaReview
    {
        [Key]
        [Column("review_ID")]
        public int ReviewId { get; set; }
        [Column("passenger_ID")]
        public int PassengerId { get; set; }
        [Required]
        [Column("review")]
        public string Review { get; set; }
        [Required]
        [Column("date")]
        [StringLength(55)]
        public string Date { get; set; }

        [ForeignKey(nameof(PassengerId))]
        [InverseProperty(nameof(FlightServicePassenger.OtaReviews))]
        public virtual FlightServicePassenger Passenger { get; set; }
    }
}
