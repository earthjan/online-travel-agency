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
        [BindProperty(SupportsGet = true)]
        public string Adult { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Child { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Infant { get; set; }
        public List<Model.FlightService> FlightServices;
        public PassengersService passengersService = new PassengersService();

        public IActionResult OnGetQuery(string isQuery, string trip_type, string cabin_class,
            string from, string to, string departure, string @return)
        {
            // This is just a simulation on how search flight services from the model and how to display them.
            this.FlightServices = OTADBContext.GetFlightServices();

            // Checks if the customer queries again a service by using the one in the second page.
            // If the customer does, the TempData that holds the query from the landing page is changed
            // so it will hold the new query done in the second page.
            if (isQuery != null && isQuery.Equals("true"))
            {
                this.passengersService.NumberOfPassenger = 
                    new NumberOfPassenger(this.Adult, this.Child, this.Infant);

                TempData["NumberOfPassenger"] = JsonSerializer.Serialize(this.passengersService.NumberOfPassenger);
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