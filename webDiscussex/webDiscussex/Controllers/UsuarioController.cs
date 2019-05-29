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
            try
            {
                UsuarioDAO dao = new UsuarioDAO();

                if (upload != null)
                {
                    var uploadPath = Server.MapPath("~/img/imgUsers");
                    string caminhoArquivo = Path.Combine(@uploadPath, user.NomeUsuario + Path.GetExtension(upload.FileName));

                    string[] extensaoPermitida = { ".gif", ".png", ".jpeg", ".jpg" };

                    for (int i = 0; i < extensaoPermitida.Length; i++)
                        if (Path.GetExtension(caminhoArquivo) == extensaoPermitida[i])
                        {
                            upload.SaveAs(caminhoArquivo);
                            user.ImgPerfil = "img/imgUsers/" + user.NomeUsuario + Path.GetExtension(upload.FileName);
                            break;
                        }
                }
                else
                {
                    user.ImgPerfil = "img/UsuarioPadrao.png";
                }

                dao.Adiciona(user);
                Session["emailUsuario"] = user.Email;
                Session["nomeUsuario"] = user.NomeUsuario;
                Session["imgPerfil"] = user.ImgPerfil;
            }
            catch (Exception)
            { }

            return RedirectToAction("Index", "Home");
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
            Usuario user;

            if ((user = dao.BuscaPorNome(Session["nomeUsuario"].ToString())).ImgPerfil != "img/usuarioPadrao.png")
            {
                var imagem = Server.MapPath("~/" + user.ImgPerfil);

                System.IO.File.Delete(imagem);
            }

            dao.Excluir(email, senha);
            Session["emailUsuario"] = null;
            Session["nomeUsuario"] = null;
            Session["imgPerfil"] = null;

            return RedirectToAction("Configuracoes", "Usuario");
        }

        public ActionResult AtualizarNome(string nomeUser, string senha)
        {
            try
            {
                UsuarioDAO dao = new UsuarioDAO();
                Usuario user;
                if ((user = dao.BuscaPorNome(Session["nomeUsuario"].ToString())).ImgPerfil != "img/usuarioPadrao.png")
                {
                    var imagem = Server.MapPath("~/" + user.ImgPerfil);

                    var extensao = Path.GetExtension(imagem);

                    var novoCaminho = imagem.Replace(user.NomeUsuario, nomeUser);

                    System.IO.File.Move(imagem, novoCaminho);

                    user.ImgPerfil = "img/imgUsers/" + nomeUser + extensao;
                    Session["imgPerfil"] = user.ImgPerfil;
                }

                dao.AlterarNome(nomeUser, Session["emailUsuario"].ToString(), senha);

                Session["nomeUsuario"] = nomeUser;
            }
            catch (Exception)
            { }

            return RedirectToAction("Configuracoes", "Usuario");
        }

        public ActionResult AtualizarSenha(string novaSenha, string senha)
        {
            try
            {
                UsuarioDAO dao = new UsuarioDAO();
                dao.AlterarSenha(novaSenha, Session["emailUsuario"].ToString(), senha);

            }
            catch (Exception)
            { }
            return RedirectToAction("Configuracoes", "Uuario");
        }
        public ActionResult AtualizarEmail(string novoEmail, string senha)
        {
            try
            {
                UsuarioDAO dao = new UsuarioDAO();
                dao.AlterarEmail(novoEmail, Session["emailUsuario"].ToString(), senha);

                Session["emailUsuario"] = novoEmail;
            }
            catch (Exception)
            { }
            return RedirectToAction("Configuracoes", "Usuario");
        }
        public ActionResult AtualizarImagem(HttpPostedFileBase upload, string senha)
        {
            try
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
                        user.ImgPerfil = "img/imgUsers/" + user.NomeUsuario + Path.GetExtension(upload.FileName);

                        dao.AlterarImagem(user.ImgPerfil, user.Email, user.Senha);
                        Session["imgPerfil"] = user.ImgPerfil;
                        break;
                    }
            }
            catch (Exception)
            { }

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