using MyStartup.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;

namespace MyStartup.Data
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        public static readonly LoggerFactory GameContextLoggerFactory =
            new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name &&
                    level == LogLevel.Information, true)
            });

        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  Seed
            var switchPlatform = new Platform { Id = 1, Name = "Nintendo Switch" };

            var marioGame = new Game { Id = 1, PublishDate = new DateTime(2017, 10, 27), Title = "Super Mario Odyssey" };
            var zeldaGame = new Game { Id = 2, PublishDate = new DateTime(2017, 3, 3), Title = "The Legend of Zelda: Breath of the Wild" };

            modelBuilder.Entity<Platform>().HasData(switchPlatform);
            modelBuilder.Entity<Game>().HasData(marioGame, zeldaGame);
        }
    }
}
