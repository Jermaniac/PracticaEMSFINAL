using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppGestionEMS.Controllers
{
    [Authorize(Roles = "profesor,admin")]
    public class MenuProfesoresController : Controller
    {
        // GET: MenuProfesores
        public ActionResult Index()
        {
            return View();
        }
    }
}