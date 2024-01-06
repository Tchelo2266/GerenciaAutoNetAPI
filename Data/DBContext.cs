using GerenciaAutoNetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciaAutoNetAPI.Data
{
    public class DBContext(DbContextOptions<DBContext> opts) : DbContext(opts)
    {

        public DbSet<TipoDespesa> TipoDespesa { get; set; }
        public DbSet<Combustivel> Combustivel { get; set; }
        public DbSet<Marca> Marca { get; set; }
    }
}
