using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Repository
{
    public class ClaimRepository
    {
        private readonly Queue<Claim> _queueOfClaims = new Queue<Claim>();

        // Create
        public bool AddClaimToDirectory(Claim newClaim)
        {
            int startingCount = _queueOfClaims.Count;
            _queueOfClaims.Enqueue(newClaim);
            bool wasAdded = _queueOfClaims.Count > startingCount;
            return wasAdded;
        }

        // Read
        public Claim PeekClaimFromQueue()
        {
            return _queueOfClaims.Peek();
        }

        public Queue<Claim> GetAllClaimsFromQueue()
        {
            return _queueOfClaims;
        }

        public Claim GetClaimsFromQueueById(int claimID)
        {
            foreach (var item in _queueOfClaims)
            {
                if (item.ClaimID == claimID)
                {
                    return item;
                }
            }
            return null;
        }

        // Update 
        public bool UpdateExisitingClaimByID(int claimID, Claim updatedClaim)
        {
            Claim oldClaim = GetClaimsFromQueueById(claimID);

            if (oldClaim != null)
            {
                oldClaim.ClaimID = updatedClaim.ClaimID;
                oldClaim.TypeOfClaim = updatedClaim.TypeOfClaim;
                oldClaim.Description = updatedClaim.Description;
                oldClaim.ClaimAmount = updatedClaim.ClaimAmount;
                oldClaim.DateOfIncident = updatedClaim.DateOfIncident;
                oldClaim.DateOfClaim = updatedClaim.DateOfClaim;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Dequeue

        public bool RemoveFirstClaimFromQuene(int claimNumber)
        {
            Claim claim = GetClaimsFromQueueById(claimNumber);

            if (claim == null)
            {
                return false;
            }

            int intialCount = _queueOfClaims.Count;
            _queueOfClaims.Dequeue();

            if (intialCount > _queueOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DequeueClaimFromQueue(char response)
        {
            if (response == 'y')
            {
                _queueOfClaims.Dequeue();
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete any object
        //not sure if this would work...
        public bool DeleteClaimFromList(int claimNumber)
        {
            Claim claimToDelete = GetClaimsFromQueueById(claimNumber);
            if (claimToDelete == null)
            {
                return false;
            }
            else
            {
                int initalCount = _queueOfClaims.Count();

                foreach (var item in _queueOfClaims)
                {
                        Queue<int> newQueue = new Queue<int>(new int[] { item.ClaimID });

                        newQueue = new Queue<int>(newQueue.Where(x => x != claimToDelete.ClaimID));
                        int updatedClaimCount = newQueue.Count();

                        foreach (var newItem in newQueue)
                        {
                            if (newItem == item.ClaimID)
                            {
                                _queueOfClaims.Enqueue(item);

                                if (initalCount > updatedClaimCount)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                }
                return true;
            }
        }
    }
}
