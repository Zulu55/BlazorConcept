using BlazorConcept.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorConcept.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedDb(modelBuilder);
        }

        private void SeedDb(ModelBuilder modelBuilder)
        {
            SeedTeams(modelBuilder);
        }

        private void SeedTeams(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(new Team { Id = 1, Name = "Colombia" });
            modelBuilder.Entity<Team>().HasData(new Team { Id = 2, Name = "Argentina" });
            modelBuilder.Entity<Team>().HasData(new Team { Id = 3, Name = "Brasil" });
            modelBuilder.Entity<Team>().HasData(new Team { Id = 4, Name = "Uruguay" });
        }
    }
}
