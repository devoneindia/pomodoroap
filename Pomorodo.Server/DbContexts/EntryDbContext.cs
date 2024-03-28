using Microsoft.EntityFrameworkCore;
using Pomorodo.Server.Models;
using System.Collections.Generic;

namespace Pomorodo.Server.DbContexts
{
    public class EntryDbContext : DbContext
    {
        public EntryDbContext(DbContextOptions<EntryDbContext> options)
       : base(options)
        {
        }
        public DbSet<Entry> entries { get; set; }

        public EntryDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configurationInstance = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)?.FullName ?? ".")
                .AddJsonFile("appsettings.json", optional: true)
                //  .AddJsonFile("appsettings.local.json", optional: true)
                .Build();
            string dbConnString = configurationInstance["ConnectionStrings: entrydb"] ?? "";
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            optionsBuilder.UseNpgsql(dbConnString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
