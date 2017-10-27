using ClubWorld.Database.EntityModel;
using ClubWorld.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubWorld.Database.Services
{
    class Booking
    {
        ClubWorldDbContext db = new ClubWorldDbContext();
        
        public List<GetBookingsForDay_Result> SessionDetailsForDay(DateTime DateRequired)
        {
            Repository<GetBookingsForDay_Result> repo = new Repository<GetBookingsForDay_Result>(db);
            return repo.GetAll().ToList();
        }
        public void BookSession(string Description, DateTime Booked, int Status, int EntryType, int Rink, int Session)
        {
            Repository<Booking_Diary> repo = new Repository<Booking_Diary>(db);
            repo.ExecInsertOrUpdateSP("InsertRinkBooking", Description, Booked, Status, EntryType, Rink, Session);
        }

    }
}
