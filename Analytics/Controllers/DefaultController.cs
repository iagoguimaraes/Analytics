using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analytics.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {          
            Usuario usuario = (Usuario)Session["usuario"];
            UsuarioDao usuarioDao = new UsuarioDao();
            if (usuario == null || !usuarioDao.Autorizar(usuario.IdUsuario, 1))
                return RedirectToAction("Login");

            return View();
        }

        public ActionResult Login()
        {
            Session["usuario"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Logar(FormCollection form)
        {
            string login = form["login"];
            string senha = form["senha"];

            UsuarioDao usuarioDao = new UsuarioDao();
            Usuario usuario = usuarioDao.Logar(login, senha);
            if (usuario != null)
            {
                Session["usuario"] = usuario;
                return RedirectToAction("Index");
            }
            else
                return View("Login");
        }
    }
}