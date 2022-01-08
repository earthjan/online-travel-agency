using System;

namespace OTA.Classes
{
    public class Utility
    {
        public static string DMY(DateTime dateTime)
        {
            string formattedDate = $"{dateTime.Day}/{dateTime.Month}/{dateTime.Year}";
            
            return formattedDate;
        }

        /// <summary>
        /// Generates 7-digit code.
        /// It Is mainly used as ID in the Passenger class to provide equality logic for IEquality<T>.
        /// </summary>
        /// <returns>7-digit code</returns>
        public static int Generate7DigitCode() => new Random().Next(1111111, 9999999);
    }
}