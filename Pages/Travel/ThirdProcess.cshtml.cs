using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using static System.Console;
using System.Text.Json;
using static Newtonsoft.Json.JsonConvert;
using OTA.Classes;
using OTA.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace OTA.Pages
{
    public class ThirdProcessPageModel : PageModel
    {
        // private List<Passenger> passengers;
        // private BookingInfo bookingInfo;
        public PassengersService PassengersService;

        public void OnGetForm()
        {
            // Gets TempData["PassengersService"] to display appropriate values.
            var strPassengersService = TempData["PassengersService"] as string;
            var passengersService = JsonSerializer.Deserialize<PassengersService>(strPassengersService);

            // Lets this controller's page access some data in the PassengersService 
            // given by SecondProcessPageModel.
            this.PassengersService = passengersService;

            // Lets OnPostBook() access the PassengersService 
            // given by SecondProcessPageModel.
            TempData["PassengersService"] = JsonSerializer.Serialize(this.PassengersService);
        }

        public IActionResult OnPostBook(int total)
        {
            var passengers = new List<Passenger>();

            // Processes each passenger form section.
            // Creates the passenger collection to be able to 
            // construct BookingInfo.
            for (int i = 0; i < total; i++)
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
                    "" + Request.Form[givenName],
                    "" + Request.Form[surname],
                    "" + Request.Form[nationality],
                    "" + Request.Form[gender],
                    "" + Request.Form[dateOfBirth],
                    "" + Request.Form[passportOrIDNumber],
                    "" + Request.Form[passportOrIDExpiryDate],
                    "" + Request.Form["email"],
                    "" + Request.Form["phone"],
                    Int32.Parse(Request.Form[cabinBag]),
                    Int32.Parse(Request.Form[checkedBag])
                );

                passengers.Add(passenger);
            }

            // Gets TempData["PassengersService"] to get the chosen service to be able
            // to construct BookingInfo.
            var strPassengersService = TempData["PassengersService"] as string;
            var passengersService = JsonSerializer.Deserialize<PassengersService>(strPassengersService);

            // These two data were fields of BookingInfo, but there are conflicts so they were isolated.
            TempData["Passengers"] = JsonSerializer.Serialize(passengers);
            TempData["ChosenService"] = JsonSerializer.Serialize<Model.FlightService>(passengersService.ChosenService);

            return RedirectToPage("FourthProcess", "Price");
        }
    }
}

