using System;

namespace online_travel_agency.Classes
{
    public class Utility
    {
        public static string DMY(DateTime dateTime)
        {
            string formattedDate = $"{dateTime.Day}/{dateTime.Month}/{dateTime.Year}";
            
            return formattedDate;
        }
    }
}