using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.Booking
{
    public class RinkUnit
    {
        public string HomeRef { get; set; }
        public string AwayRef { get; set; }
        public string HomeName { get; set; }
        public string AwayName { get; set; }
        public string Description { get; set; }
        public string Rink { get; set; }
        public string DiaryRef { get; set; }
        public string Free
        {
            get
            {
                if (DiaryRef == null)
                {
                    return "free";
                }
                return null;
            }
        }
        public string Fixture
        {
            get
            {
                if (HomeRef == "")
                {
                    return DiaryRef;
                }
                else
                {
                    return HomeRef + " v " + AwayRef;
                }
            }
        }
        public string Tooltip
        { 
            get
            {
                if(HomeRef != "")
                {
                    return Description.Trim() + "\n(" + HomeName + " v " + AwayName + ")";
                }
                else if (Description != null)
                {
                    return "Booked\n(" + Description.Trim() + ")";
                }
                else
                {
                    return "";
                }
            }
        }
    }
}