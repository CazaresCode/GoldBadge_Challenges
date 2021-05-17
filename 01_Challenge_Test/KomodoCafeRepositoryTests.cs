using GoldBadgeConsoleApplicationChallenges;
using GoldBadgeConsoleApplicationChallenges.KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_Challenge_Test
{
    [TestClass]
    public class KomodoCafeRepositoryTests
    {
        private MenuItem _menuItem;
        private MenuItemRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemRepository();
            _menuItem = new MenuItem(3, "Sammie", "a very simple sandwich", new List<string> { "White Bread", "Meat", "Cheese", "Grey Poupon" }, 14.75);
            _repo.AddMenuItemToList(_menuItem);
        }


        [TestMethod]
        public void TestMethod1()
        {
            //Create a Test Class for your repository methods. (You don't need to test your constructors or objects, just your methods)



        }
    }
}
