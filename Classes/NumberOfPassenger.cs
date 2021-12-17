using System;
using Microsoft.AspNetCore.Mvc;

namespace OTA.Classes
{
    public class NumberOfPassenger
    {
        public string Adult { get; set; }
        public string Child { get; set; }
        public string Infant { get; set; }

        public NumberOfPassenger(string adult, string child, string infant)
        {
            this.Adult = adult;
            this.Child = child;
            this.Infant = infant;
        }
        public int GetTotal()
        {
            int total = Int32.Parse(this.Adult) + Int32.Parse(this.Child) + Int32.Parse(this.Infant);
        
            return total;
        } 
    }
}