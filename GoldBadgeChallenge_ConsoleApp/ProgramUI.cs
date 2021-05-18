﻿using _01_Challenge_Repository;
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
                Console.WriteLine("\nPress any key to continue...");
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
                "4. Get a Menu Item By Number\n" +
                "5. Update Exisiting Menu Item By Name\n" +
                "6. Remove a Menu Item\n" +
                "7. Exit");

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
                    DisplayMenuItemByNumber();
                    break;
                case "5":
                    UpdateItemByNum();
                    break;
                case "6":
                    RemoveItem();
                    break;
                case "7":
                    return false;
                default:
                    Console.WriteLine("\nPlease enter a vaild number");
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
            ShowOnlyMealItemByNumAndName();
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

        private void DisplayMenuItemByNumber()
        {
            Console.ReadLine();
            ShowOnlyMealItemByNumAndName();

            Console.WriteLine("\nEnter the NUMBER of the menu item you would like to see:");

            bool itemWasFound = Int32.TryParse(Console.ReadLine(), out int result);

            if (itemWasFound)
            {
                MenuItem itemToUpdate = _repo.GetMenuItemByNumber(result);

                if (itemToUpdate != null)
                {
                    DisplayAllMenuItemProp(itemToUpdate);
                }
                else
                {
                    Console.WriteLine("\nThere is no menu item with that number.");
                }
            }
        }

        private void UpdateItemByNum()
        {
            Console.Clear();
            ShowOnlyMealItemByNumAndName();

            Console.WriteLine("\nPlease enter the NUMBER of the menu item you would like to update:");

            bool newItemFound = Int32.TryParse(Console.ReadLine(), out int result);

            if (newItemFound)
            {
                MenuItem newItem = _repo.GetMenuItemByNumber(result);

                if (newItem != null)
                {
                    MenuItem menuItem = GetValuesForMenuItemObjects();
                    _repo.UpdateExisitingMenuItemByNumber(result, menuItem);
                    Console.WriteLine("\nThe menu item was updated successfully!");
                }
                else
                {
                    Console.WriteLine("\nThere is no menu item by that name.");

                }
            }
        }

        private void RemoveItem()
        {
            Console.Clear();
            ShowOnlyMealItemByNumAndName();
            Console.WriteLine("\nEnter the NUMBER of the menu item you would like to delete:\n");

            if (_repo.RemoveMenuItemFromListByNumber(int.Parse(Console.ReadLine())))
            {
                Console.WriteLine("\nThe menu item was successfully deleted!");
            }
            else
            {
                Console.WriteLine("\nThe menu item was not successfully deleted.");
            }
        }

        private MenuItem GetValuesForMenuItemObjects()
        {
            Console.Clear();

            Console.WriteLine("\nEnter the menu item number:");
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
            string combindedString = string.Join(", ", item.Ingredients);

            Console.WriteLine($"\n\t#{item.MealNumber}\n" +
                $"\tName: {item.MealName}\n" +
                $"\tDescription: {item.Description}\n" +
                $"\tIngredients: {combindedString}\n" +
                $"\tPrice: ${item.Price}\n");
        }

        private void ShowOnlyMealItemByNumAndName()
        {
            foreach (var item in _repo.GetMenuItems())
            {
                Console.WriteLine($"\n\t#{item.MealNumber}\n" +
                $"\tName: {item.MealName}");
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
