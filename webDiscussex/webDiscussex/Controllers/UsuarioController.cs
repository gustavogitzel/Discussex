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
            ViewBag.EhCadastro = true;
            return View();
        }

        public JsonResult ChecarEmailDisponibilidade(string emailDigitado)
        {
            UsuarioDAO dao = new UsuarioDAO();
            var data = dao.BuscaPorEmail(emailDigitado);
            if(data != null)
            {
                return Json(1);
            }

            return Json(0);
        }

        [HttpPost]
        public ActionResult Adiciona(Usuario user)
        {
            UsuarioDAO dao = new UsuarioDAO();
            if (dao.BuscaPorEmail(user.Email) == null)
                return RedirectToAction("Home", "HomePagina");

            dao.Adiciona(user);
            Session["emailUsuario"] = user.Email;
            Session["nomeUsuario"] = user.NomeUsuario;
            Session["imgPerfil"] = user.ImgPerfil;
            return RedirectToAction("Home", "HomePagina");
        }

        public ActionResult Login()
        {
            ViewBag.EhCadastro = false;
            ViewBag.EstaLogado = false;
            return View();
        }

        public ActionResult Configuracoes()
        {
            ViewBag.EhCadastro = true;
            ViewBag.EstaLogado = true;
            return View();
        }

        public ActionResult Excluir(string email, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.Excluir(email, senha);
            Session["emailUsuario"] = null;
            Session["nomeUsuario"] = null;
            Session["imgPerfil"] = null;
            Session["pontos"] = null;
            return RedirectToAction("Configuracoes", "Usuario");
        }

        public ActionResult AtualizarNome(string nomeUser, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.AlterarNome(nomeUser, Session["emailUsuario"].ToString(), senha);

            Session["nomeUsuario"] = nomeUser;

            return RedirectToAction("Configuracoes", "Usuario");
        }

        public ActionResult AtualizarSenha(string novaSenha, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.AlterarSenha(novaSenha, Session["emailUsuario"].ToString(), senha);
            return RedirectToAction("Configuracoes", "Usuario");
        }
        public ActionResult AtualizarEmail(string novoEmail, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.AlterarEmail(novoEmail, Session["emailUsuario"].ToString(), senha);

            Session["emailUsuario"] = novoEmail;

            return RedirectToAction("Configuracoes", "Usuario");
        }
        public ActionResult AtualizarImagem(string novaFoto, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.AlterarImagem(novaFoto, Session["emailUsuario"].ToString(), senha);

            Session["imgPerfil"] = novaFoto;

            return RedirectToAction("Configuracoes", "Usuario");
        }

        public ActionResult Logar(string logar, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario user = dao.Login(logar, senha);
            Session["emailUsuario"] = user.Email;
            Session["nomeUsuario"] = user.NomeUsuario;
            Session["imgPerfil"] = user.ImgPerfil;
            Session["pontos"] = user.Pontuacao;
            return RedirectToAction("Home", "HomePagina");
        }
    }
}