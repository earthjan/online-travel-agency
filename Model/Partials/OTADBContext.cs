using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OTA.Classes;
using OTA.Pages;

namespace OTA.Model
{
    public partial class OTADBContext
    {
        private string ConnectionString = Environment.GetEnvironmentVariable(Configs.Variable, EnvironmentVariableTarget.Machine);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                if (this.ConnectionString == null)
                    throw new("Check your connection string.");

                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseMySQL(this.ConnectionString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

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

        public Airline GetAirline(int id)
        {
            var table = "airline";
            var airlineCodeCol = "airline_code";

            var airline = this.Airlines.FromSqlRaw($"SELECT * FROM {table} WHERE {airlineCodeCol} = {id}").Single();

            return airline;
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

        public static bool InsertBillBaggage(int biId, decimal cabinBagPrice, decimal checkedBagPrice
        )
        {
            using (var db = new OTADBContext())
            {
                var newTuple = new BillBaggage()
                {
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