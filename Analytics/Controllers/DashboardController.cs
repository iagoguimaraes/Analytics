using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analytics.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Mktzap()
        {
            Usuario usuario = (Usuario)Session["usuario"];
            UsuarioDao usuarioDao = new UsuarioDao();
            if (usuario == null || !usuarioDao.Autorizar(usuario.IdUsuario, 2))
                return RedirectToAction("../Default/Login");

            return View();
        }


    }
}