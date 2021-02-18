using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using OTA.Classes;
using Microsoft.AspNetCore.Mvc;

namespace OTA.Pages
{
    public class FourthProcessPageModel : PageModel
    {
        public string ExpirationDate = GetNextWeekDate();
        public int GeneratedCode = generateCode();

        /// <summary>
        /// Generates 6-digit code.
        /// It Is mainly used for one-time code generation.
        /// </summary>
        /// <returns>6-digit code</returns>
        static int generateCode() => new Random().Next(111111, 999999);

        public void OnGet()
        {}

        /// <summary>
        /// Determines the next week date-time that is relative with when the code is executed.
        /// </summary>
        /// <returns>Next week date with the following format: DD/MM/YYYY HH:MM AM/PM. </returns>
        static string GetNextWeekDate()
        {
            DateTime result = DateTime.Now.AddDays(1);
            DayOfWeek dayNow = DateTime.Now.DayOfWeek;

            while( result.DayOfWeek != dayNow )
                result = result.AddDays(1);    

            // DD/MM/YYYY HH:MM AM/PM
            string formattedDate = $"{result.Day}/{result.Month}/{result.Year} {DateTime.Now.Hour.ToString()}:{DateTime.Now.Minute.ToString()} {DateTime.Now.ToString("tt")}";

            return formattedDate;   
        }
    }
}