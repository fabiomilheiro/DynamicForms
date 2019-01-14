using System;
using System.Collections.Generic;

namespace DynamicForms.Common.Models.ApplicationModels
{
    public class Applicant
    {
        public Applicant()
        {
            TradingExperiences = new List<TradingExperience>();
            Declarations = new List<Declaration>();
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public string CitizenshipID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public string TitleID { get; set; }
        public List<TradingExperience> TradingExperiences { get; set; }
        public List<Declaration> Declarations { get; set; }
    }
}