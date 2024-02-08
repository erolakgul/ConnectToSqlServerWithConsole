using ConnectToSqlServerWithConsole.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace ConnectToSqlServerWithConsole.Data.Context
{
    public class IotContext : DbContext
    {
        public virtual DbSet<LOGS> Logs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HAUSCL-410\\BESIKTASDEV;User ID=sa;Password=İstanbul88*;Database=IotMasterDb_v1;Trusted_Connection=True; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LOGS>(entity =>
            {
                //entity.Property(e => e.ID).IsRequired();
                entity.ToTable("LOGS");
                entity.HasKey(e => e.ID);
            });
        }
    }
}
