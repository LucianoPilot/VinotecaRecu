using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using VinotecaRecu.Data.Entities;

namespace VinotecaRecu.Data
{
    public class VinotecaRecuContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Cata> Catas { get; set; }

        public VinotecaRecuContext(DbContextOptions<VinotecaRecuContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            User Hideo = new User()
            {
                Id = 1,
                Username = "mgs@gmail.com",
                Password = "Pa$$w0rd",
                Rol = Data.Enum.Rol.Admin
            };

            User Keanu = new User()
            {
                Id = 2,
                Username = "jhonwick@gmail.com",
                Password = "Cl4ve!",
                Rol = Data.Enum.Rol.Admin
            };

            Wine cabernetSauvignon = new Wine()
            {
                Id = 1,
                Name = "Cabernet Sauvignon",
                Variety = "Cabernet Sauvignon",
                Year = 2018,
                Region = "Mendoza",
                Stock = 50,
                CreatedAt = DateTime.UtcNow
            };

            Wine malbec = new Wine()
            {
                Id = 2,
                Name = "Malbec",
                Variety = "Malbec",
                Year = 2020,
                Region = "Mendoza",
                Stock = 30,
                CreatedAt = DateTime.UtcNow
            };


            modelBuilder.Entity<User>().HasData(Hideo, Keanu);
            modelBuilder.Entity<Wine>().HasData(malbec, cabernetSauvignon);

            // Configuración para la relación muchos a muchos
            modelBuilder.Entity<Wine>()
                .HasMany(w => w.Catas)  // 'Wine' tiene muchas 'Catas'
                .WithMany(c => c.Wines) // 'Cata' tiene muchos 'Wines'
                .UsingEntity<Dictionary<string, object>>(
                    "WineCata", // Nombre de la tabla intermedia
                    r => r.HasOne<Cata>().WithMany().HasForeignKey("CataId"), // ForeignKey de Cata
                    l => l.HasOne<Wine>().WithMany().HasForeignKey("WineId") // ForeignKey de Wine
                );

            base.OnModelCreating(modelBuilder);
        }

       

    }


}
