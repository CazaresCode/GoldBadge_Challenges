using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Repository
{
    public enum ClaimType { Car, Home, Theft }

    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        // Figure out how to set IsValid based on if it is valid within 30 days. Would that be a method in the class?
        public bool IsValid 
        { 
            get
            {
                TimeSpan differenceOfDates = DateOfClaim - DateOfIncident;
                double differenceOfDatesInDays = differenceOfDates.TotalDays;

                if (differenceOfDatesInDays <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
