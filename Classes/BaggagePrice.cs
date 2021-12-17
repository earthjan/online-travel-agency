using System;

namespace OTA.Classes
{
    public class BaggagePrice
    {
        public Passenger passenger;
        public decimal Cabin { get; set; }
        public decimal Checked { get; set; }

        public BaggagePrice()
        {
            // this.passenger = passenger;
            // this.Cabin = BaggagePrice.Calc(this.passenger.CabinBagCount);
            // this.Checked = BaggagePrice.Calc(this.passenger.CheckedBagCount);
        }

        public static decimal Calc(int quantity) => 1000.00M * quantity;
    }
}