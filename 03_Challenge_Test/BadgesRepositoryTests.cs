using _03_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_Challenge_Test
{
    [TestClass]
    public class BadgesRepositoryTests
    {
        private BadgesRepository _repo;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgesRepository();
            _badge = new Badge(123, new List<string> { "A1", "B1", "A2", "A3" });
            _repo.AddBadgeToList(_badge);
        }

        [TestMethod]
        public void AddBadgeToDirectory_ShouldBeTrue()
        {
            Assert.IsTrue(_repo.AddBadgeToDictionary(_badge));
        }

        [TestMethod]
        public void GetListBadge_ShouldBeTrue()
        {
            int initalCount = _repo.GetListBadge().Count;
            Assert.AreEqual(1, initalCount);
        }

        [TestMethod]
        public void EditDoorAddByID_ShouldBeTrue()
        {
            int firstCount = _badge.DoorName.Count;
            _repo.EditDoorAddByID(123, "A5");
            int secoundCount = _badge.DoorName.Count;

            Assert.IsTrue(_badge.DoorName.Contains("A5"));
            Assert.AreEqual(firstCount + 1, secoundCount);
        }

        [TestMethod]
        public void EditDoorRemoveByID_ShouldBeTrue()
        {
            int firstCount = _badge.DoorName.Count;
            _repo.EditDoorRemoveByID(123, "A2");
            int secoundCount = _badge.DoorName.Count;

            Assert.IsFalse(_badge.DoorName.Contains("A2"));
            Assert.AreEqual(firstCount - 1, secoundCount);
        }

    }
}
