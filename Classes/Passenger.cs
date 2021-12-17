using System;

namespace OTA.Classes

{
    public class Passenger
    {
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

        public Passenger(string givenName, string middleName, string surname,
            string nationality, string gender, string birthDate, 
            string passportOrIDNo, string passportOrIDExpiryDate, string email,
            string mobileNo, int cabinBagCount, int checkedBagCount)
        {
            this.GivenName = givenName;
            this.MiddleName = middleName;
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

        public Passenger(string givenName, string surname,
            string nationality, string gender, string birthDate, 
            string passportOrIDNo, string passportOrIDExpiryDate, string email,
            string mobileNo, int cabinBagCount, int checkedBagCount)
        {
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
    }
}