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
            ViewBag.EstaLogado = false;
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.EstaLogado = false;
            return View();
        }

        public ActionResult Configuracoes()
        {
            ViewBag.EstaLogado = true;
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Usuario user)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.Adiciona(user);
            return RedirectToAction("Cadastro", "Usuario");
        }

        public ActionResult Excluir(string email, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.Excluir(email, senha);
            return RedirectToAction("Cadastro", "Usuario");
        }

        public ActionResult AtualizarNome (string nomeUser, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.AlterarNome(nomeUser, ViewBag.Email, senha);
            return RedirectToAction("Cadastro", "Usuario");
        }

        public ActionResult AtualizarSenha(string novaSenha, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.AlterarSenha(novaSenha, ViewBag.Email, senha);
            return RedirectToAction("Cadastro", "Usuario");
        }
        public ActionResult AtualizarEmail(string novoEmail, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.AlterarEmail(novoEmail, ViewBag.Email, senha);
            ViewBag.Email = novoEmail;
            return RedirectToAction("Cadastro", "Usuario");
        }
        public ActionResult AtualizarImagem(string novaFoto, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.AlterarImagem(novaFoto, ViewBag.Email, senha);
            return RedirectToAction("Cadastro", "Usuario");
        }
    }
}