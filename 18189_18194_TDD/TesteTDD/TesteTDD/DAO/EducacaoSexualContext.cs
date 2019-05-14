using Microsoft.EntityFrameworkCore;
using TesteTDD.Models;

namespace TesteTDD.DAO
{
    class EducacaoSexualContext : DbContext
    {
        public DbSet<Usuario> PP2_Usuario { get; set; }

        public DbSet<Pergunta> PP2_Pergunta { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=regulus.cotuca.unicamp.br;Initial Catalog=PR118194;User ID=PR118194;Password=guisa2019");
        }
    }
}
