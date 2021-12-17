using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace OTA.Model
{
    [Table("flight_service")]
    [Index(nameof(AirlineCode), Name = "airline_code")]
    public partial class FlightService
    {
        public FlightService()
        {
            BookedFlightServices = new HashSet<BookedFlightService>();
        }

        [Key]
        [Column("FS_ID")]
        public int FsId { get; set; }
        [Column("airline_code")]
        public int AirlineCode { get; set; }
        [Column("price", TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        [Required]
        [Column("duration")]
        [StringLength(45)]
        public string Duration { get; set; }
        [Required]
        [Column("departure_schedule")]
        [StringLength(45)]
        public string DepartureSchedule { get; set; }
        [Required]
        [Column("arrival_schedule")]
        [StringLength(45)]
        public string ArrivalSchedule { get; set; }
        [Required]
        [StringLength(45)]
        public string Origin { get; set; }
        [Required]
        [StringLength(45)]
        public string Destination { get; set; }
        [Required]
        [Column("flight_number")]
        [StringLength(45)]
        public string FlightNumber { get; set; }
        [Required]
        [Column("fare_type")]
        [StringLength(45)]
        public string FareType { get; set; }
        [Required]
        [Column("cabin_class")]
        [StringLength(45)]
        public string CabinClass { get; set; }
        [Required]
        [Column("trip_type")]
        [StringLength(45)]
        public string TripType { get; set; }
        [Column("no_of_booked_passengers")]
        public int NoOfBookedPassengers { get; set; }
        [Column("max_passengers")]
        public int MaxPassengers { get; set; }

        [ForeignKey(nameof(AirlineCode))]
        [InverseProperty(nameof(Airline.FlightServices))]
        public virtual Airline AirlineCodeNavigation { get; set; }
        [InverseProperty(nameof(BookedFlightService.Fs))]
        public virtual ICollection<BookedFlightService> BookedFlightServices { get; set; }
    }
}
