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
            return (_listOfMenuItems.Count > startingCount);
        }

        // Read
        public List<MenuItem> GetMenuItems()
        {
            return _listOfMenuItems.OrderBy(m => m.MealNumber).ToList();
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
        public bool UpdateExisitingMenuItemByNumber(int menuItemNum, MenuItem updatedMenuItem)
        {
            MenuItem oldItem = GetMenuItemByNumber(menuItemNum);

            if (oldItem != null)
            {
                oldItem.MealNumber = updatedMenuItem.MealNumber;
                oldItem.MealName = updatedMenuItem.MealName;
                oldItem.Description = updatedMenuItem.Description;
                oldItem.Ingredients = updatedMenuItem.Ingredients;
                oldItem.Price = updatedMenuItem.Price;

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

            return (intialCount > _listOfMenuItems.Count);
        }
    }
}