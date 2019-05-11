using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webDiscussex.Models;

namespace webDiscussex.DAO
{
    public class UsuarioGoogleDAO
    {
        public IList<UsuarioGoogle> Lista()
        {
            using (var contexto = new EducacaoSexualContext())
            {
                IList<UsuarioGoogle> lista = contexto.PP2_UsuarioGoogle.ToList();

                return lista;
            }
        }

        public void Atualiza(UsuarioGoogle user)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                contexto.Entry(user).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public int AddAndReturn(UsuarioGoogle novo)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                contexto.PP2_UsuarioGoogle.Add(novo);
                contexto.SaveChanges();
            }

            return novo.Id;
        }
    }
}