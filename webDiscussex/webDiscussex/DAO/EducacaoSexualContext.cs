using Microsoft.EntityFrameworkCore;
using webDiscussex.Models;

namespace webDiscussex.DAO
{
    public class EducacaoSexualContext: DbContext
    {
        public DbSet<Imagem> PP2_Imagem { get; set; }

        public DbSet<Usuario> PP2_Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=regulus;Initial Catalog=PR118194;User ID=PR118194;Password=guisa2019");
        }
    }
}