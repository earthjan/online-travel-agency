using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using OTA.Pages;
using OTA.Classes;

#nullable disable

namespace OTA.Model
{
    public partial class OTADBContext : DbContext
    {
        public OTADBContext()
        {
        }

        public OTADBContext(DbContextOptions<OTADBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<BaggageInformation> BaggageInformations { get; set; }
        public virtual DbSet<BillBaggage> BillBaggages { get; set; }
        public virtual DbSet<BilledBookedFlightService> BilledBookedFlightServices { get; set; }
        public virtual DbSet<BookedFlightService> BookedFlightServices { get; set; }
        public virtual DbSet<BookedPassenger> BookedPassengers { get; set; }
        public virtual DbSet<FlightService> FlightServices { get; set; }
        public virtual DbSet<FlightServicePassenger> FlightServicePassengers { get; set; }
        public virtual DbSet<OtaReview> OtaReviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=ota;user=root;password=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>(entity =>
            {
                entity.HasKey(e => e.AirlineCode)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<BaggageInformation>(entity =>
            {
                entity.HasKey(e => e.BiId)
                    .HasName("PRIMARY");

                entity.Property(e => e.CabinBagCount).HasDefaultValueSql("'0'");

                entity.Property(e => e.CheckedBagCount).HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.BaggageInformations)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("baggage_information_ibfk_1");
            });

            modelBuilder.Entity<BillBaggage>(entity =>
            {
                entity.HasKey(e => e.BillId)
                    .HasName("PRIMARY");

                entity.Property(e => e.CabinBagPrice).HasDefaultValueSql("'0.00'");

                entity.Property(e => e.CheckedBagPrice).HasDefaultValueSql("'0.00'");

                entity.HasOne(d => d.Bi)
                    .WithMany(p => p.BillBaggages)
                    .HasForeignKey(d => d.BiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bill_baggage_ibfk_1");
            });

            modelBuilder.Entity<BilledBookedFlightService>(entity =>
            {
                entity.HasKey(e => e.BillId)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BilledBookedFlightServices)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("billed_booked_flight_service_ibfk_1");
            });

            modelBuilder.Entity<BookedFlightService>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.Fs)
                    .WithMany(p => p.BookedFlightServices)
                    .HasForeignKey(d => d.FsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booked_flight_service_ibfk_1");
            });

            modelBuilder.Entity<BookedPassenger>(entity =>
            {
                entity.HasKey(e => new { e.BookedId, e.PassengerId })
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<FlightService>(entity =>
            {
                entity.HasKey(e => e.FsId)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.AirlineCodeNavigation)
                    .WithMany(p => p.FlightServices)
                    .HasForeignKey(d => d.AirlineCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flight_service_ibfk_1");
            });

            modelBuilder.Entity<FlightServicePassenger>(entity =>
            {
                entity.HasKey(e => e.PassengerId)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<OtaReview>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.OtaReviews)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ota_review_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public static List<FlightServicePassenger> GetAllFlightServicePassenger()
        {
            using (var db = new OTADBContext())
            {
                var passengers = db.FlightServicePassengers.ToList();
                return passengers;
            }
        }

        public static FlightServicePassenger GetNewFlightServicePassenger()
        {
            using (var db = new OTADBContext())
            {
                var newPassenger = db.FlightServicePassengers.
                                    ToList().
                                    OrderByDescending(x => x.PassengerId).
                                    Take(1).
                                    First();

                return newPassenger;
            }
        }
        public static BilledBookedFlightService GetNewBilledBookedFlightService()
        {
            using (var db = new OTADBContext())
            {
                var newTuple = db.BilledBookedFlightServices.
                                    ToList().
                                    OrderByDescending(x => x.BillId).
                                    Take(1).
                                    First();

                return newTuple;
            }
        }

        public static BookedFlightService GetNewBookedFlightService()
        {
            using (var db = new OTADBContext())
            {
                var newTuple = db.BookedFlightServices.
                                    ToList().
                                    OrderByDescending(x => x.BookingId).
                                    Take(1).
                                    First();

                return newTuple;
            }
        }

        public static BaggageInformation GetNewBaggageInformation()
        {
            using (var db = new OTADBContext())
            {
                var newTuple = db.BaggageInformations.
                                    ToList().
                                    OrderByDescending(x => x.BiId).
                                    Take(1).
                                    First();

                return newTuple;
            }
        }

        public static FlightService GetFlightService(int fsId)
        {
            using (var db = new OTADBContext())
            {
                var newTuple = db.FlightServices.
                                    ToList().
                                    Where(x => x.FsId == fsId).
                                    First();

                return newTuple;
            }
        }

        /// <summary>
        /// Gets a set of flight services based on the parameters.
        /// </summary>
        /// <param name="totalPassengers">Is the total of passengers in a book.</param>
        /// <param name="origin">Is the origin of a book.</param>
        /// <param name="destination">Is the destination of a book.</param>
        /// <param name="tripType">Is the trip type of a book.</param>
        /// <param name="cabinClass">Is the cabin class of a book.</param>
        /// <returns>A set of queried flight services.</returns>
        public List<FlightService> GetFlightServices(int totalPassengers, string origin, string destination, string tripType, string cabinClass)
        {   
            string table = "flight_service";
            string tripTypeCol = "trip_type";
            string cabinClassCol = "cabin_class";
            string originCol = "origin";
            string destinationCol = "destination";
            string noOfBookedPassengersCol = "no_of_booked_passengers";
            string maxPassengersCol = "max_passengers";

            var preResults = this.FlightServices.FromSqlRaw($"SELECT * FROM {table} WHERE {noOfBookedPassengersCol} < {maxPassengersCol} AND {tripTypeCol} = '{tripType}' AND {cabinClassCol} = '{cabinClass}' AND {originCol} = '{origin}' AND {destinationCol} = '{destination}'").ToList();

            var finalResult = new List<FlightService>();

            preResults.ForEach(flightService => {
                var availableSeats = flightService.MaxPassengers - flightService.NoOfBookedPassengers;

                if(availableSeats >= totalPassengers)  
                    finalResult.Add(flightService);
            });

            return finalResult;
        }
    
        /// <summary>
        /// Uniquely gets the origins of all available flight services.
        /// </summary>
        /// <returns>List of unique origins</returns>
        public List<string> GetOrigins()
        {
            string column = "*";
            string table = "flight_service";

            var flightServices = this.FlightServices.FromSqlRaw($"SELECT {column} FROM {table};").ToList();
            
            var origins = new List<string>();

            flightServices.ForEach(flightService => {
                origins.Add(flightService.Origin);
            });

            return origins.Distinct().ToList();
        }

        /// <summary>
        /// Uniquely gets the destinations of all available flight services.
        /// </summary>
        /// <returns>List of unique destinations</returns>
        public List<string> GetDestinations()
        {
            string column = "*";
            string table = "flight_service";

            var flightServices = this.FlightServices.FromSqlRaw($"SELECT {column} FROM {table};").ToList();
            
            var destinations = new List<string>();

            flightServices.ForEach(flightService => {
                destinations.Add(flightService.Destination);
            });

            return destinations.Distinct().ToList();
        }


        public static bool InsertFlightServicePassenger(
            string givenName, string middleName, string surname,
            string gender, string birthDate, string passportOrIDNo,
            string passportOrIDExpiryDate, string email, string mobileNo)
        {
            using (var db = new OTADBContext())
            {
                var newTuple = new FlightServicePassenger()
                {
                    PassengerId = FourthProcessPageModel.generateCode(),
                    GivenName = givenName,
                    MiddleName = middleName,
                    Surname = surname,
                    Gender = gender,
                    Birthdate = birthDate,
                    PassportOrIdNo = passportOrIDNo,
                    PassportOrIdExpiryDate = passportOrIDExpiryDate,
                    Email = email,
                    MobileNo = mobileNo
                };

                db.FlightServicePassengers.Add(newTuple);

                var affected = db.SaveChanges();

                return (affected == 1);
            }
        }

        public static bool InsertBaggageInformation(int passengerId, int cabinBagCount, int checkedBagCount)
        {
            using (var db = new OTADBContext())
            {
                var newTuple = new BaggageInformation()
                {
                    PassengerId = passengerId,
                    CabinBagCount = cabinBagCount,
                    CheckedBagCount = checkedBagCount
                };

                db.BaggageInformations.Add(newTuple);

                var affected = db.SaveChanges();

                return (affected == 1);
            }
        }

        public static bool InsertBookedPassenger(int bookedId, int passengerId)
        {
            using (var db = new OTADBContext())
            {
                var newTuple = new BookedPassenger()
                {
                    BookedId = bookedId,
                    PassengerId = passengerId
                };

                db.BookedPassengers.Add(newTuple);

                var affected = db.SaveChanges();

                return (affected == 1);
            }
        }

        public static bool InsertBookedFlightService(int fsId, string date)
        {
            using (var db = new OTADBContext())
            {
                var newTuple = new BookedFlightService()
                {
                    FsId = fsId,
                    Date = date
                };

                db.BookedFlightServices.Add(newTuple);

                var affected = db.SaveChanges();

                return (affected == 1);
            }
        }

        public static bool InsertBilledBookedFlightService(
            int bookingId, string method, decimal totalPrice
        )
        {
            using (var db = new OTADBContext())
            {
                var newTuple = new BilledBookedFlightService()
                {
                    BookingId = bookingId,
                    Method = method,
                    TotalPrice = totalPrice
                };

                db.BilledBookedFlightServices.Add(newTuple);

                var affected = db.SaveChanges();

                return (affected == 1);
            }
        }

        public static bool InsertBillBaggage(
            int billId, int biId, decimal cabinBagPrice, decimal checkedBagPrice
        )
        {
            using (var db = new OTADBContext())
            {
                var newTuple = new BillBaggage()
                {
                    BillId = billId,
                    BiId = biId,
                    CabinBagPrice = cabinBagPrice,
                    CheckedBagPrice = checkedBagPrice
                };

                db.BillBaggages.Add(newTuple);

                var affected = db.SaveChanges();

                return (affected == 1);
            }
        }
    }
}
