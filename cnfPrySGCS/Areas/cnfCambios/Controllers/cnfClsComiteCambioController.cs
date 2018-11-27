using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cnfPrySGCS.Models;

namespace cnfPrySGCS.Areas.cnfCambios.Controllers
{
    
    public class cnfClsComiteCambioController : Controller
    {
        cnfUSUpUsuario USUpMiembro = new cnfUSUpUsuario();
        // GET: cnfCambios/cnfClsComiteCambio
        public ActionResult cnfFrmComite(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                ViewBag.USUpProyecto = USUpMiembro.mtdCargarDatos();                                            
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}