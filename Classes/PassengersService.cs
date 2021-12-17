using System;
using OTA.Model;

namespace OTA.Classes
{
    public class PassengersService
    {
        public Model.FlightService ChosenService { get; set; }
        public NumberOfPassenger NumberOfPassenger { get; set; }
    }
}