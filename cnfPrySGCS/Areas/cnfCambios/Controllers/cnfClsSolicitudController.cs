using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cnfPrySGCS.Models;

namespace cnfPrySGCS.Areas.cnfCambios.Controllers
{
    public class cnfClsSolicitudController : Controller
    {
        // GET: cnfCambios/cnfSOLpSolicitud
        cnfSOLpSolicitud PobjSolicitud = new cnfSOLpSolicitud();
        cnfMEFpMetodologiaFase MetodologiaFase = new cnfMEFpMetodologiaFase();
        cnfMNTpMetodologiaEntregable Entregable = new cnfMNTpMetodologiaEntregable();
        cnfPECpProyectoElementoConfiguracion ElemConfiguracion = new cnfPECpProyectoElementoConfiguracion();
        cnfPRYpProyecto PRYpProyecto = new cnfPRYpProyecto();
        public ActionResult cnfFrmSolicitud(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                ViewBag.PRYpProyecto = PRYpProyecto.mtdListarProyecto(2);
                ViewBag.MetodologiaFase = MetodologiaFase.mtdCargarDatos();
                ViewBag.Entregable = Entregable.mtdCargarDatosPrincipal();
                //ViewBag.ElementoConfiguracion = ElemConfiguracion.mtdCargarDatosPrincipal();
                ViewBag.Solicitud = PobjSolicitud.Listar();
                return View(PobjSolicitud.Listar());
            }
            else
            {
                return View(PobjSolicitud.buscar(criterio));
            }
        }
        public object mtdBuscar(String LintCodigo)
        {
            return PobjSolicitud.buscar(LintCodigo);
        }
        public void mtdGuardar()
        {
            PobjSolicitud.guardar();
        }
    }
}