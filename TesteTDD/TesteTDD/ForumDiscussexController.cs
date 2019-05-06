using System;
using TesteTDD.Models;
using TesteTDD.DAO;


public class ForumDiscussexController
{
    public static void FazerPergunta(bool anonimo, string emailUsuario, Pergunta p)
    {
        //if (emailUsuario == null || anonimo)
        //    p.CodUsuario = null;
        //else
        //{
        var user = new UsuarioDAO();
        Usuario usuario = user.BuscaPorEmail(emailUsuario);
        p.CodUsuario = usuario.Id;
        //}

        var dao = new PerguntaDAO();

        dao.Adicionar(p);
    }
}

