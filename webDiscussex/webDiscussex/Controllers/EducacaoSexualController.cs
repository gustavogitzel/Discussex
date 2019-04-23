using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webDiscussex.Models;
using webDiscussex.DAO;

namespace webDiscussex.Controllers
{
    public class EducacaoSexualController : Controller
    {
        // GET: EducacaoSexual
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gravidez()
        {
            var dao = new GravidezDAO();

            IList<Gravidez> lista = dao.Lista();

            ViewBag.TabelaGravidez = lista;

            return View();
        }

        public ActionResult Prevencao()
        {            
            return View();
        }

        public ActionResult Corpo()
        {
            var dao = new CorpoDAO();

            IList<Corpo> lista = dao.Lista();

            ViewBag.TabelaCorpo = lista;

            return View();
        }


        public ActionResult HIV()
        {
            return View();
        }

        public ActionResult Infeccoes()
        {
            var dao = new DoencaDAO();

            IList<Doenca> lista = dao.Lista();

            ViewBag.TabelaInfeccoes = lista;

            return View();
        }
    }
}