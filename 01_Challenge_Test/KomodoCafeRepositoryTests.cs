using _01_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_Challenge_Test
{
    [TestClass]
    public class KomodoCafeRepositoryTests
    {
        private MenuItemRepository _repo;
        private MenuItem _menuItem;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemRepository();
            _menuItem = new MenuItem(3, "Sammie", "a very simple sandwich", new List<string> { "White Bread", "Meat", "Cheese", "Grey Poupon" }, 14.75);
            _repo.AddMenuItemToDirectory(_menuItem);
        }

        [TestMethod]
        public void AddMenuItemToDirectory_ShouldGetCorrectBoolean()
        {
            Assert.IsTrue(_repo.AddMenuItemToDirectory(_menuItem));
        }

        [TestMethod]
        public void GetMenuItems_ShouldReturnMenuItems()
        {
            List<MenuItem> directory = _repo.GetMenuItems();

            bool directoryHasMenuItems = directory.Contains(_menuItem);
            Assert.IsTrue(directoryHasMenuItems);
        }

        [TestMethod]
        public void GetMenuItemByName_ShouldBeEqual()
        {
            MenuItem searchResult = _repo.GetMenuItemByName("sammie");
            Assert.AreEqual(_menuItem, searchResult);
        }

        [TestMethod]
        public void UpdateExisitingMenuItemByName_ShouldReturnUpdatedValue()
        {
            _repo.UpdateExisitingMenuItemByName("sammie", new MenuItem(1, "Cuban Sammie", "a very simple  Cuban sandwich", new List<string> { "French Sword Bread", "Ham", "White Cheese", "Grey Poupon" }, 15.95));

            Assert.AreEqual(_menuItem.MealName.ToLower(), "cuBan sAMmie".ToLower());
        }

        [TestMethod]
        public void RemoveMenuItemFromList_ShouldReturnTrue()
        {
            bool wasDeleted = _repo.RemoveMenuItemFromList(_menuItem.MealName);

            Assert.IsTrue(wasDeleted);
        }
    }
}


