using System;
using TesteTDD.Models;
using TesteTDD.DAO;


public class ForumDiscussexController
{
    public static string FazerPergunta(bool anonimo, string emailUsuario, Pergunta p)
    {
        if (emailUsuario == null || anonimo)
            p.CodUsuario = null;
        else
        {
            var user = new UsuarioDAO();
            Usuario usuario = user.BuscaPorEmail(emailUsuario);

            if (usuario == null)
                throw new Exception("Usuario não existe");

            p.CodUsuario = usuario.Id;
        }

        var dao = new PerguntaDAO();

        return dao.Adicionar(p);
    }
}

