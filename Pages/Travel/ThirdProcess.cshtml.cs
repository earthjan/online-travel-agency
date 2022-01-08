using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using static System.Console;
using System.Text.Json;
using static Newtonsoft.Json.JsonConvert;
using OTA.Classes;
using OTA.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OTA.Pages
{
    public class ThirdProcessPageModel : PageModel
    {
        // private List<Passenger> passengers;
        // private BookingInfo bookingInfo;
        public PassengersService PassengersService;

        /// <summary>
        /// Gets the number of passengers and the chosen service from the second process to give an appropriate number of forms and display the service on this pagemodel's page.
        /// </summary>
        public void OnGetForm()
        {
            var strPassengersService = TempData.Peek("PassengersService") as string;
            var passengersService = System.Text.Json.JsonSerializer.Deserialize<PassengersService>(strPassengersService);
            
            this.PassengersService = passengersService;
        }

        public IActionResult OnPostBook()
        {
            var strPassengersService = TempData.Peek("PassengersService") as string;
            var passengersService = System.Text.Json.JsonSerializer.Deserialize<PassengersService>(strPassengersService);

            var totalPassenger = passengersService.NumberOfPassenger.GetTotal();

            var passengers = new List<Passenger>();

            // Processes each passenger form section.
            // Creates the passenger collection to be able to 
            // construct BookingInfo.
            for (int i = 0; i < totalPassenger; i++)
            {
                string givenName = "given_name" + i,
                        surname = "surname" + i,
                        nationality = "nationality" + i,
                        gender = "gender" + i,
                        dateOfBirth = "date_of_birth" + i,
                        passportOrIDNumber = "passport_or_id_number" + i,
                        passportOrIDExpiryDate = "passport_or_id_expiry_date" + i,
                        cabinBag = "cabin_bag" + i,
                        checkedBag = "checked_bag" + i;

                var passenger = new Passenger(
                    Utility.Remove("" + Request.Form[givenName]),
                    Utility.Remove("" + Request.Form[surname]),
                    Utility.Remove("" + Request.Form[nationality]),
                    "" + Request.Form[gender],
                    "" + Request.Form[dateOfBirth],
                    Utility.Remove("" + Request.Form[passportOrIDNumber]),
                    "" + Request.Form[passportOrIDExpiryDate],
                    Utility.CleanEmail("" + Request.Form["email"]),
                    Utility.Remove("" + Request.Form["phone"]),
                    Int32.Parse(Request.Form[cabinBag]),
                    Int32.Parse(Request.Form[checkedBag])
                );

                passengers.Add(passenger);
            }

            // These two data were fields of BookingInfo, but there are conflicts so they were isolated.
            TempData["Passengers"] = JsonConvert.SerializeObject(passengers);
            TempData["ChosenService"] = System.Text.Json.JsonSerializer.Serialize<Model.FlightService>(passengersService.ChosenService);

            return RedirectToPage("FourthProcess", "Price");
        }
    }
}

