using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace OTA.Model
{
    [Table("booked_flight_service")]
    [Index(nameof(FsId), Name = "FS_ID")]
    public partial class BookedFlightService
    {
        public BookedFlightService()
        {
            BilledBookedFlightServices = new HashSet<BilledBookedFlightService>();
        }

        [Key]
        [Column("booking_ID")]
        public int BookingId { get; set; }
        [Column("FS_ID")]
        public int FsId { get; set; }
        [Required]
        [Column("date")]
        [StringLength(45)]
        public string Date { get; set; }

        [ForeignKey(nameof(FsId))]
        [InverseProperty(nameof(FlightService.BookedFlightServices))]
        public virtual FlightService Fs { get; set; }
        [InverseProperty(nameof(BilledBookedFlightService.Booking))]
        public virtual ICollection<BilledBookedFlightService> BilledBookedFlightServices { get; set; }
    }
}
