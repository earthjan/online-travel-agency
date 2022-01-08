using System;

namespace OTA.Classes

{
    public class Passenger : IEquatable<Passenger>
    {
        public int ID { get; set; }
    
        public string GivenName { get; set; }

        public string MiddleName { get; set; } = "NA";

        public string Surname { get; set; }

        public string Nationality { get; set; }

        public string Gender { get; set; }

#warning if you have time, make this DateTime
        public string BirthDate { get; set; }
        public string PassportOrIDNo { get; set; }

#warning if you have time, make this DateTime
        public string PassportOrIDExpiryDate { get; set; }

        public string Email { get; set; }

        public string MobileNo { get; set; }

        public int CabinBagCount { get; set; }

        public int CheckedBagCount { get; set; }

        public Passenger() {}

        public Passenger(string givenName, string surname,
            string nationality, string gender, string birthDate,
            string passportOrIDNo, string passportOrIDExpiryDate, string email,
            string mobileNo, int cabinBagCount, int checkedBagCount)
        {
            this.ID = Utility.Generate7DigitCode();
            this.GivenName = givenName;
            this.Surname = surname;
            this.Nationality = nationality;
            this.Gender = gender;
            this.BirthDate = birthDate;
            this.PassportOrIDNo = passportOrIDNo;
            this.PassportOrIDExpiryDate = passportOrIDExpiryDate;
            this.Email = email;
            this.MobileNo = mobileNo;
            this.CabinBagCount = cabinBagCount;
            this.CheckedBagCount = checkedBagCount;
        }

        public bool Equals(Passenger other)
        {
            if (other == null)
                return false;

            if (this.ID == other.ID)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Passenger passengerObj = obj as Passenger;

            if (passengerObj == null)
                return false;
            else
                return Equals(passengerObj);
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public static bool operator ==(Passenger passenger1, Passenger passenger2)
        {
            if (((object)passenger1) == null || ((object)passenger2) == null)
                return Object.Equals(passenger1, passenger2);

            return passenger1.Equals(passenger2);
        }

        public static bool operator !=(Passenger passenger1, Passenger passenger2)
        {
            if (((object)passenger1) == null || ((object)passenger2) == null)
                return !Object.Equals(passenger1, passenger2);

            return !(passenger1.Equals(passenger2));
        }

        // public static Passenger CreateInstance(string givenName, string surname,
        //     string nationality, string gender, string birthDate,
        //     string passportOrIDNo, string passportOrIDExpiryDate, string email,
        //     string mobileNo, int cabinBagCount, int checkedBagCount)
        // {
        //     var passenger = new Passenger(Utility.Generate7DigitCode(), givenName, surname,
        //     nationality, gender, birthDate,
        //     passportOrIDNo, passportOrIDExpiryDate, email,
        //     mobileNo, cabinBagCount, checkedBagCount);

        //     return passenger;
        // }
    }
}