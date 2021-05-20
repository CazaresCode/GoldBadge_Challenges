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
            SeedBadges();
            while (Menu())
            {
                Console.WriteLine("\n\nPress any key to continue...");
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

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    AddBadge();
                    break;
                case 2:
                    EditBadge();
                    break;
                case 3:
                    ListAllBadges();
                    break;
                case 4:
                    return false;
                default:
                    Console.WriteLine("\nPlease enter a vaild number");
                    return true;
            }
            return true;
        }

        private void AddBadge()
        {
            Console.Clear();
            Console.WriteLine("ADD BADGE\n\n");

            Console.WriteLine("What is the number of the badge:");
            int badgeID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nList the FIRST door that it needs access to (ex. A1) and then press any key to continue:");
            string response = Console.ReadLine().ToUpper();
            List<string> listResponse = new List<string> { response };

            bool keepAsking = true;
            while (keepAsking)
            {
                Console.WriteLine("\nAny other doors? Enter Yes or No:");
                string userResponse = Console.ReadLine().ToLower();
                if (userResponse == "yes")
                {
                    Console.WriteLine("\nList another door that it needs access to (ex. A1):");
                    string addDoor = Console.ReadLine().ToUpper();
                    listResponse.Add(addDoor);
                }
                else if (userResponse == "no")
                {
                    keepAsking = false;
                }
                else
                {
                    Console.WriteLine("\nPlease enter a valide response.");
                }
            }

            Badge newBadge = new Badge(badgeID, listResponse);
            if (_repo.AddBadgeToDictionary(newBadge))
            {
                Console.WriteLine("\nYou successfully added a new Badge.");
            }
            else
            {
                Console.WriteLine("\nYou were NOT able to add this Badge.");
            }
        }

        private void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~EDIT BADGE~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");

            while (RemoveOrAddDoorMenu())
            {
                Console.WriteLine("\n\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~EDIT BADGE~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
            }
        }

        private bool RemoveOrAddDoorMenu()
        {
            Console.WriteLine("\nEnter the NUMBER you would like to do:\n" +
                "\t1. Add a Door.\n" +
                "\t2. Remove a Door.\n" +
                "\t3. See List of Badges.\n" +
                "\t4. Back to Menu.\n");

            int input = Convert.ToInt32(Console.ReadLine());

            if (input == 1)
            {
                EditAddDoor();
                return true;
            }
            else if (input == 2)
            {
                EditRemoveDoor();
                return true;
            }
            else if (input == 3)
            {
                ListAllBadges();
                return true;
            }
            else if (input == 4)
            {
                return false;
            }
            else
            {
                Console.WriteLine("\nPlease enter a vaild number");
                return true;
            }
        }

        private void EditAddDoor()
        {
            Console.WriteLine("\nEnter the BADGE ID:");

            int badgeID = Convert.ToInt32(Console.ReadLine());

            if (_repo.GetListBadge().ContainsKey(badgeID))
            {
                foreach (var badge in _repo.GetListBadge())
                {
                    if (badge.Key == badgeID)
                    {
                        int firstCount = badge.Value.Count;

                        Console.WriteLine($"\n{badge.Key} has access to doors: {badge.Value}.");

                        Console.WriteLine("\nEnter the door you would like to ADD (ex. A1):");
                        string additionDoor = Console.ReadLine().ToUpper();
                        badge.Value.Add(additionDoor);

                        int secondCount = badge.Value.Count;
                        
                        if (secondCount > firstCount)
                        {
                            Console.WriteLine($"\nDoor was ADDED." +
                                $"\n{badge.Key} has access to doors: {badge.Value}.");
                        }
                        else
                        {
                            Console.WriteLine("\nCould NOT add the door.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nThere is NOT a BADGE ID in the database.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nThere is NOT a BADGE ID in the database.");
            }
        }

        private void EditRemoveDoor()
        {
            Console.WriteLine("\nEnter the BADGE ID:");

            int badgeID = Convert.ToInt32(Console.ReadLine());

            if (_repo.GetListBadge().ContainsKey(badgeID))
            {
                foreach (var badge in _repo.GetListBadge())
                {
                    if (badge.Key == badgeID)
                    {
                        int firstCount = badge.Value.Count;
                       
                        Console.WriteLine($"\n{badge.Key} has access to doors: {badge.Value}.");
                        
                        Console.WriteLine("\nEnter the door you would like to REMOVE (ex. A1):");
                        string additionDoor = Console.ReadLine().ToUpper();
                        badge.Value.Remove(additionDoor);

                        int secondCount = badge.Value.Count;

                        if (secondCount < firstCount)
                        {
                            Console.WriteLine($"\nDoor was REMOVED." +
                                $"\n{badge.Key} has access to doors: {badge.Value}.");
                        }
                        else
                        {
                            Console.WriteLine("\nCould NOT remove the door.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nThere is NOT a BADGE ID in the database.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nThere is NOT a BADGE ID in the database.");
            }
        }

        private void ListAllBadges()
        {
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~LIST OF BADGES~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");


            var dict = _repo.GetListBadge();
            if (dict.Count > 0)
            {
                foreach (var badge in dict.OrderBy(key => key.Key))
                {
                    var list = badge.Value;

                    var valueAsString = string.Join(", ", list);

                    Console.WriteLine($"\n\tBadge ID {badge.Key} has access to doors: {valueAsString}.");
                }
            }
        }

        private void SeedBadges()
        {
            _repo.AddBadgeToDictionary(new Badge(1, new List<string> { "A1", "B1", "A5" }));
            _repo.AddBadgeToDictionary(new Badge(31, new List<string> { "A1", "B2", "A3" }));
            _repo.AddBadgeToDictionary(new Badge(3, new List<string> { "A1", "B1", "A7" }));
        }

        //NOT NEEDED AT THIS MOMENT
        private void DisplayBadgeIDAndDoorAccess()
        {
            Console.WriteLine("\nEnter the BADGE ID:");

            int badgeID = Convert.ToInt32(Console.ReadLine());

            foreach (var badge in _repo.GetListBadge())
            {
                if (badge.Key == badgeID)
                {
                    var list = badge.Value;

                    var valueAsString = string.Join(", ", list);

                    Console.WriteLine($"\nBadge ID {badge.Key} has access to doors: {valueAsString}.");
                }
                else
                {
                    Console.WriteLine("\nThere is NOT a BADGE ID in the database.");
                }
            }
        }

    }
}
