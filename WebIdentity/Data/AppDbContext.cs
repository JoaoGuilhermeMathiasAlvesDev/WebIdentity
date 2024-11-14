using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebIdentity.Entities;

namespace WebIdentity.Data
{
    public class AppDbContext :IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Joao Guilherme",
                    Email = "joaoguilhermemalves@gmail.com",
                    Idade = 26,
                    DataCadastro = DateTime.Now,
                });
        }
    }
}
