using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webDiscussex.Models;
using Microsoft.EntityFrameworkCore;

namespace webDiscussex.DAO
{
    public class UsuarioGoogleDAO
    {
        public void Adiciona(UsuarioGoogle us)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                contexto.PP2_UsuarioGoogle.Add(us);
                contexto.SaveChanges();
            }
        }

        public void Excluir(string e)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                UsuarioGoogle user;
                if((user = BuscaPorEmail(e)) != null)
                {
                    contexto.PP2_UsuarioGoogle.Remove(user);
                    contexto.SaveChanges();
                }
            }
        }

        public UsuarioGoogle BuscaPorEmail(string email)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                return contexto.PP2_UsuarioGoogle.Where(p => p.Email == email).FirstOrDefault();
            }
        }

        public UsuarioGoogle BuscaPorNome(string nome)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                var user = contexto.PP2_UsuarioGoogle.Where(p => p.Nome == nome).FirstOrDefault();
                
                 return user;
            }
        }

        public UsuarioGoogle BuscaPorId(int id)
        {
            using(var contexto = new EducacaoSexualContext())
            {
                return contexto.PP2_UsuarioGoogle.Where(p => p.Id == id).FirstOrDefault(); ;
            }
        }

        public UsuarioGoogle Login(string email)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                List<UsuarioGoogle> ret;
                
                ret = contexto.PP2_UsuarioGoogle.FromSql("loginGoogleDiscussex_sp @p0", parameters: new[] { email }).ToList();
                
          
                return ret.ElementAt(0);
            }
                
        }

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
        
    }
}