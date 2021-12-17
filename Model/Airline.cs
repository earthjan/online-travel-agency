using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace OTA.Model
{
    [Table("airline")]
    public partial class Airline
    {
        public Airline()
        {
            FlightServices = new HashSet<FlightService>();
        }

        [Key]
        [Column("airline_code")]
        public int AirlineCode { get; set; }
        [Required]
        [Column("name")]
        [StringLength(55)]
        public string Name { get; set; }

        [InverseProperty(nameof(FlightService.AirlineCodeNavigation))]
        public virtual ICollection<FlightService> FlightServices { get; set; }
    }
}
