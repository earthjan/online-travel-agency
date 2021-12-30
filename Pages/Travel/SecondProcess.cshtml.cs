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

        public PassengersService passengersService = new PassengersService();

        public SecondProcessPageModel(OTADBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets either from the homepage or this PageModel's page the user query for a service.
        /// </summary>
        /// <param name="isQuery">Is a param key from this PageModel's page form that indicates that a user is trying to query again another service by having the param value 'true'. <br/>
        /// Helps to differentiate the query of this page against the one from the homepage.
        /// </param>
        /// <param name="trip_type">Is a param key of a form field for Fare type.</param>
        /// <param name="cabin_class">Is a param key of a form field for Cabin class.</param>
        /// <param name="from">Is a param key of a form field for Origin.</param>
        /// <param name="to">Is a param key of a form field for Destination.</param>
        /// <param name="departure">Is a param key of a form field for departure schedule.</param>
        /// <param name="return">Is a param key of a form field for return schedule.</param>
        /// <returns>The page of this page model.</returns>
        public IActionResult OnGetQuery(string isQuery, string trip_type, string cabin_class,
            string from, string to, string departure, string @return)
        {
            if (isQuery != null && isQuery.Equals("true"))
            {
                this.passengersService.NumberOfPassenger = 
                    new NumberOfPassenger(this.Adult, this.Child, this.Infant);

                TempData["NumberOfPassenger"] = JsonSerializer.Serialize(this.passengersService.NumberOfPassenger);
            }
            else
            {
                var strNumberOfPassenger = TempData["NumberOfPassenger"] as string;
                var NumberOfPassenger = JsonSerializer.Deserialize<NumberOfPassenger>(strNumberOfPassenger);

                this.FlightServices = this._context.GetFlightServices(NumberOfPassenger.GetTotal(), from, to, trip_type, cabin_class);
            }
                
            return Page();
        }

        public IActionResult OnPostBook(int FS_ID)
        {
            // Gets the query from either the landing page or the second page.
            // The NOP abbreviation in the identifiers means number of passenger.
            var strNOP = TempData["NumberOfPassenger"] as string;
            var NOP = JsonSerializer.Deserialize<NumberOfPassenger>(strNOP);
            
            // Gets the chosen service in the DB using PK.
            var chosenService = OTADBContext.GetFlightService(FS_ID);

            var passengersService = new PassengersService();
            passengersService.NumberOfPassenger = NOP;
            passengersService.ChosenService = chosenService;

            TempData["PassengersService"] = JsonSerializer.Serialize(passengersService);

            return RedirectToPage("ThirdProcess", "Form");    
        }
    }

}