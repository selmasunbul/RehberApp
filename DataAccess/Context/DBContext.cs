using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Context
{
    public class DBContext : DbContext
    {
        private readonly IConfiguration? _configuration;

        public DBContext()
        {
        }

        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region  BilgiTipi

            modelBuilder.Entity<BilgiTipi>()
               .HasMany(A => A.IletisimBilgileri)
               .WithOne(A => A.BilgiTipi)
               .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region  BilgiTipi

            modelBuilder.Entity<IletisimBilgisi>();

            #endregion

            #region  Kisi

            modelBuilder.Entity<Kisi>()
               .HasMany(A => A.IletisimBilgileri)
               .WithOne(A => A.Kisi)
               .OnDelete(DeleteBehavior.NoAction);

            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var x = "Host=localhost;Port=5432;Database=Rehber;User Id=postgres;Password=123456;";

            optionsBuilder.UseNpgsql(x);
        }

      
    }
}
