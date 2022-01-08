using System;
using System.Text;

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

        /// <summary>
        /// Removes special charaters.
        /// </summary>
        /// <param name="str">is the string to be cleaned,</param>
        /// <returns>A cleaned string</returns>
        public static string Remove(string str)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}