using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteTDD.Models;

namespace TesteTDD.DAO
{
    public class UsuarioDAO
    {
        public Usuario BuscaPorEmail(string email)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                return contexto.PP2_Usuario.Where(p => p.Email == email).FirstOrDefault();
            }
        }
    }
}
