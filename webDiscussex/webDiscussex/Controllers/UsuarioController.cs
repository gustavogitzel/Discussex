using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using webDiscussex.Models;
using webDiscussex.DAO;
using System.Web.Mvc;
using System.Drawing;
using Microsoft.Owin.Host.SystemWeb;
using System.Text.RegularExpressions;
using System.Security.Claims;

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

        public JsonResult NomeOuEmailExistente(string digitado)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario data;
            if (digitado.IndexOf("@") == -1)
                data = dao.BuscaPorNome(digitado);
            else
                data = dao.BuscaPorEmail(digitado);

            if (data != null)
                return Json(true);

            return Json(false);
        }

        public JsonResult SenhaCorreta(string digitado)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario data;
            if (digitado.IndexOf("@") == -1)
                data = dao.BuscaPorNome(digitado);
            else
                data = dao.BuscaPorEmail(digitado);

            if (data != null)
                return Json(true);

            return Json(false);
        }

        public JsonResult EmailDisponivel(string digitado)
        {
            UsuarioDAO dao = new UsuarioDAO();
            var data = dao.BuscaPorEmail(digitado);
            if (data != null)
                return Json(false);

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(digitado);

            if (!match.Success)
                return Json(false);
            
            return Json(true);
        }

        public JsonResult NomeDisponivel(string digitado)
        {
            UsuarioDAO dao = new UsuarioDAO();
            var data = dao.BuscaPorNome(digitado);
            if (data != null)
                return Json(false);

            return Json(true);
        }

        public JsonResult SenhaDisponivel(string digitado)
        {
            if (digitado.Length < 8)
                return Json(false);

            return Json(true);
        }

        [HttpPost]
        public ActionResult Adiciona(Usuario user, HttpPostedFileBase upload)
        {
            UsuarioDAO dao = new UsuarioDAO();
            //if (dao.BuscaPorEmail(user.Email) == null)
            //  return RedirectToAction("Home", "HomePagina");

            //if (ModelState.IsValid)
            //{
            if (upload != null)
            {
                string caminhoArquivo = null;
                var uploadPath = Server.MapPath("~/img/imgUsers");
                caminhoArquivo = Path.Combine(@uploadPath, user.NomeUsuario + Path.GetExtension(upload.FileName));

                string[] extensãoPermitida = { ".gif", ".png", ".jpeg", ".jpg" };

                for (int i = 0; i < extensãoPermitida.Length; i++)
                    if (Path.GetExtension(caminhoArquivo) == extensãoPermitida[i])
                    {
                        upload.SaveAs(caminhoArquivo);
                        break;
                    }
                user.ImgPerfil = "img/imgUsers/" + user.NomeUsuario + Path.GetExtension(upload.FileName);
            }
            else
            {
                user.ImgPerfil = "img/UsuarioPadrao.png";
            }
            dao.Adiciona(user);
            Session["emailUsuario"] = user.Email;
            Session["nomeUsuario"] = user.NomeUsuario;
            Session["imgPerfil"] = user.ImgPerfil;

            return RedirectToAction("Index", "Home");
            // }

            //return RedirectToAction("Cadastro", "Usuario");
        }

        public ActionResult Login()
        {
            ViewBag.EhCadastro = false;
            ViewBag.EstaLogado = false;
            return View();
        }

        public void SignIn(string ReturnUrl = "/", string type = "")
        {
            if(!Request.IsAuthenticated)
            {
                if(type == "Google")
                {
                    HttpContext.GetOwinContext().Authentication.Challenge(new Microsoft.Owin.Security.AuthenticationProperties { RedirectUri = "/Usuario/LoginWithGoogle" }, "Google");
                }
            }
        }
        

        public ActionResult LoginWithGoogle()
        {
            var claimsPrincipal = HttpContext.User.Identity as ClaimsIdentity;
            var user = Usuario.GetLoginInfo(claimsPrincipal);
            if (user == null)
                return RedirectToAction("Login", "Usuario");

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Configuracoes()
        {
            ViewBag.EhCadastro = true;
            ViewBag.EstaLogado = true;
            return View();
        }

        public ActionResult SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult Sair()
        {
            Session["emailUsuario"] = null;
            Session["nomeUsuario"] = null;
            Session["imgPerfil"] = null;


            return RedirectToAction("Index", "Home");
        }

        public ActionResult Excluir(string email, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.Excluir(email, senha);
            Session["emailUsuario"] = null;
            Session["nomeUsuario"] = null;
            Session["imgPerfil"] = null;
           
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
        public ActionResult AtualizarImagem(HttpPostedFileBase upload, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();

            Usuario user = new Usuario();

            user = dao.BuscaPorEmail(Session["emailUsuario"].ToString());

            string caminhoArquivo = null;

            var uploadPath = Server.MapPath("~/img/imgUsers");
            caminhoArquivo = Path.Combine(@uploadPath, user.NomeUsuario + Path.GetExtension(upload.FileName));

            string[] extensãoPermitida = { ".gif", ".png", ".jpeg", ".jpg" };

            for (int i = 0; i < extensãoPermitida.Length; i++)
                if (Path.GetExtension(caminhoArquivo) == extensãoPermitida[i])
                {
                    upload.SaveAs(caminhoArquivo);
                    break;
                }

            upload.SaveAs(caminhoArquivo);

            return RedirectToAction("Configuracoes", "Usuario");
        }

        public ActionResult Logar(string logar, string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario user = dao.Login(logar, senha);
            if (user != null)
            {
                Session["emailUsuario"] = user.Email;
                Session["nomeUsuario"] = user.NomeUsuario;
                Session["imgPerfil"] = user.ImgPerfil;
                return RedirectToAction("Index", "Home");
            }

            return View("Login");
        }
        

    }
}