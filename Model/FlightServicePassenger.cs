using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace OTA.Model
{
    [Table("flight_service_passenger")]
    public partial class FlightServicePassenger
    {
        public FlightServicePassenger()
        {
            BaggageInformations = new HashSet<BaggageInformation>();
            OtaReviews = new HashSet<OtaReview>();
        }

        [Key]
        [Column("passenger_ID")]
        public int PassengerId { get; set; }
        [Required]
        [Column("given_name")]
        [StringLength(55)]
        public string GivenName { get; set; }
        [Required]
        [Column("middle_name")]
        [StringLength(45)]
        public string MiddleName { get; set; }
        [Required]
        [Column("surname")]
        [StringLength(45)]
        public string Surname { get; set; }
        [Required]
        [Column("gender")]
        [StringLength(6)]
        public string Gender { get; set; }
        [Required]
        [Column("birthdate")]
        [StringLength(55)]
        public string Birthdate { get; set; }
        [Required]
        [Column("passport_or_ID_no")]
        [StringLength(45)]
        public string PassportOrIdNo { get; set; }
        [Required]
        [Column("passport_or_ID_expiry_date")]
        [StringLength(45)]
        public string PassportOrIdExpiryDate { get; set; }
        [Required]
        [Column("email")]
        [StringLength(55)]
        public string Email { get; set; }
        [Required]
        [Column("mobile_no")]
        [StringLength(45)]
        public string MobileNo { get; set; }

        [InverseProperty(nameof(BaggageInformation.Passenger))]
        public virtual ICollection<BaggageInformation> BaggageInformations { get; set; }
        [InverseProperty(nameof(OtaReview.Passenger))]
        public virtual ICollection<OtaReview> OtaReviews { get; set; }
    }
}
