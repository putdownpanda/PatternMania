using Microsoft.EntityFrameworkCore;
using PatternMania.HorseBettingNotificationPatterns.CoreProblem.Models;
using PatternMania.NotificationPatterns.CoreProblem.Models;

namespace HorseBettingNotifications.Core.Data
{
    public class HBDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Bet> Bets => Set<Bet>();
        public DbSet<Meeting> Meetings => Set<Meeting>();
        public DbSet<Race> Races => Set<Race>();
        public DbSet<Horse> Horses => Set<Horse>();
        public DbSet<BetType> BetTypes => Set<BetType>();

        public HBDbContext(DbContextOptions<HBDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed sample ULUlid values
            var user1Ulid = Ulid.NewUlid(DateTime.UtcNow).ToString();
            var user2Ulid = Ulid.NewUlid(DateTime.UtcNow).ToString();
            var meetingUlid = Ulid.NewUlid(DateTime.UtcNow).ToString();
            var raceUlid = Ulid.NewUlid(DateTime.UtcNow).ToString();
            var horse1Ulid = Ulid.NewUlid(DateTime.UtcNow).ToString();
            var horse2Ulid = Ulid.NewUlid(DateTime.UtcNow).ToString();
            var winBetTypeUlid = Ulid.NewUlid(DateTime.UtcNow).ToString();
            var placeBetTypeUlid = Ulid.NewUlid(DateTime.UtcNow).ToString();
            var bet1Ulid = Ulid.NewUlid(DateTime.UtcNow).ToString();
            var bet2Ulid = Ulid.NewUlid(DateTime.UtcNow).ToString();

            modelBuilder.Entity<User>().HasData(
                new User { Ulid = user1Ulid, Username = "jockey_joe", PreferredChannel = "Email" },
                new User { Ulid = user2Ulid, Username = "lucky_lucy", PreferredChannel = "SMS" }
            );

            modelBuilder.Entity<Meeting>().HasData(
                new Meeting { Ulid = meetingUlid, Location = "Ascot", Date = DateTime.UtcNow.Date }
            );

            modelBuilder.Entity<Race>().HasData(
                new Race { Ulid = raceUlid, Name = "Race 1", MeetingUlid = meetingUlid, StartTime = DateTime.UtcNow.AddHours(1) }
            );

            modelBuilder.Entity<Horse>().HasData(
                new Horse { Ulid = horse1Ulid, Name = "MUlidnight Thunder" },
                new Horse { Ulid = horse2Ulid, Name = "Golden Arrow" }
            );

            modelBuilder.Entity<BetType>().HasData(
                new BetType { Ulid = winBetTypeUlid, Name = "Win" },
                new BetType { Ulid = placeBetTypeUlid, Name = "Place" }
            );

            modelBuilder.Entity<Bet>().HasData(
                new Bet
                {
                    Ulid = bet1Ulid,
                    UserUlid = user1Ulid,
                    RaceUlid = raceUlid,
                    HorseUlid = horse1Ulid,
                    BetTypeUlid = winBetTypeUlid,
                    Amount = 100,
                    PlacedAt = DateTime.UtcNow
                },
                new Bet
                {
                    Ulid = bet2Ulid,
                    UserUlid = user2Ulid,
                    RaceUlid = raceUlid,
                    HorseUlid = horse2Ulid,
                    BetTypeUlid = placeBetTypeUlid,
                    Amount = 250,
                    PlacedAt = DateTime.UtcNow
                }
            );
        }
    }
}
