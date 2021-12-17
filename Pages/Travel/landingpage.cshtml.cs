using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using static System.Console;
using OTA.Classes;
using OTA.Pages;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using OTA.Model;

namespace OTA.Pages
{
    public class LandingPagePageModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Adult { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Child { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Infant { get; set; }
        private NumberOfPassenger numberOfPassenger;
        public string Background { get; private set; }
        // This property is accessed by "landingpage" page to get "Suggested flights" data.
        public IEnumerable<SuggestedFlight> SuggestedFlights { get; private set; }

        public void OnGet()
        {

            ViewData["Title"] = "Travel OTA Name";
            // Data of "SuggestedFlights" should come from the DB.
            SuggestedFlights = new SuggestedFlight[] {
                SuggestedFlight.Make("../misc/images/as_suggested_flights_thumbnails/japan.jpg", "Tokyo", "0"),
                SuggestedFlight.Make("../misc/images/as_suggested_flights_thumbnails/singapore.jpg", "Singapore", "0"),
                SuggestedFlight.Make("../misc/images/as_suggested_flights_thumbnails/malaysia.jpg", "Malaysia", "0"),
                SuggestedFlight.Make("../misc/images/as_suggested_flights_thumbnails/thailand.jpg", "Bangkok", "0"),
                SuggestedFlight.Make("../misc/images/as_suggested_flights_thumbnails/philippines.jpg", "Bohol", "0"),
                SuggestedFlight.Make("../misc/images/as_suggested_flights_thumbnails/south_korea.jpg", "Seoul", "0"),
                SuggestedFlight.Make("../misc/images/as_suggested_flights_thumbnails/china.jpg", "The Forbidden City", "0"),
                SuggestedFlight.Make("../misc/images/as_suggested_flights_thumbnails/hongkong.jpg", "Hongkong", "0")
            };

            Background = "../misc/images/as_backgrounds/japan.jpg";   
        }

        public IActionResult OnGetResults(string trip_type, string cabin_class, 
            string from, string to, string departure, string @return)
        {
            this.numberOfPassenger = new NumberOfPassenger(this.Adult, this.Child, this.Infant);

            TempData["NumberOfPassenger"] = JsonSerializer.Serialize(this.numberOfPassenger);

            // But, for now, only "from" & "to" are used as search criteria. 
            return RedirectToPage("SecondProcess", 
                "Query",
                new {
                    trip_type = trip_type,
                    cabin_class = cabin_class,
                    from = from,
                    to = to,
                    departure = departure,
                    @return = @return
                });
        }

    }
}

