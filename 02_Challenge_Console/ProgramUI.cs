using _02_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Console
{
    public class ProgramUI
    {

        private ClaimRepository _repo = new ClaimRepository();
        public void Run()
        {
            //SeedMenuItems();
            while (Menu())
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private bool Menu()
        {
            Console.WriteLine("Please enter the NUMBER of the action you would like to do:\n\n" +
                "1. Display All Claims\n" +
                "2. Accept Next Claim\n" +
                "3. Add New Claim\n" +
                "4. Search Claim By Claim Number\n" +
                "5. Update Exisiting Claim By Claim Number\n" +
                "6. DeleteClaim\n" +
                "7. Exit");

            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "1":
                    DisplayAllClaims();
                    break;
                case "2":
                    AcceptNextClaim();
                    break;
                case "3":
                    AddNewClaim();
                    break;
                case "4":
                    //SearchClaimByClaimNumber();
                    break;
                case "5":
                    //UpdateExisitingClaimByClaimNumber();
                    break;
                case "6":
                    //DeleteClaim();
                    break;
                case "7":
                    return false;
                default:
                    Console.WriteLine("\nPlease enter a vaild number");
                    return true;
            }
            return true;
        }
        // menu methods:
        private void DisplayAllClaims()
        {
            Console.Clear();

            foreach (var item in _repo.GetAllClaimsFromQueue())
            {
                DisplayAllClaimProp(item);
            }
        }

        private void AcceptNextClaim()
        {
            Console.Clear();

            _repo.PeekClaimFromQueue();
            Console.WriteLine("Would you like to deal with this claim now?\n" +
                "\tPlease enter [Y]es or[N]o.");
            if(_repo.DequeueFirstClaim(Console.ReadLine().ToLower()))
            {
                Console.WriteLine("\nYou accepted the claim.");
            }
            else
            {
                Console.WriteLine("\nYou were not able to take on this claim. Please contact your IT specalist.");
            }
        }

        private void AddNewClaim()
        {
            Console.Clear();

            Claim newClaim = GetValuesForClaimObjects();

            _repo.AddClaimToDirectory(newClaim);
        }

        //private void SearchClaimByClaimNumber()
        //{

        //}

        //private void UpdateExisitingClaimByClaimNumber()
        //{

        //}

        //private void DeleteClaim()
        //{

        //}


        //helper methods:

        private Claim GetValuesForClaimObjects()
        {
            Console.Clear();

            Console.WriteLine("\nEnter the Claim Number:");
            int claimID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter the Number corrosponding to the Claim Type:\n" +
                "\t1. Car\n" +
                "\t2. Home\n" +
                "\t3. Theft\n");
            ClaimType typeOfClaim = (ClaimType)Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter the claim description:");
            string description = Console.ReadLine();

            Console.WriteLine("\nAmount of Damage:");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("\nEnter the date of Incident (MM/DD/YYYY):");
            DateTime dateIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter the date of Claim (MM/DD/YYYY):");
            DateTime dateClaim= DateTime.Parse(Console.ReadLine());

            

            Claim claim = new Claim (claimID, typeOfClaim, description, amount, dateIncident, dateClaim);
            return claim;
        }

        private void DisplayAllClaimProp(Claim c)
        {
            Console.WriteLine($"\n\tClaim ID: {c.ClaimID}\n" +
                $"\tType: {c.TypeOfClaim}\n" +
                $"\tDescription: {c.Description}\n" +
                $"\tAmount: {c.ClaimAmount}\n" +
                $"\tDate of Incident: {c.DateOfIncident}\n" +
                $"\tDate of Claim: {c.DateOfClaim}\n" +
                $"\t{c.IsValid}\n");
        }


    }
}
