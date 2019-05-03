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

            return RedirectToAction("Respostas", "ForumDiscussex", new { id = p.Id });
        }

        [Route("ForumDiscussex/Respostas/{id}")]
        public ActionResult Respostas(string id)
        {
            var dao = new PerguntaDAO();

            ViewBag.Pergunta = dao.BuscaPorId(int.Parse(id));

            if (ViewBag.Pergunta.CodUsuario != null)
            {
                var perguntador = new UsuarioDAO();
                ViewBag.UsuarioPerguntador = perguntador.BuscaPorId((int)ViewBag.Pergunta.CodUsuario);
            }

            var daoRespostas = new RespostaDAO();

            ViewBag.ListaRespostas = daoRespostas.BuscaPorPergunta(ViewBag.Pergunta.Id);

            IList<Usuario> user = new List<Usuario>();
            foreach(var resposta in ViewBag.ListaRespostas)
            {
                var respondedor = new UsuarioDAO();
                user.Add((Usuario)respondedor.BuscaPorId(resposta.CodUsuario));
            }

            ViewBag.ListaRespondedor = user;

            return View();
        }
        [Route("ForumDiscussex/responder/ {id}")]
        public ActionResult Responder(string id)
        {
            var dao = new PerguntaDAO();

            ViewBag.Pergunta = dao.BuscaPorId(int.Parse(id));

            return View();
        }

        public ActionResult AdicionarResposta(string resp, string id)
        {
            var resposta = new TResposta();

            var user = new UsuarioDAO();
            resposta.CodUsuario = user.BuscaPorEmail(Session["emailUsuario"].ToString()).Id;

            return RedirectToAction("Responder", "ForumDiscussex");
        }
    }
}