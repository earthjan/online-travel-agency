using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace OTA.Model
{
    [Table("billed_booked_flight_service")]
    [Index(nameof(BookingId), Name = "booking_ID")]
    public partial class BilledBookedFlightService
    {
        [Key]
        [Column("bill_ID")]
        public int BillId { get; set; }
        [Column("booking_ID")]
        public int BookingId { get; set; }
        [Required]
        [Column("method")]
        [StringLength(45)]
        public string Method { get; set; }
        [Column("total_price", TypeName = "decimal(6,2)")]
        public decimal TotalPrice { get; set; }

        [ForeignKey(nameof(BookingId))]
        [InverseProperty(nameof(BookedFlightService.BilledBookedFlightServices))]
        public virtual BookedFlightService Booking { get; set; }
    }
}
