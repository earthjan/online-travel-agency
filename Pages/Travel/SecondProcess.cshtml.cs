using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace OTA.Pages
{
    public class SecondProcessPageModel : PageModel
    {
        /// <summary>
        /// Is a collection of flight results based on a flight query.
        /// </summary>
        public object[] flightResults;

        public void OnGet()
        {
        }
    }
    
}