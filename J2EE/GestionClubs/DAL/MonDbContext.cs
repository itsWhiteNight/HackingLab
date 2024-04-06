using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class MonDbContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Membre> Membres { get; set; }
        public DbSet<Activite> Activites { get; set; }
        public DbSet<Utilisateur>Utilisateurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=Doudi\SQLEXPRESS;Initial Catalog=GestionClub;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }

        
    }
}
