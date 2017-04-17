namespace WebApplication10.Data
{
    using global::Models;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BettingOddsContext : DbContext
    {
        public BettingOddsContext()
            : base("BettingOddsContext")
        {
        }

        public DbSet<Sport> Sports { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Odd> Odds { get; set; }

    }
}