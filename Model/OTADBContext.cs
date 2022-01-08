using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
    }
}
