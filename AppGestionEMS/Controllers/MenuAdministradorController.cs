using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppGestionEMS.Controllers
{
    [Authorize(Roles = "admin")]

    public class MenuAdministradorController : Controller
    {
        // GET: MenuAdministrador
        public ActionResult Index()
        {
            return View();
        }
    }
}