using System;
using System.Collections.Generic;
using OTA.Classes;

namespace OTA.Classes
{
    public class BookingInfo
    {
        //public List<Passenger> Passengers { get; set; }
        // public FlightService ChosenService { get; set; }

        // public BookingInfo(FlightService chosenService)
        // {
        //     this.ChosenService = chosenService;
        // }

        /// <summary>
        /// Computes the total cabin bag of all passengers.
        /// </summary>
        /// <returns>The total cabin bag of all passengers.</returns>
        public static int GetCabinBagTotal(List<Passenger> passengers)
        {
            int cabinBagTotal = 0;

            passengers.ForEach( delegate(Passenger passenger)
            {
               cabinBagTotal += passenger.CabinBagCount; 
            });

            return cabinBagTotal;
        }
        /// <summary>
        /// Computes the total checked bag of all passengers.
        /// </summary>
        /// <returns>The total checked bag of all passengers.</returns>
        public static int GetCheckedBagTotal(List<Passenger> passengers)
        {
            int checkedBagTotal = 0;

            passengers.ForEach( delegate(Passenger passenger)
            {
               checkedBagTotal += passenger.CheckedBagCount; 
            });

            return checkedBagTotal;
        }

    }
}