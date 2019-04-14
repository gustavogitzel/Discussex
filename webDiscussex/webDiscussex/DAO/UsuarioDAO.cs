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

        public void Excluir(string n, string senha)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                Usuario user;
                if((user = BuscaPorNomeSenha(n, senha)) != null)
                {
                    contexto.PP2_Usuario.Remove(user);
                    contexto.SaveChanges();
                }

            }
        }

        public void Alterar(Usuario us)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                contexto.Entry(us).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

       
        public  Usuario BuscaPorNomeSenha(string nome, string senha)
        {
            using (var contexto = new EducacaoSexualContext())
            {

                if (contexto.PP2_Usuario.Where(p => p.NomeUsuario == nome).FirstOrDefault().Senha == senha)
                    return contexto.PP2_Usuario.Where(p => p.NomeUsuario == nome).FirstOrDefault();
                else
                    return null;
            }
        }
    }
}