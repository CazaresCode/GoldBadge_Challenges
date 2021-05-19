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
            SeedClaims();
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
                "\t1. Display All Claims\n" +
                "\t2. Accept Next Claim\n" +
                "\t3. Add New Claim\n" +
                "\t4. Search Claim By Claim Number\n" +
                "\t5. Update Exisiting Claim By Claim Number\n" +
                "\t6. Delete Claim\n" +
                "\t7. Exit");

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
                    SearchClaimByClaimNumber();
                    break;
                case "5":
                    UpdateExisitingClaimByClaimNumber();
                    break;
                case "6":
                    DeleteClaim();
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

            var firstQueueClaim = _repo.PeekClaimFromQueue();
            DisplayAllClaimProp(firstQueueClaim);
            Console.WriteLine("Would you like to deal with this claim now?\n" +
                "\tPlease enter [Y]es or[N]o.");

            if(_repo.DequeueFirstClaim(Console.ReadLine().ToLower()))
            {
                Console.WriteLine("\nYou accepted the claim.");
            }
            else
            {
                Console.WriteLine("\nYou did not take on this claim.");
            }
        }

        private void AddNewClaim()
        {
            Console.Clear();

            Claim newClaim = GetValuesForClaimObjects();

            if(_repo.AddClaimToDirectory(newClaim))
            {
                Console.WriteLine("You successfully ADDED a claim!");
            }
            else
            {
                Console.WriteLine("Unable to process claim");
            }
        }

        private void SearchClaimByClaimNumber()
        {
            Console.Clear();
            DisplayAllClaims();
            Console.WriteLine("\nPlease enter the Claim NUMBER you would like to DISPLAY:\n");

            Claim claim = _repo.GetClaimsFromQueueById(Convert.ToInt32(Console.ReadLine()));

            if (_repo.GetClaimsFromQueueById(claim.ClaimID) != null)
            {
                Console.Clear();
                DisplayAllClaimProp(claim);
            }
            else
            {
                Console.WriteLine("There is no claim  with that NUMBER.");
            }
        }

        private void UpdateExisitingClaimByClaimNumber()
        {
            Console.Clear();
            DisplayAllClaims();
            Console.WriteLine("\nPlease enter the Claim NUMBER you would like to UPDATE:");

           Claim oldClaim=  _repo.GetClaimsFromQueueById(Convert.ToInt32(Console.ReadLine()));
            
            if(_repo.UpdateExisitingClaimByID(oldClaim.ClaimID, GetValuesForClaimObjects()))
            {
                Console.WriteLine("You successfully UPDATED the claim!");
            }
            else
            {
                Console.WriteLine("You are not able to updated this claim. Please contact the nearest human possible.");
            }
        }

        private void DeleteClaim()
        {
            Console.Clear();
            DisplayAllClaims();
            Console.WriteLine("\nPlease enter the Claim NUMBER you would like to DELETE:");
            int claimToDelete = Convert.ToInt32(Console.ReadLine());
           if(_repo.DeleteClaimFromList(claimToDelete))
            {
                Console.WriteLine("You successfully DELETED the claim!");
            }
            else
            {
                Console.WriteLine("You are not able to delete this claim. Please contact the nearest human possible.");
            }
        }


        //helper methods:
        private Claim GetValuesForClaimObjects()
        {
            Console.Clear();

            Console.WriteLine("\nEnter the Claim Number:");
            int claimId = Convert.ToInt32(Console.ReadLine());

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

            Claim claim = new Claim (claimId, typeOfClaim, description, amount, dateIncident, dateClaim);
            return claim;
        }

        private void DisplayAllClaimProp(Claim c)
        {
            Console.WriteLine($"\n\tClaim ID: {c.ClaimID}\n" +
                $"\tType: {c.TypeOfClaim}\n" +
                $"\tDescription: {c.Description}\n" +
                $"\tAmount: ${c.ClaimAmount}\n" +
                $"\tDate of Incident: {c.DateOfIncident.ToShortDateString()}\n" +
                $"\tDate of Claim: {c.DateOfClaim.ToShortDateString()}\n" +
                $"\t{c.Valid()}\n");
        }

        private void SeedClaims()
        {
            _repo.AddClaimToDirectory(new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27)));
            _repo.AddClaimToDirectory(new Claim(2, ClaimType.Home, "house fire.", 400000.00m, new DateTime(2018, 03, 25), new DateTime(2018, 04, 30)));
            _repo.AddClaimToDirectory(new Claim(3, ClaimType.Theft, "pokemon cards stolen.", 300.00m, new DateTime(2018, 02, 25), new DateTime(2018, 03, 27)));
        }
    }
}
