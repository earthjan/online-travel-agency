using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Text.Json;
using static System.Console;
using OTA.Classes;
using OTA.Model;
using Microsoft.AspNetCore.Mvc;
using static Newtonsoft.Json.JsonConvert;
using System.Linq;
using Newtonsoft.Json;

namespace OTA.Pages
{
    public class FourthProcessPageModel : PageModel
    {
        private readonly OTADBContext _context;

        public PriceInfo PriceInfo;

        public int CabinBagCount;

        public int CheckedBagCount;

        public int FlightNumber;

        public string AirlineProvider;

        //isn't stored in the OTA DB because it comes from an airline provider DB.
        public string ExpirationDate = GetNextWeekDate();

        //isn't stored in the OTA DB because it comes from an airline provider DB.
        public int GeneratedCode = generateCode();

        //isn't stored in the OTA DB because it comes from an airline provider DB.
        public decimal Fee = 250.00M;

        /// <summary>
        /// Generates 6-digit code.
        /// It Is mainly used for one-time code generation.
        /// </summary>
        /// <returns>6-digit code</returns>
        public static int generateCode() => new Random().Next(111111, 999999);

        public FourthProcessPageModel(OTADBContext context)
        {
            this._context = context;
        }

        public void OnGetPrice()
        {
            // Gets the TempData["Passengers"] to compute bill baggage.
            var strPassengers = TempData.Peek("Passengers") as string;
            var passengers = JsonConvert.DeserializeObject<List<Passenger>>(strPassengers);

            // Gets the TempData["ChosenService"] to compute the total price in PriceInfo.
            var strChosenService = TempData.Peek("ChosenService") as string;
            var chosenService = System.Text.Json.JsonSerializer.Deserialize<Model.FlightService>(strChosenService);

            this.FlightNumber = chosenService.FsId;

            this.AirlineProvider = this._context.GetAirline(chosenService.AirlineCode).Name;

            // To display what things are billed.
            this.CabinBagCount = BookingInfo.GetCabinBagTotal(passengers);
            this.CheckedBagCount = BookingInfo.GetCheckedBagTotal(passengers);

            this.PriceInfo = new PriceInfo();

            this.PriceInfo.Passengers = this.PriceInfo.CalcPassenger(passengers);
            this.PriceInfo.CabinBags = BaggagePrice.Calc(BookingInfo.GetCabinBagTotal(passengers));
            this.PriceInfo.CheckedBags = BaggagePrice.Calc(BookingInfo.GetCheckedBagTotal(passengers));
            this.PriceInfo.TotalPrice = this.PriceInfo.SetTotalPrice(chosenService);

            // Processes the bill of bags of a respective passenger.
            var billBaggage = PriceInfo.CalcBaggage(passengers);

            //TempData["BillBaggage"] = JsonSerializer.Serialize(billBaggage);
            TempData["BillBaggage"] = JsonConvert.SerializeObject(billBaggage);
            TempData["PriceInfo"] = System.Text.Json.JsonSerializer.Serialize(this.PriceInfo);
        }

        public IActionResult OnPostDone()
        {
            var strPassengers = TempData["Passengers"] as string;
            var passengers = System.Text.Json.JsonSerializer.Deserialize<List<Passenger>>(strPassengers);

            var strChosenService = TempData["ChosenService"] as string;
            var chosenService = System.Text.Json.JsonSerializer.Deserialize<Model.FlightService>(strChosenService);

            var strBillBaggage = TempData["BillBaggage"] as string;
            var billBaggage = JsonConvert.DeserializeObject<List<BaggagePrice>>(strBillBaggage);

            var strPriceInfo = TempData["PriceInfo"] as string;
            var priceInfo = System.Text.Json.JsonSerializer.Deserialize<PriceInfo>(strPriceInfo);

            OTADBContext.InsertBookedFlightService(chosenService.FsId, DateTime.Now + "");

            var bookedFlightService = OTADBContext.GetNewBookedFlightService();

            OTADBContext.InsertBilledBookedFlightService(bookedFlightService.BookingId, priceInfo.Method, priceInfo.TotalPrice);

            passengers.ForEach(passenger =>
            {
                OTADBContext.InsertFlightServicePassenger(
                passenger.GivenName,
                passenger.MiddleName,
                passenger.Surname,
                passenger.Gender,
                passenger.BirthDate,
                passenger.PassportOrIDNo,
                passenger.PassportOrIDExpiryDate,
                passenger.Email,
                passenger.MobileNo);

                var newPassenger = OTADBContext.GetNewFlightServicePassenger();

                OTADBContext.InsertBaggageInformation(
                    newPassenger.PassengerId,
                    passenger.CabinBagCount,
                    passenger.CheckedBagCount);

                var newBag = OTADBContext.GetNewBaggageInformation();

                var baggagePrice = billBaggage.Find(b => b.passenger == passenger);

                OTADBContext.InsertBillBaggage(
                newBag.BiId,
                baggagePrice.Cabin,
                baggagePrice.Checked);
            });
            
            return RedirectToPage("landingpage");
        }

        /// <summary>
        /// Determines the next week date-time that is relative with when the code is executed.
        /// </summary>
        /// <returns>Next week date with the following format: DD/MM/YYYY HH:MM AM/PM. </returns>
        static string GetNextWeekDate()
        {
            DateTime result = DateTime.Now.AddDays(1);
            DayOfWeek dayNow = DateTime.Now.DayOfWeek;

            while (result.DayOfWeek != dayNow)
                result = result.AddDays(1);

            // DD/MM/YYYY HH:MM AM/PM
            string formattedDate = $"{result.Day}/{result.Month}/{result.Year} {DateTime.Now.Hour.ToString()}:{DateTime.Now.Minute.ToString()} {DateTime.Now.ToString("tt")}";

            return formattedDate;
        }

    }
}