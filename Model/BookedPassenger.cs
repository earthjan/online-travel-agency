using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace OTA.Model
{
    [Table("booked_passenger")]
    public partial class BookedPassenger
    {
        [Key]
        [Column("booked_ID")]
        public int BookedId { get; set; }
        [Key]
        [Column("passenger_ID")]
        public int PassengerId { get; set; }
    }
}
