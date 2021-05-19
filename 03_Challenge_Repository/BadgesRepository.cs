using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge_Repository
{
    public class BadgesRepository
    {
        private readonly List<Badge> _badges = new List<Badge>();
        private readonly Dictionary<int, List<string>> _dictionary = new Dictionary<int, List<string>>();

        //CREATE
        public bool AddBadgeToList(Badge badge)
        {
            int initialCount = _badges.Count;
            _badges.Add(badge);
            bool wasAdded = _badges.Count > initialCount;
            return wasAdded;
        }

        public bool AddBadgeToDictionary(Badge badge)
        {
            int initialCount = _dictionary.Count;

            _dictionary.Add(badge.BadgeID, badge.DoorName);

            bool wasAdded = _dictionary.Count > initialCount;
            return wasAdded;
        }



        //READ
        public List<Badge> GetListBadge()
        {
            return _badges;
        }

        //UPDATE ADD
        public bool EditDoorAddByID(int badgeNum, string doorName)
        {
            Badge old = GetBadgeObjectByID(badgeNum);
            int firstCount = old.DoorName.Count;
            old.DoorName.Add(doorName);
            int secondCount = old.DoorName.Count;
            if (firstCount > secondCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //UPDATE REMOVE
        public bool EditDoorRemoveByID(int badgeNum, string doorName)
        {
            Badge old = GetBadgeObjectByID(badgeNum);
            int firstCount = old.DoorName.Count;
            old.DoorName.Remove(doorName);
            int secondCount = old.DoorName.Count;
            if (firstCount > secondCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //HELPER METHODS
        public Badge GetBadgeObjectByID(int badgeID)
        {
            foreach (var item in _badges)
            {
                if (item.BadgeID == badgeID)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
