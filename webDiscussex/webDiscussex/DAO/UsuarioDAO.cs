using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webDiscussex.Models;
using Microsoft.EntityFrameworkCore;

namespace webDiscussex.DAO
{
    public class UsuarioDAO
    {
        public void Adiciona(Usuario us)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                contexto.PP2_Usuario.Add(us);
                contexto.SaveChanges();
            }
        }
        /*

        public void Alterar(Usuario us)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                contexto.Entry(us).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Excluir(string n)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                contexto.PP2_Usuario.Remove(BuscaPorNome(n));
                contexto.SaveChanges();
            }
        }

        public  Usuario BuscaPorNome(string nome)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                return contexto.PP2_Usuario.Where(p => p.NomeUsuario == nome).FirstOrDefault();
            }
        }*/
    }
}