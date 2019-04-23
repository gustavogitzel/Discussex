using Microsoft.EntityFrameworkCore;
using webDiscussex.Models;

namespace webDiscussex.DAO
{
    public class EducacaoSexualContext: DbContext
    {
        public DbSet<Imagem> PP2_Imagem { get; set; }

        public DbSet<Usuario> PP2_Usuario { get; set; }

        public DbSet<EducacaoSexual> PP2_EducacaoSexual { get; set; }

        public DbSet<Corpo> PP2_Corpo{ get; set; }

        public DbSet<Gravidez> PP2_Gravidez { get; set; }

        public DbSet<Doenca> PP2_Doenca { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=regulus.cotuca.unicamp.br;Initial Catalog=PR118194;User ID=PR118194;Password=guisa2019");
        }
    }
}