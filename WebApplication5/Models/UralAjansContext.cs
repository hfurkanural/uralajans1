using Microsoft.EntityFrameworkCore;
using WebApplication5.Models.MVVM;

namespace WebApplication5.Models
{
    public class UralAjansContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:UralAjansCon"]);
        }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<sp_Search> sp_Searches { get; set; }
        public DbSet<Newsletter> Newsletter { get; set; }
    }
}
