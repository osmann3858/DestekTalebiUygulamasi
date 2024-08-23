using Microsoft.EntityFrameworkCore;

namespace DestekTalebiUygulamasi.Models
{
    

    public class AppDbContext : DbContext
    {
        public DbSet<DestekTalebi> DestekTalepleri { get; set; }
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
  
}
