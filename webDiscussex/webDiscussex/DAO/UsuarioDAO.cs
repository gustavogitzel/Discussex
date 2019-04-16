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
                if (BuscaPorNome(us.NomeUsuario) == null)
                {
                    contexto.PP2_Usuario.Add(us);
                    contexto.SaveChanges();
                }
                else
                    throw  new Exception("Nome inválido");
            }
        }

        public void Excluir(string e, string senha)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                Usuario user;
                if((user = BuscaPorEmailSenha(e, senha)) != null)
                {
                    contexto.PP2_Usuario.Remove(user);
                    contexto.SaveChanges();
                }
            }
        }

        public void AlterarNome(string n, string e, string s)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                Usuario user;
                if ((user = BuscaPorEmailSenha(e, s)) != null)
                {
                    user.NomeUsuario = n;
                    contexto.Update(user);
                    contexto.SaveChanges();
                }
                else
                    throw new Exception("Senha Inválida");
            }
        }

        public void AlterarEmail(string ne, string e, string s)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                Usuario user;
                if ((user = BuscaPorEmailSenha(e, s)) != null)
                {
                    user.Email = ne;
                    contexto.Update(user);
                    contexto.SaveChanges();
                }
                else
                    throw new Exception("Senha Inválida");
            }
        }

        public void AlterarSenha(string ns, string e, string s)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                Usuario user;
                if ((user = BuscaPorEmailSenha(e, s)) != null)
                {
                    user.Senha = ns;
                    contexto.Update(user);
                    contexto.SaveChanges();
                }
                else
                    throw new Exception("Senha Inválida");
            }
        }

        public void AlterarImagem(string ni, string e, string s)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                Usuario user;
                if ((user = BuscaPorEmailSenha(e, s)) != null)
                {
                    user.ImgPerfil = ni;
                    contexto.Update(user);
                    contexto.SaveChanges();
                }
                else
                    throw new Exception("Senha Inválida");
            }
        }

        public Usuario BuscaPorEmailSenha(string email, string senha)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                var user = contexto.PP2_Usuario.Where(p => p.Email == email).FirstOrDefault();
                if (user != null && user.Senha == senha)
                    return user;

                return null;
            }
        }

        public Usuario BuscaPorNome(string nome)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                return contexto.PP2_Usuario.Where(p => p.NomeUsuario == nome).FirstOrDefault();
            }
        }
    }
}