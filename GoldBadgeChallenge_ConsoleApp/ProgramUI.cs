using _01_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_ConsoleApp
{
    public class ProgramUI
    {
        private MenuItemRepository _repo = new MenuItemRepository();

        public void Run()
        {
            SeedMenuItems();
            while (Menu())
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //HOW TO MAKE THIS BOOL A MENU WITH SWITCH CASE AND NOT IF STATEMENT
        private bool Menu()
        {
            Console.WriteLine("Please enter the number of the action you would like to do:\n" +
                "1. Add a New Menu Item\n" +
                "2. Get a List of Menu Items\n" +
                "3. Get a Menu Item By Name\n" +
                "4. Update Exisiting Menu Item By Name\n" +
                "5. Remove a Menu Item\n" +
                "6. Exit");

            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "1":
                    AddNewItem();
                    break;
                case "2":
                    GetAllMenuItems();
                    break;
                case "3":
                    GetItemByName();
                    break;
                case "4":
                    UpdateItemByName();
                    break;
                case "5":
                    RemoveItem();
                    break;
                case "6":
                    return false;
                default:
                    Console.WriteLine("Please enter a vaild number");
                    return true;
            }
            return true;
        }

        private void AddNewItem()
        {
            Console.Clear();
            MenuItem newItem = GetValuesForMenuItemObjects();

            _repo.AddMenuItemToDirectory(newItem);
        }

        private void GetAllMenuItems()
        {
            Console.Clear();

            foreach (var item in _repo.GetMenuItems())
            {
                DisplayAllMenuItemProp(item);
            }
        }
        private void GetItemByName()
        {
            Console.Clear();
            DisplayOnlyMealItemByNumAndName();
            Console.WriteLine("\nPlease enter the NAME of the menu item you would like to display:\n");

            MenuItem menuItem = _repo.GetMenuItemByName(Console.ReadLine());

            if (menuItem != null)
            {
                DisplayAllMenuItemProp(menuItem);
            }
            else
            {
                Console.WriteLine("\nThere is no menu item with that NAME.");
            }
        }
        

        //IF TIME PLEASE ADD THIS AS AN OPTION
        //private void GetItemByNumber()
        //{
        //    Console.Clear();
        //    DisplayOnlyMealItemByNumAndName();
        //    Console.WriteLine("Please enter the number you would like to see:");
        //    int menuItemNum = Convert.ToInt32(Console.ReadLine());

        //    foreach (MenuItem item in _repo.GetMenuItems())
        //    {
        //        if (menuItemNum == item.MealNumber)
        //        {
        //            DisplayAllMenuItemProp(item);
        //        }
        //        else
        //        {
        //            Console.WriteLine("There is no menu item by that number.");
        //        }
        //    }
        //}

        private void UpdateItemByName()
        {
            Console.Clear();
            DisplayOnlyMealItemByNumAndName();

            Console.WriteLine("Please enter the NAME of the menu item you would like to update:");

            string oldItem = Console.ReadLine();
            MenuItem newItem = GetValuesForMenuItemObjects();

            bool wasAdded = _repo.UpdateExisitingMenuItemByName(oldItem, newItem);
            
            if (wasAdded)
            {
                Console.WriteLine("The menu item was updated successfully!");
            }
            else
            {
                Console.WriteLine("There is no menu item by that name.");
            }
        }

        private void RemoveItem()
        {
            Console.Clear();
            DisplayOnlyMealItemByNumAndName();
            Console.WriteLine("Enter the name of the menu item you would like to delete:\n");

            if (_repo.RemoveMenuItemFromList(Console.ReadLine()))
            {
                Console.WriteLine("The menu item was successfully deleted!");
            }
            else
            {
                Console.WriteLine("The menu item was not successfully deleted.");
            }
        }

        private MenuItem GetValuesForMenuItemObjects()
        {
            Console.Clear();

            Console.WriteLine("Enter the menu item number:");
            int mealNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter the name of the menu item:");
            string name = Console.ReadLine();

            Console.WriteLine("\nEnter the description of the menu item:");
            string description = Console.ReadLine();

            Console.WriteLine("\nEnter the ingredients. Please seperate each ingredient with 1 (one) comma, FOLLOWED by a 1 (one) space.");
            string ingredientsAsString = Console.ReadLine();
            char[] separators = new char[] { ' ', ',' };
            string[] ingredientsAsArray = ingredientsAsString.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            List<string> ingredientsAsList = new List<string>(ingredientsAsArray);

            Console.WriteLine("\nEnter the price of the menu item:");
            double price = Convert.ToDouble(Console.ReadLine());

            MenuItem item = new MenuItem(mealNum, name, description, ingredientsAsList, price);
            return item;
        }

        private void DisplayAllMenuItemProp(MenuItem item)
        {
            Console.WriteLine($"\n\t#{item.MealNumber}\n" +
                $"\tName: {item.MealName}\n" +
                $"\tDescription: {item.Description}\n" +
                $"\tIngredients: {item.Ingredients}\n" +
                $"\tPrice: ${item.Price}\n");
        }

        private void DisplayOnlyMealItemByNumAndName()
        {
            foreach (var item in _repo.GetMenuItems())
            {
                Console.WriteLine($"\t#{item.MealNumber}\n" +
                $"\tName: {item.MealName}");
            }
        }

        private void GetMenuItemByNameOrNum()
        {
            DisplayOnlyMealItemByNumAndName();
            Console.WriteLine("Please enter the number OR the name of the item you would like to display:");

            string input = Console.ReadLine().ToLower();
            bool successful = Int32.TryParse(input, out int result);

            foreach (var item in _repo.GetMenuItems())
            {
                if (item.MealName == input)
                {
                    DisplayAllMenuItemProp(item);
                }
                else if (successful == true)
                {
                    if (item.MealNumber == result)
                    {
                        DisplayAllMenuItemProp(item);
                    }
                }
                else
                {
                    Console.WriteLine("There is no menu item by that NAME or NUMBER.");
                }
            }
        }

        private void SeedMenuItems()
        {
            _repo.AddMenuItemToDirectory(new MenuItem(1, "Bob's Best Burger", "Mouth watering sammie", new List<string> { "bread", "meat", "cheese" }, 11.50));
            _repo.AddMenuItemToDirectory(new MenuItem(2, "Smashed", "better than McD's", new List<string> { "buns", "6oz Meat", "cheese" }, 12.50));
            _repo.AddMenuItemToDirectory(new MenuItem(4, "Vegan mush", "Mouth watering vegan sammie", new List<string> { "vegan bread", "tofu", "mushrooms" }, 10.50));
        }
    }
}
