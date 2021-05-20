using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge_Repository
{
    public class BadgesRepository
    {
        private readonly Dictionary<int, List<string>> _dictionary = new Dictionary<int, List<string>>();

        //CREATE
        public bool AddBadgeToDictionary(Badge badge)
        {
            int initialCount = _dictionary.Count;

            _dictionary.Add(badge.BadgeID, badge.DoorName);

            bool wasAdded = _dictionary.Count > initialCount;
            return wasAdded;
        }

        //READ
        public Dictionary<int, List<string>> GetListBadge()
        {
            return _dictionary;
        }
 

        //UPDATE ADD
        public bool EditDoorAddByID(int badgeID, string doorName)
        {
            int firstCount = _dictionary[badgeID].Count;
            _dictionary[badgeID].Add(doorName);
            int secondCount = _dictionary[badgeID].Count;

            return secondCount > firstCount;
        }

        //UPDATE REMOVE
        public bool EditDoorRemoveByID(int badgeID, string doorName)
        {
            int firstCount = _dictionary[badgeID].Count;
            _dictionary[badgeID].Remove(doorName);
            int secondCount = _dictionary[badgeID].Count;

            return secondCount < firstCount;
        }

        //HELPER METHODS
        public List<string> GetBadgeInfoByID(int badgeID)
        {
            return _dictionary[badgeID];
        }
    }
}
