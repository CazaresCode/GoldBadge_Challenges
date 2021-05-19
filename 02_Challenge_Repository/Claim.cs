using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Repository
{
    public enum ClaimType { Car = 1, Home, Theft }

    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; private set; }

        public string Valid()
        {
            TimeSpan differenceOfDates = DateOfClaim - DateOfIncident;
            double differenceOfDatesInDays = differenceOfDates.TotalDays;

            if (differenceOfDatesInDays <= 30)
            {
                IsValid = true;
                return "This claim is valid.";
            }
            else
            {
                IsValid = false;
                return "This claim is NOT valid.";
            }

        }

        public Claim(int claimId, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimId;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
