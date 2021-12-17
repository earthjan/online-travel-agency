using System;
using System.Collections.Generic;
using OTA.Model;

namespace OTA.Classes
{
    public class PriceInfo
    {
        //public BookingInfo BookingInfo { get; init; }
        //public List<BaggagePrice> BillBaggage { get; init; }
        public decimal Fee { get; private set; } = 250.00M;
        public decimal Passengers { get; set; }
        public decimal CabinBags { get; set; }
        public decimal CheckedBags { get; set; }
        public decimal TotalPrice { get; set; }
        public string Method { get; private set; } = "Over the counter";

        public PriceInfo()
        {
            // this.BookingInfo = bookingInfo;
            // this.BillBaggage = new List<BaggagePrice>();
            // this.Passengers = this.CalcPassenger(this.passengers);
            // this.CabinBags = BaggagePrice.Calc( BookingInfo.GetCabinBagTotal(passengers) );
            // this.CheckedBags = BaggagePrice.Calc( BookingInfo.GetCheckedBagTotal(passengers) );
            // this.TotalPrice = this.SetTotalPrice(chosenService);
        }
        public decimal SetTotalPrice(Model.FlightService chosenService)
        {
            return 0.00M + 
                chosenService.Price + 
                CabinBags +
                CheckedBags +
                Passengers +
                Fee;
        } 
        public static List<BaggagePrice> CalcBaggage(List<Passenger> passengers)
        {
            var billBaggage = new List<BaggagePrice>();
            foreach (var passenger in passengers)
            {
                var baggagePrice = new BaggagePrice();
                baggagePrice.Cabin = BaggagePrice.Calc(passenger.CabinBagCount);
                baggagePrice.Checked = BaggagePrice.Calc(passenger.CheckedBagCount);

                billBaggage.Add(baggagePrice);
            }

            return billBaggage;
        }
        public decimal CalcPassenger(List<Passenger> passengers)
        {
            return passengers.Count * 1000.00M;
        }
        
    }
}