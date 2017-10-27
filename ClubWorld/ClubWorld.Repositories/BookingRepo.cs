using ClubWorld.Data.SQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubWorld.Repositories
{
    public class BookingRepo
    {
        ClubWorldContext _db = new ClubWorldContext();

        public List<BookingsForDay> SessionDetailsForDay(DateTime DateRequired)
        {
            return _db.GetBookingsForDay(DateRequired).ToList();
        }
        public void BookSession(string Description, DateTime Booked, int Status, int EntryType, int Rink, int Session)
        {
            _db.InsertRinkBooking(Description, Booked, Status, EntryType, Rink, Session);
        }
    }
}
