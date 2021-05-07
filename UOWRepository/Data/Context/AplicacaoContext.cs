using Microsoft.EntityFrameworkCore;
using UOWRepository.Model;

namespace UOWRepository.Data.Context
{
    public class AplicacaoContext : DbContext
    {
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Funcioanario> Funcioanarios { get; set; }

        public AplicacaoContext(DbContextOptions<AplicacaoContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
