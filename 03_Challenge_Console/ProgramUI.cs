using _03_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge_Console
{
    public class ProgramUI
    {
        private BadgesRepository _repo = new BadgesRepository();
        public void Run()
        {
            //SeedClaims();
            while (Menu())
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private bool Menu()
        {
            Console.WriteLine("Enter the NUMBER you would like to do:\n\n" +
                "\t1. Add a Badge \n" +
                "\t2. Edit a Badge\n" +
                "\t3. List All Badges\n" +
                "\t4. Exit");

            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "1":
                    //AddBadge();
                    break;
                case "2":
                    //EditBadge();
                    break;
                case "3":
                    //ListAllBadges();
                    break;
                case "4":
                    return false;
                default:
                    Console.WriteLine("\nPlease enter a vaild number");
                    return true;
            }
            return true;
        }
    }
}
