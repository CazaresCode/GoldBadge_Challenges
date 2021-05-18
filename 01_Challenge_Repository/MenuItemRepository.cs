using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge_Repository
{
    public class MenuItemRepository
    {
        private readonly List<MenuItem> _listOfMenuItems = new List<MenuItem>();

        // Create
        public bool AddMenuItemToDirectory(MenuItem item)
        {
            int startingCount = _listOfMenuItems.Count;
            _listOfMenuItems.Add(item);
            bool wasAdded = _listOfMenuItems.Count > startingCount;
            return wasAdded;
        }

        // Read
        public List<MenuItem> GetMenuItems()
        {
            return _listOfMenuItems;
        }

        public MenuItem GetMenuItemByName(string menuItemName)
        {
            foreach (MenuItem item in _listOfMenuItems)
            {
                if (item.MealName.ToLower() == menuItemName.ToLower())
                {
                    return item;
                }
            }

            return null;
        }

        public MenuItem GetMenuItemByNumber(int menuNumber)
        {
            foreach (var item in _listOfMenuItems)
            {
                if (item.MealNumber == menuNumber)
                {
                    return item;
                }
            }

            return null;
        }

        // Update
        public bool UpdateExisitingMenuItemByNumber(int menuItemName, MenuItem updatedMenuItemName)
        {
            MenuItem oldItem = GetMenuItemByNumber(menuItemName);

            if (oldItem != null)
            {
                oldItem.MealNumber = updatedMenuItemName.MealNumber;
                oldItem.MealName = updatedMenuItemName.MealName;
                oldItem.Description = updatedMenuItemName.Description;
                oldItem.Ingredients = updatedMenuItemName.Ingredients;
                oldItem.Price = updatedMenuItemName.Price;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool RemoveMenuItemFromListByNumber(int menuItemNum)
        {
            MenuItem item = GetMenuItemByNumber(menuItemNum);

            if (item == null)
            {
                return false;
            }

            int intialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(item);

            if (intialCount > _listOfMenuItems.Count)
            {
                return true;
                //could add a cw successfully removed item...
            }
            else
            {
                return false;
            }
        }
    }
}