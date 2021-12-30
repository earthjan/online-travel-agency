using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using OTA.Pages;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OTA.Classes;
using OTA.Model;

namespace OTA.Pages
{
    public class SecondProcessPageModel : PageModel
    {
        private readonly OTADBContext _context;

        [BindProperty(SupportsGet = true)]
        public string Adult { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Child { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Infant { get; set; }

        public List<Model.FlightService> FlightServices;

        public List<string> Origins { get; private set; }

        public List<string> Destinations { get; private set; }

        public PassengersService passengersService = new PassengersService();

        public SecondProcessPageModel(OTADBContext context)
        {
            this._context = context;
        }

        public void OnGet()
        {
            this.Origins =  this._context.GetOrigins();

            this.Destinations = this._context.GetDestinations();
        }

        /// <summary>
        /// Gets either from the homepage or this PageModel's page the user query for a service.
        /// </summary>
        /// <param name="isQuery">Is a param key from this PageModel's page form that indicates that a user is trying to query again another service by having the param value 'true'. <br/>
        /// Helps to differentiate the query of this page against the one from the homepage.
        /// </param>
        /// <param name="trip_type">Is a param key of a form field for Fare type.</param>
        /// <param name="cabin_class">Is a param key of a form field for Cabin class.</param>
        /// <param name="origin">Is a param key of a form field for Origin.</param>
        /// <param name="destination">Is a param key of a form field for Destination.</param>
        /// <returns>The page of this page model.</returns>
        public IActionResult OnGetQuery(string isQuery, string trip_type, string cabin_class,
            string origin, string destination)
        {
            this.Origins =  this._context.GetOrigins();

            this.Destinations = this._context.GetDestinations();

            if (isQuery != null && isQuery.Equals("true"))
            {
                this.passengersService.NumberOfPassenger = 
                    new NumberOfPassenger(this.Adult, this.Child, this.Infant);

                TempData["NumberOfPassenger"] = JsonSerializer.Serialize(this.passengersService.NumberOfPassenger);

                this.FlightServices = this._context.GetFlightServices(this.passengersService.NumberOfPassenger.GetTotal(), origin, destination, trip_type, cabin_class);
            }
            else
            {
                var strNumberOfPassenger = TempData.Peek("NumberOfPassenger") as string;
                var NumberOfPassenger = JsonSerializer.Deserialize<NumberOfPassenger>(strNumberOfPassenger);

                this.FlightServices = this._context.GetFlightServices(NumberOfPassenger.GetTotal(), origin, destination, trip_type, cabin_class);
            }
                
            return Page();
        }

        public IActionResult OnPostBook(int FS_ID)
        {
            // Gets the query from either the landing page or the second page.
            // The NOP abbreviation in the identifiers means number of passenger.
            var strNumberOfPassenger = TempData.Peek("NumberOfPassenger") as string;
            var NumberOfPassenger = JsonSerializer.Deserialize<NumberOfPassenger>(strNumberOfPassenger);
            
            // Gets the chosen service in the DB using PK.
            var chosenService = OTADBContext.GetFlightService(FS_ID);

            var passengersService = new PassengersService();
            passengersService.NumberOfPassenger = NumberOfPassenger;
            passengersService.ChosenService = chosenService;

            TempData["PassengersService"] = JsonSerializer.Serialize(passengersService);

            return RedirectToPage("ThirdProcess", "Form");    
        }
    }

}