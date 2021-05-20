using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge_Repository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorName { get; set; } 

        public Badge(int badgeID, List<string> doorName)
        {
            BadgeID = badgeID;
            DoorName = doorName;
        }
    }
}
