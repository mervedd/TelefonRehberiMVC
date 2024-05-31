using Microsoft.EntityFrameworkCore;

namespace TelefonRehberiMVC.Models.MVCDbContext
{
    public class TelefonRehberiDbContext:DbContext
    {
        public DbSet <Phone>Phones{ get; set; }
        public DbSet<Persons>Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-LCDHNHB;Initial Catalog=TelefonRehberi;Integrated Security=True; TrustServerCertificate=True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
