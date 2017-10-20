using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ClubWorld.DataAccess.ClubWorldDB.Stored_Procs;

namespace ClubWorld.DataAccess.ClubWorldDB
{
    public partial class ClubworldContext : DbContext
    {
        public virtual DbSet<AppConfig> AppConfig { get; set; }
        public virtual DbSet<AppMembers> AppMembers { get; set; }
        public virtual DbSet<AuditBookingDiary> AuditBookingDiary { get; set; }
        public virtual DbSet<BookingAvailableSessions> BookingAvailableSessions { get; set; }
        public virtual DbSet<BookingDiary> BookingDiary { get; set; }
        public virtual DbSet<BookingIntegrity> BookingIntegrity { get; set; }
        public virtual DbSet<BookingRink> BookingRink { get; set; }
        public virtual DbSet<BookingType> BookingType { get; set; }
        public virtual DbSet<CompetitionDraw> CompetitionDraw { get; set; }
        public virtual DbSet<CompetitionEntries> CompetitionEntries { get; set; }
        public virtual DbSet<CompetitionList> CompetitionList { get; set; }
        public virtual DbSet<LeagueFixtures> LeagueFixtures { get; set; }
        public virtual DbSet<LeagueFixtureType> LeagueFixtureType { get; set; }
        public virtual DbSet<LeagueList> LeagueList { get; set; }
        public virtual DbSet<LeagueRegisteredPlayers> LeagueRegisteredPlayers { get; set; }
        public virtual DbSet<LeagueResult> LeagueResult { get; set; }
        public virtual DbSet<LeagueResultPlayers> LeagueResultPlayers { get; set; }
        public virtual DbSet<LeagueTeams> LeagueTeams { get; set; }
        
        //**************************
        //      Stored Procs
        //**************************
        public DbSet<LeagueResults_FixturesForLeague> LeagueResults_FixturesForLeague { get; set; }

        // Unable to generate entity type for table 'ClubWorld.Competition_Rounds'. Please see the warning messages.
        // Unable to generate entity type for table 'ClubWorld.Booking_Status'. Please see the warning messages.
        // Unable to generate entity type for table 'ClubWorld.Temp_League_FixtureType'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.;Database=Clubworld;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "ClubWorld");

            modelBuilder.Entity<AppConfig>(entity =>
            {
                entity.ToTable("App_Config");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppMembers>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.ToTable("App_Members");

                entity.Property(e => e.Forename)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<AuditBookingDiary>(entity =>
            {
                entity.HasKey(e => e.AuditId);

                entity.ToTable("Audit_Booking_Diary");

                entity.Property(e => e.BookedDate).HasColumnType("date");

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<BookingAvailableSessions>(entity =>
            {
                entity.HasKey(e => e.SessionId);

                entity.ToTable("Booking_AvailableSessions");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BookingDiary>(entity =>
            {
                entity.HasKey(e => e.DiaryId);

                entity.ToTable("Booking_Diary");

                entity.Property(e => e.BookedDate).HasColumnType("date");

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<BookingIntegrity>(entity =>
            {
                entity.HasKey(e => e.IntegrityId);

                entity.ToTable("Booking_Integrity");

                entity.HasIndex(e => new { e.BookingRef, e.BookedDate, e.TeamRef })
                    .HasName("IX_DuplicateTeam")
                    .IsUnique();

                entity.Property(e => e.BookedDate).HasColumnType("date");
            });

            modelBuilder.Entity<BookingRink>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.ToTable("Booking_Rink");
            });

            modelBuilder.Entity<BookingType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("Booking_Type");

                entity.Property(e => e.TypeId).ValueGeneratedNever();

                entity.Property(e => e.TypeEnum)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompetitionDraw>(entity =>
            {
                entity.HasKey(e => e.DrawId);

                entity.ToTable("Competition_Draw");
            });

            modelBuilder.Entity<CompetitionEntries>(entity =>
            {
                entity.HasKey(e => e.EntrantId);

                entity.ToTable("Competition_Entries");
            });

            modelBuilder.Entity<CompetitionList>(entity =>
            {
                entity.HasKey(e => e.CompetitionId);

                entity.ToTable("Competition_List");

                entity.Property(e => e.CompetitionName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<LeagueFixtures>(entity =>
            {
                entity.HasKey(e => e.FixtureId);

                entity.ToTable("League_Fixtures");

                entity.HasOne(d => d.DiaryRefNavigation)
                    .WithMany(p => p.LeagueFixtures)
                    .HasForeignKey(d => d.DiaryRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_League_Fixtures_Diary");
            });

            modelBuilder.Entity<LeagueFixtureType>(entity =>
            {
                entity.HasKey(e => e.FixtureTypeId);

                entity.ToTable("League_FixtureType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LeagueList>(entity =>
            {
                entity.HasKey(e => e.LeagueId);

                entity.ToTable("League_List");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<LeagueRegisteredPlayers>(entity =>
            {
                entity.HasKey(e => e.RegistrationId);

                entity.ToTable("League_RegisteredPlayers");

                entity.HasOne(d => d.TeamRefNavigation)
                    .WithMany(p => p.LeagueRegisteredPlayers)
                    .HasForeignKey(d => d.TeamRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_League_RegisteredPlayers_League_Teams");
            });

            modelBuilder.Entity<LeagueResult>(entity =>
            {
                entity.HasKey(e => e.ResultId);

                entity.ToTable("League_Result");

                entity.Property(e => e.ResultId).HasColumnName("ResultID");

                entity.HasOne(d => d.FixtureRefNavigation)
                    .WithMany(p => p.LeagueResult)
                    .HasForeignKey(d => d.FixtureRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_League_Result_League_Fixtures");
            });

            modelBuilder.Entity<LeagueResultPlayers>(entity =>
            {
                entity.HasKey(e => e.ResultPlayerId);

                entity.ToTable("League_ResultPlayers");
            });

            modelBuilder.Entity<LeagueTeams>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.ToTable("League_Teams");

                entity.HasIndex(e => new { e.TeamName, e.LeagueRef })
                    .HasName("IX_Teams")
                    .IsUnique();

                entity.Property(e => e.TeamName).HasMaxLength(100);

                entity.HasOne(d => d.LeagueRefNavigation)
                    .WithMany(p => p.LeagueTeams)
                    .HasForeignKey(d => d.LeagueRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_League_Teams_League_List");
            });
        }
    }
}
