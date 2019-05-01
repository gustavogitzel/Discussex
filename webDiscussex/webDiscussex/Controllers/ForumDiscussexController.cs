using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webDiscussex.DAO;
using webDiscussex.Models;

namespace webDiscussex.Controllers
{
    public class ForumDiscussexController : Controller
    {
        // GET: ForumDiscussex
        public ActionResult Index()
        {
            var dao = new PerguntaDAO();

            IList<Pergunta> lista = dao.Lista();

            ViewBag.ListaPerguntas = lista;

            return View();
        }

        public ActionResult Perguntar()
        {
            return View();
        }

        public ActionResult Responder()
        {
            var dao = new PerguntaDAO();

            IList<Pergunta> lista = dao.Lista();

            ViewBag.ListaPerguntas = lista;

            return View();
        }

        public ActionResult BuscarTemas(string busca)
        {
            var dao = new PerguntaDAO();

            IList<Pergunta> lista = dao.BuscaPorPalavraChave(busca);

            Session["palavraChave"] = lista;

            return RedirectToAction("Index", "ForumDiscussex");
        }

        public ActionResult FazerPergunta(Pergunta p, bool anonimo)
        {
            if (Session["emailUsuario"] == null || anonimo)
                p.CodUsuario = null;
            else
            {
                var user = new UsuarioDAO();
                Usuario usuario = user.BuscaPorEmail(Session["emailUsuario"].ToString());
                p.CodUsuario = usuario.Id;
            }

            var dao = new PerguntaDAO();

            dao.Adicionar(p);

            return RedirectToAction("Responder", "ForumDiscussex");
        }
    }
}