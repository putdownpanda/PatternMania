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

            // Configure primary keys
            modelBuilder.Entity<User>().HasKey(u => u.Ulid);
            modelBuilder.Entity<Bet>().HasKey(b => b.Ulid);
            modelBuilder.Entity<Meeting>().HasKey(m => m.Ulid);
            modelBuilder.Entity<Race>().HasKey(r => r.Ulid);
            modelBuilder.Entity<Horse>().HasKey(h => h.Ulid);
            modelBuilder.Entity<BetType>().HasKey(bt => bt.Ulid);

            base.OnModelCreating(modelBuilder);

            var user1 = new User { Username = "jockey_joe", PreferredChannel = "Email" };
            var user2 = new User { Username = "lucky_lucy", PreferredChannel = "SMS" };
            var meeting = new Meeting { Location = "Ascot", Date = DateTime.UtcNow.Date };
            var race = new Race {Name = "Race 1", MeetingUlid = meeting.Ulid, StartTime = DateTime.UtcNow.AddHours(1) };
            var horse1 = new Horse { Name = "Midnight Thunder", RaceUlid = race.Ulid };
            var horse2 = new Horse { Name = "golden Arrow", RaceUlid = race.Ulid };
            var betType1 = new BetType { Name = "Win" };
            var betType2 = new BetType { Name = "Place" };

            var bet1 = new Bet { 
                Amount = 200, 
                BetTypeUlid = betType1.Ulid, 
                PlacedAt = DateTime.UtcNow, 
                RaceUlid = race.Ulid, 
                HorseUlid = horse1.Ulid, 
                UserUlid = user1.Ulid
            };
            var bet2 = new Bet
            {
                Amount = 150,
                BetTypeUlid = betType2.Ulid,
                PlacedAt = DateTime.UtcNow,
                RaceUlid = race.Ulid,
                HorseUlid = horse2.Ulid,
                UserUlid = user2.Ulid
            };

            modelBuilder.Entity<User>().HasData(
                user1,
                user2
            );

            modelBuilder.Entity<Meeting>().HasData(
                meeting 
            );

            modelBuilder.Entity<Race>().HasData(race
            );

            modelBuilder.Entity<Horse>().HasData(
                horse1,
                horse2
            );

            modelBuilder.Entity<BetType>().HasData(
                betType1,
                betType2
            );

            modelBuilder.Entity<Bet>().HasData(
                bet1,
                bet2
            );
        }
    }
}
