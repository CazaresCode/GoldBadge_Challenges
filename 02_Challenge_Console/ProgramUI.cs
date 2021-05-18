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
                    //DisplayAllClaims();
                    break;
                case "2":
                    //AcceptNextClaim();
                    break;
                case "3":
                    //AddNewClaim();
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

    }
}
