using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using tp3.Models;

namespace tp3.Data
{
    public class ApplicationdbContext : DbContext
    {
        public ApplicationdbContext(DbContextOptions options) : base(options) { }

        public DbSet<Movies> movies { get; set; }
        public DbSet<Genres> genres { get; set; }
        public DbSet<Customers> customers { get; set; }
        public DbSet<Membershiptypes> membershiptypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            string GenreJSon = System.IO.File.ReadAllText("Genres.Json");
            List<Genres>? genres = System.Text.Json.JsonSerializer.Deserialize<List<Genres>>(GenreJSon);
            foreach (Genres c in genres)
                modelBuilder.Entity<Genres>()
                .HasData(c);

        }
    }
}
