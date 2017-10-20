﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClubWorld.Database.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ClubWorldDbContext : DbContext
    {
        public ClubWorldDbContext()
            : base("name=ClubWorldDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<App_Config> App_Config { get; set; }
        public virtual DbSet<App_Members> App_Members { get; set; }
        public virtual DbSet<Audit_Booking_Diary> Audit_Booking_Diary { get; set; }
        public virtual DbSet<Booking_AvailableSessions> Booking_AvailableSessions { get; set; }
        public virtual DbSet<Booking_Diary> Booking_Diary { get; set; }
        public virtual DbSet<Booking_Integrity> Booking_Integrity { get; set; }
        public virtual DbSet<Booking_Rink> Booking_Rink { get; set; }
        public virtual DbSet<Booking_Type> Booking_Type { get; set; }
        public virtual DbSet<Competition_Draw> Competition_Draw { get; set; }
        public virtual DbSet<Competition_Entries> Competition_Entries { get; set; }
        public virtual DbSet<Competition_List> Competition_List { get; set; }
        public virtual DbSet<League_Fixtures> League_Fixtures { get; set; }
        public virtual DbSet<League_FixtureType> League_FixtureType { get; set; }
        public virtual DbSet<League_List> League_List { get; set; }
        public virtual DbSet<League_RegisteredPlayers> League_RegisteredPlayers { get; set; }
        public virtual DbSet<League_Result> League_Result { get; set; }
        public virtual DbSet<League_ResultPlayers> League_ResultPlayers { get; set; }
        public virtual DbSet<League_Teams> League_Teams { get; set; }
        public virtual DbSet<Competition_Rounds> Competition_Rounds { get; set; }
        public virtual DbSet<VW_League_Details> VW_League_Details { get; set; }
        public virtual DbSet<VW_RinkBookings> VW_RinkBookings { get; set; }
    
        [DbFunction("ClubWorldDbContext", "GenerateCalendar")]
        public virtual IQueryable<GenerateCalendar_Result> GenerateCalendar(Nullable<System.DateTime> fromDate, Nullable<int> noDays)
        {
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));
    
            var noDaysParameter = noDays.HasValue ?
                new ObjectParameter("NoDays", noDays) :
                new ObjectParameter("NoDays", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GenerateCalendar_Result>("[ClubWorldDbContext].[GenerateCalendar](@FromDate, @NoDays)", fromDateParameter, noDaysParameter);
        }
    
        public virtual int AddNewFixture(string desc, Nullable<System.DateTime> booked, Nullable<int> type, Nullable<int> rinkFlag, Nullable<int> session, Nullable<int> leagueId, Nullable<int> homeTeam, Nullable<int> awayTeam)
        {
            var descParameter = desc != null ?
                new ObjectParameter("Desc", desc) :
                new ObjectParameter("Desc", typeof(string));
    
            var bookedParameter = booked.HasValue ?
                new ObjectParameter("Booked", booked) :
                new ObjectParameter("Booked", typeof(System.DateTime));
    
            var typeParameter = type.HasValue ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(int));
    
            var rinkFlagParameter = rinkFlag.HasValue ?
                new ObjectParameter("RinkFlag", rinkFlag) :
                new ObjectParameter("RinkFlag", typeof(int));
    
            var sessionParameter = session.HasValue ?
                new ObjectParameter("Session", session) :
                new ObjectParameter("Session", typeof(int));
    
            var leagueIdParameter = leagueId.HasValue ?
                new ObjectParameter("LeagueId", leagueId) :
                new ObjectParameter("LeagueId", typeof(int));
    
            var homeTeamParameter = homeTeam.HasValue ?
                new ObjectParameter("HomeTeam", homeTeam) :
                new ObjectParameter("HomeTeam", typeof(int));
    
            var awayTeamParameter = awayTeam.HasValue ?
                new ObjectParameter("AwayTeam", awayTeam) :
                new ObjectParameter("AwayTeam", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewFixture", descParameter, bookedParameter, typeParameter, rinkFlagParameter, sessionParameter, leagueIdParameter, homeTeamParameter, awayTeamParameter);
        }
    
        public virtual ObjectResult<GetBookingsForDay_Result> GetBookingsForDay(Nullable<System.DateTime> dateRequired)
        {
            var dateRequiredParameter = dateRequired.HasValue ?
                new ObjectParameter("DateRequired", dateRequired) :
                new ObjectParameter("DateRequired", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBookingsForDay_Result>("GetBookingsForDay", dateRequiredParameter);
        }
    
        public virtual ObjectResult<GetFreeRinks_Result> GetFreeRinks(Nullable<System.DateTime> startDate, Nullable<int> sessionFlag, Nullable<int> dayFlag, Nullable<int> altWeeks, Nullable<int> minFree)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var sessionFlagParameter = sessionFlag.HasValue ?
                new ObjectParameter("SessionFlag", sessionFlag) :
                new ObjectParameter("SessionFlag", typeof(int));
    
            var dayFlagParameter = dayFlag.HasValue ?
                new ObjectParameter("DayFlag", dayFlag) :
                new ObjectParameter("DayFlag", typeof(int));
    
            var altWeeksParameter = altWeeks.HasValue ?
                new ObjectParameter("AltWeeks", altWeeks) :
                new ObjectParameter("AltWeeks", typeof(int));
    
            var minFreeParameter = minFree.HasValue ?
                new ObjectParameter("MinFree", minFree) :
                new ObjectParameter("MinFree", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFreeRinks_Result>("GetFreeRinks", startDateParameter, sessionFlagParameter, dayFlagParameter, altWeeksParameter, minFreeParameter);
        }
    
        public virtual int GetRinkBookings(Nullable<System.DateTime> bookingDate)
        {
            var bookingDateParameter = bookingDate.HasValue ?
                new ObjectParameter("BookingDate", bookingDate) :
                new ObjectParameter("BookingDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetRinkBookings", bookingDateParameter);
        }
    
        public virtual int InsertRinkBooking(string desc, Nullable<System.DateTime> booked, Nullable<int> status, Nullable<int> entryType, Nullable<int> rink, Nullable<int> session)
        {
            var descParameter = desc != null ?
                new ObjectParameter("Desc", desc) :
                new ObjectParameter("Desc", typeof(string));
    
            var bookedParameter = booked.HasValue ?
                new ObjectParameter("Booked", booked) :
                new ObjectParameter("Booked", typeof(System.DateTime));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(int));
    
            var entryTypeParameter = entryType.HasValue ?
                new ObjectParameter("EntryType", entryType) :
                new ObjectParameter("EntryType", typeof(int));
    
            var rinkParameter = rink.HasValue ?
                new ObjectParameter("Rink", rink) :
                new ObjectParameter("Rink", typeof(int));
    
            var sessionParameter = session.HasValue ?
                new ObjectParameter("Session", session) :
                new ObjectParameter("Session", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertRinkBooking", descParameter, bookedParameter, statusParameter, entryTypeParameter, rinkParameter, sessionParameter);
        }
    
        public virtual ObjectResult<League_ShowLeagueTable_Result> League_ShowLeagueTable(Nullable<int> leagueID)
        {
            var leagueIDParameter = leagueID.HasValue ?
                new ObjectParameter("LeagueID", leagueID) :
                new ObjectParameter("LeagueID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<League_ShowLeagueTable_Result>("League_ShowLeagueTable", leagueIDParameter);
        }
    
        public virtual ObjectResult<LeagueResult_TeamsForFixture_Result> LeagueResult_TeamsForFixture(Nullable<int> fixtureId)
        {
            var fixtureIdParameter = fixtureId.HasValue ?
                new ObjectParameter("FixtureId", fixtureId) :
                new ObjectParameter("FixtureId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LeagueResult_TeamsForFixture_Result>("LeagueResult_TeamsForFixture", fixtureIdParameter);
        }
    
        public virtual int LeagueResults_AddResult(Nullable<int> fixtureRef, Nullable<int> homeShots, Nullable<int> awayShots, ObjectParameter resultId)
        {
            var fixtureRefParameter = fixtureRef.HasValue ?
                new ObjectParameter("FixtureRef", fixtureRef) :
                new ObjectParameter("FixtureRef", typeof(int));
    
            var homeShotsParameter = homeShots.HasValue ?
                new ObjectParameter("HomeShots", homeShots) :
                new ObjectParameter("HomeShots", typeof(int));
    
            var awayShotsParameter = awayShots.HasValue ?
                new ObjectParameter("AwayShots", awayShots) :
                new ObjectParameter("AwayShots", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LeagueResults_AddResult", fixtureRefParameter, homeShotsParameter, awayShotsParameter, resultId);
        }
    
        public virtual int LeagueResults_AddResultPlayers(Nullable<int> resultRef, Nullable<int> registrationRef)
        {
            var resultRefParameter = resultRef.HasValue ?
                new ObjectParameter("ResultRef", resultRef) :
                new ObjectParameter("ResultRef", typeof(int));
    
            var registrationRefParameter = registrationRef.HasValue ?
                new ObjectParameter("RegistrationRef", registrationRef) :
                new ObjectParameter("RegistrationRef", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LeagueResults_AddResultPlayers", resultRefParameter, registrationRefParameter);
        }
    
        public virtual ObjectResult<LeagueResults_FixturesForLeague_Result> LeagueResults_FixturesForLeague(Nullable<int> leagueId)
        {
            var leagueIdParameter = leagueId.HasValue ?
                new ObjectParameter("LeagueId", leagueId) :
                new ObjectParameter("LeagueId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LeagueResults_FixturesForLeague_Result>("LeagueResults_FixturesForLeague", leagueIdParameter);
        }
    
        public virtual ObjectResult<LeagueResults_GetFixture_Result> LeagueResults_GetFixture(Nullable<int> fixtureId)
        {
            var fixtureIdParameter = fixtureId.HasValue ?
                new ObjectParameter("FixtureId", fixtureId) :
                new ObjectParameter("FixtureId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LeagueResults_GetFixture_Result>("LeagueResults_GetFixture", fixtureIdParameter);
        }
    
        public virtual ObjectResult<ShowBookingsForDay_Result> ShowBookingsForDay(Nullable<System.DateTime> requestedDate)
        {
            var requestedDateParameter = requestedDate.HasValue ?
                new ObjectParameter("RequestedDate", requestedDate) :
                new ObjectParameter("RequestedDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ShowBookingsForDay_Result>("ShowBookingsForDay", requestedDateParameter);
        }
    }
}
