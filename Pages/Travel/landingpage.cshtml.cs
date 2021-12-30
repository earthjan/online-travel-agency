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
        private readonly OTADBContext _context;
        
        [BindProperty(SupportsGet = true)]
        public string Adult { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Child { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Infant { get; set; }

        private NumberOfPassenger numberOfPassenger;

        [BindProperty(SupportsGet = true)]
        public string Origin { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Destination { get; set; }

        public string Background { get; private set; }

        // This property is accessed by "landingpage" page to get "Suggested flights" data.
        public IEnumerable<SuggestedFlight> SuggestedFlights { get; private set; }

        public List<string> Origins { get; private set; }

        public List<string> Destinations { get; private set; }
        
        public LandingPagePageModel(OTADBContext context)
        {
            this._context = context;
        }

        public void OnGet()
        {

            ViewData["Title"] = "Travel OTA Name";

            this.Origins =  this._context.GetOrigins();

            this.Destinations = this._context.GetDestinations();

            Background = "../misc/images/as_backgrounds/japan.jpg";
        }

        public IActionResult OnGetResults(string trip_type, string cabin_class, string departure)
        {
            this.numberOfPassenger = new NumberOfPassenger(this.Adult, this.Child, this.Infant);

            TempData["NumberOfPassenger"] = JsonSerializer.Serialize(this.numberOfPassenger);
 
            return RedirectToPage("SecondProcess",
                "Query",
                new
                {
                    trip_type = trip_type,
                    cabin_class = cabin_class,
                    origin = this.Origin,
                    destination = this.Destination,
                    departure = departure
                });
        }
    }
}

