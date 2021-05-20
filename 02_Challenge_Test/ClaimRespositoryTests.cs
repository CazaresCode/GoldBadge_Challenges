using _02_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_Challenge_Test
{
    [TestClass]
    public class ClaimRespositoryTests
    {
        private ClaimRepository _repo;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
            _claim = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            _repo.AddClaimToDirectory(_claim);
        }

        [TestMethod]
        public void AddClaimToDirectory_ShouldBeTrue()
        {
            Assert.IsTrue(_repo.AddClaimToDirectory(_claim));
        }

        [TestMethod]
        public void GetAllClaimsFromQueue_ShouldBeTrue()
        {
            int initalCount = _repo.GetAllClaimsFromQueue().Count;
            Assert.AreEqual(initalCount, 1);
            Assert.AreNotEqual(initalCount, 2);
        }

        [TestMethod]
        public void PeekClaimFromQueue_ShouldBeTrue()
        {
            Assert.AreEqual( _claim, _repo.PeekClaimFromQueue());
        }

        [TestMethod]
        public void GetClaimsFromQueueById_ShouldBeCorrectObject()
        {
            Claim claim = _repo.GetClaimsFromQueueById(1);
            Assert.AreEqual( _claim, claim);
        }

        [TestMethod]
        public void UpdateExisitingClaimByID_ShouldBeTrue()
        {
            _repo.UpdateExisitingClaimByID(1, new Claim(2, ClaimType.Home, "kitchen fire.", 40000.00m, new DateTime(2018, 04, 20), new DateTime(2018, 04, 30)));

            Assert.AreEqual(_claim.ClaimID, 2);
        }

        [TestMethod]
        public void DequeueFirstClaim_ShouldBeTrue()
        {
            _repo.DequeueFirstClaim("y");
            int count = _repo.GetAllClaimsFromQueue().Count;

            Assert.AreEqual(0, count);
        }
    }
}
