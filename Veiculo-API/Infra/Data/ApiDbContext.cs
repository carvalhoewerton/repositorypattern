using Microsoft.EntityFrameworkCore;
using Veiculo_API.Dominio;

namespace Veiculo_API.Infra.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("ConexaoPadrao"); // Substitua pela sua string de conexão
            }
        }

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}