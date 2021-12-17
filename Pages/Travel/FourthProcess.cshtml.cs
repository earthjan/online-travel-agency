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

namespace OTA.Pages
{
    public class FourthProcessPageModel : PageModel
    {
        // I commented the BookingInfo field because only this handler method seems to access its data.
        // private BookingInfo bookingInfo;
        public PriceInfo PriceInfo;
        public int CabinBagCount;
        public int CheckedBagCount;
        public string ExpirationDate = GetNextWeekDate();
        public int GeneratedCode = generateCode();
        public decimal Fee = 250.00M;

        /// <summary>
        /// Generates 6-digit code.
        /// It Is mainly used for one-time code generation.
        /// </summary>
        /// <returns>6-digit code</returns>
        public static int generateCode() => new Random().Next(111111, 999999);

        // Continue troubleshooting the bookinginfo here while serializing
        public void OnGetPrice()
        {
            // Gets the TempData["Passengers"] to compute bill baggage.
            var strPassengers = TempData["Passengers"] as string;
            var passengers = JsonSerializer.Deserialize<List<Passenger>>(strPassengers);

            // Gets the TempData["ChosenService"] to compute the total price in PriceInfo.
            var strChosenService = TempData["ChosenService"] as string;
            var chosenService = JsonSerializer.Deserialize<Model.FlightService>(strChosenService);

            // I commented the BookingInfo field because only this handler method seems to access its data.
            // Initializes the field.
            // this.bookingInfo = bookingInfo;

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

            // Saves the objects as TempData so that OnPostDone() can access them to store
            // their data in the DB.
            TempData["BillBaggage"] = JsonSerializer.Serialize(billBaggage);
            TempData["PriceInfo"] = JsonSerializer.Serialize(this.PriceInfo);
            TempData["ChosenService"] = JsonSerializer.Serialize(chosenService);
            TempData["Passengers"] = JsonSerializer.Serialize(passengers);
        }

        public IActionResult OnPostDone()
        {
            // Gets the TempData to store the object's data in the DB.
            var strPassengers = TempData["Passengers"] as string;
            var passengers = JsonSerializer.Deserialize<List<Passenger>>(strPassengers);

            // Gets the TempData to store the object's data in the DB.
            var strChosenService = TempData["ChosenService"] as string;
            var chosenService = JsonSerializer.Deserialize<Model.FlightService>(strChosenService);

            // Gets the TempData to store the object's data in the DB.
            var strBillBaggage = TempData["BillBaggage"] as string;
            var billBaggage = JsonSerializer.Deserialize<List<BaggagePrice>>(strBillBaggage);

            // Gets the TempData to store the object's data in the DB.
            var strPriceInfo = TempData["PriceInfo"] as string;
            var priceInfo = JsonSerializer.Deserialize<PriceInfo>(strPriceInfo);

            // These are the values that should be stored in the DB.
            WriteLine("For booked_flight_service");
            OTADBContext.InsertBookedFlightService(chosenService.FsId, DateTime.Now + "");
            var bookedFlightService = OTADBContext.GetNewBookedFlightService();

            WriteLine("For billed_booked_flight_service");
            OTADBContext.InsertBilledBookedFlightService(bookedFlightService.BookingId, priceInfo.Method, priceInfo.TotalPrice);
            var billedBookedFlightService = OTADBContext.GetNewBilledBookedFlightService();

            WriteLine("For flight_service_passenger");

            var passenger = passengers.First();
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

            WriteLine("For baggage_information");
            OTADBContext.InsertBaggageInformation(
                    newPassenger.PassengerId,
                    passenger.CabinBagCount,
                    passenger.CheckedBagCount);


            var newBag = OTADBContext.GetNewBaggageInformation();

            WriteLine("For bill-baggage");
            var baggagePrice = billBaggage.First();
            OTADBContext.InsertBillBaggage(
                billedBookedFlightService.BillId,
                newBag.BiId,
                baggagePrice.Cabin,
                baggagePrice.Checked
            );

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