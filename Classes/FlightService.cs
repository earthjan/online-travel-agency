using System;
namespace OTA.Classes
{
    public class FlightService
    {
        public int FS_ID { get; private set; }
        public decimal Price { get; private set; }
        public int Duration { get; private set; }
        public DateTime DepartureSchedule { get; private set; }
        public DateTime ArrivalSchedule { get; private set; }
        public string Origin { get; private set; }
        public string Destination { get; private set; }
        public int FlightNumber { get; private set; }
        public string FareType { get; private set; }
        public string CabinClass { get; private set; }
        public string TripType { get; private set; }

        public FlightService(int FS_ID, decimal price, int duration, 
            DateTime departureSchedule, DateTime arrivalSchedule,
            string origin, string destination, int flightNumber,
            string fareType, string cabinClass, string tripType)
        {
            this.FS_ID = FS_ID;
            this.Price = price;
            this.Duration = duration;
            this.DepartureSchedule = departureSchedule;
            this.ArrivalSchedule = arrivalSchedule;
            this.Origin = origin;
            this.Destination = destination;
            this.FlightNumber = flightNumber;
            this.FareType = fareType;
            this.CabinClass = cabinClass;
            this.TripType = tripType;
        }

    }
}