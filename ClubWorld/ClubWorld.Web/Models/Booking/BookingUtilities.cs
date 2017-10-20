using ClubWorld.Models.DataAccess;
using ClubWorld.Models.Booking.ViewModels;
using ClubWorld.Models.Fixtures;
using ClubWorld.Models.League;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.Booking
{
    public static class  BookingUtilities
    {
        public static ShowDayViewModel PrepareModel(DateTime DateRequired)
        {
            int SessionCount = _Repository.MaxSessions();
            List<GetBookingsForDay_Result> rec = _Repository.SessionDetailsForDay(DateRequired);

            ShowDayViewModel sdm = new ShowDayViewModel(DateRequired);

            for (int i = 1; i <= SessionCount; i++)
            {
                Session ses = new Session(i);
                var units =
                    from r in rec
                    where r.SessionId == i
                    select new RinkUnit
                    {
                        Rink = r.Rink.ToString(),
                        DiaryRef = r.DiaryId,
                        Description = r.Description,
                        HomeRef = r.HomeRef.ToString(),
                        HomeName = r.HomeName,
                        AwayRef = r.AwayRef.ToString(),
                        AwayName = r.AwayName
                    };

                foreach (RinkUnit unit in units)
                {
                    ses.session.Add(unit);
                }

                sdm.SessionList.Add(ses);
            }

            return sdm;
        }
        public static Boolean BookSession(JSONSession session)
        {
            foreach (JSONRinkUnit r in session.RequestedSessions)
            {
                _Repository.BookSession(session.Description, DateTime.Parse(session.BookingDate), 1, 0, Int32.Parse(r.Rink), Int32.Parse(r.Session));
            }
            return true;
        }
    }
}