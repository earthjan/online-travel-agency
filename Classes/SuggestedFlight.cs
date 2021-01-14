using System;
using System.Collections.Generic;

namespace OTA.Classes
{
    public struct SuggestedFlight
    {
        public string ImagePath { get; init; }
        public string Title { get; init; }
        public string Cost { get; init; }

        private SuggestedFlight(string imagePath, string title, string cost)
        {
            ImagePath = imagePath;
            Title = title;
            Cost = cost;
        }

        /// <summary>
        /// To make suggested flight data
        /// </summary>
        /// <param name="imagePath"> Path </param>
        /// <param name="title"> Title </param>
        /// <param name="cost"> Cost with currency symbol</param>
        /// <returns>Instance of SuggestedFlight</returns>
        public static SuggestedFlight Make(string imagePath, string title, string cost)
        {
            return new SuggestedFlight(imagePath, title, cost);
        }
    }
}