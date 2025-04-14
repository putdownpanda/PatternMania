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
        public DbSet<Runner> Horses => Set<Runner>();
        public DbSet<BetType> BetTypes => Set<BetType>();

        public HBDbContext(DbContextOptions<HBDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure primary keys
            modelBuilder.Entity<User>().HasKey(u => u.Ulid);
            modelBuilder.Entity<Bet>().HasKey(b => b.Ulid);
            modelBuilder.Entity<Meeting>().HasKey(m => m.Ulid);
            modelBuilder.Entity<Race>().HasKey(r => r.Ulid);
            modelBuilder.Entity<Runner>().HasKey(h => h.Ulid);
            modelBuilder.Entity<BetType>().HasKey(bt => bt.Ulid);


            // Configure relationships
            modelBuilder.Entity<Bet>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserUlid);

            modelBuilder.Entity<Bet>()
                .HasOne(b => b.BetType)
                .WithMany(b => b.Bets)
                .HasForeignKey(b => b.BetTypeUlid);

            modelBuilder.Entity<Race>()
                .HasOne(r => r.Meeting)
                .WithMany(m => m.Races)
                .HasForeignKey(r => r.MeetingUlid);

            modelBuilder.Entity<Runner>()
                .HasOne(r => r.Race)
                .WithMany(r => r.Runners)
                .HasForeignKey(r => r.RaceUlid);

            base.OnModelCreating(modelBuilder);

            var user1 = new User { Username = "jockey_joe", PreferredChannel = "Email" };
            var user2 = new User { Username = "lucky_lucy", PreferredChannel = "SMS" };
            var meeting = new Meeting { Location = "Ascot", Date = DateTime.UtcNow.Date };
            var race = new Race {Name = "Race 1", MeetingUlid = meeting.Ulid, StartTime = DateTime.UtcNow.AddHours(1) };
            var horse1 = new Runner { Name = "Midnight Thunder", Trainer = "bobby", Jockey = "Harriet", RaceUlid = race.Ulid };
            var horse2 = new Runner { Name = "golden Arrow", Trainer = "Indy", Jockey = "Marget", RaceUlid = race.Ulid };
            var win = new BetType { Name = "Win" };
            var place = new BetType { Name = "Place" };
            var trifecta = new BetType { Name = "Trifecta" };
            var firstFour = new BetType { Name = "FF" };

            var bet1 = new Bet { 
                Amount = 200, 
                BetTypeUlid = win.Ulid, 
                PlacedAt = DateTime.UtcNow, 
                Races = race.Ulid,
                Runners = horse1.Ulid, 
                UserUlid = user1.Ulid
            };
            var bet2 = new Bet
            {
                Amount = 150,
                BetTypeUlid = place.Ulid,
                PlacedAt = DateTime.UtcNow,
                Races = race.Ulid,
                Runners = horse2.Ulid,
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

            modelBuilder.Entity<Runner>().HasData(
                horse1,
                horse2
            );

            modelBuilder.Entity<BetType>().HasData(
                win,
                place,
                trifecta,
                firstFour
            );

            modelBuilder.Entity<Bet>().HasData(
                bet1,
                bet2
            );
        }
    }
}
