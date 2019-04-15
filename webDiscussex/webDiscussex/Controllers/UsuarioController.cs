using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webDiscussex.Models;
using webDiscussex.DAO;
using System.Web.Mvc;

namespace webDiscussex.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Configuracoes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Usuario user)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.Adiciona(user);
            return RedirectToAction("Cadastro", "Usuario");
        }

        public ActionResult Excluir(string nomeUser, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.Excluir(nomeUser, senha);
            return RedirectToAction("Cadastro", "Usuario");
        }

        public ActionResult AtualizarSenha(Usuario user)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.Alterar(user);
            return RedirectToAction("Cadastro", "Aluno");
        }
    }
}