using System;
using System.Collections.Generic;
using System.Linq;
using webDiscussex.Models;
using webDiscussex.DAO;
using System.Web;
using System.Web.Mvc;

namespace webDiscussex.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomePagina
        public ActionResult Index()
        {
            var dao = new EducacaoSexuaDAO();

            IList<EducacaoSexual> lista = dao.Lista();

            ViewBag.Temas = lista;

            if (lista.Count() % 2 == 0)
                ViewBag.ParOuImpar = "par";
            else
                ViewBag.ParOuImpar = "impar";

            return View();
        }
    }
}