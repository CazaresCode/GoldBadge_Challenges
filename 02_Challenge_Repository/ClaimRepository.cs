using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Repository
{
    class ClaimRepository
    {
        private readonly List<Claim> _listOfClaim = new List<Claim>();

        // Create
         public bool AddClaimToDirectory(Claim newClaim)
        {
            int startingCount = _listOfClaim.Count;
            _listOfClaim.Add(newClaim);
            bool wasAdded = _listOfClaim.Count > startingCount;
            return wasAdded;
        }

        // Read
         

        // Update  DO WE NEED THIS? Nothing says that we need to update it in the prompt. 

        
        // Delete


    }
}
