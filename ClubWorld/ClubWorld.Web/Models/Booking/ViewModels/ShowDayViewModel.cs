using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.Booking.ViewModels
{
    public class ShowDayViewModel
    {
        DateTime _viewDate;
        public ShowDayViewModel(DateTime ShowDate)
        {
            _viewDate = ShowDate;
        }
        List<Session> _SessionList = new List<Session>();
        public List<Session> SessionList{ get { return _SessionList; } }
        public DateTime ViewDate { get { return _viewDate; } }
    }
}