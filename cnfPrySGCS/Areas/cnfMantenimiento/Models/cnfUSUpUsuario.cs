namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Web;

    [Table("cnfUSUpUsuario")]
    public partial class cnfUSUpUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cnfUSUpUsuario()
        {
            cnfPMIpProyectoMiembro = new HashSet<cnfPMIpProyectoMiembro>();
            cnfPRYpProyecto = new HashSet<cnfPRYpProyecto>();
            cnfSOLpSolicitud = new HashSet<cnfSOLpSolicitud>();
        }

        [Key]
        public int USUcodigo { get; set; }

        [StringLength(8)]
        public string USUdni { get; set; }

        [StringLength(250)]
        public string USUnombre { get; set; }

        [StringLength(250)]
        public string USUapellido { get; set; }

        [StringLength(250)]
        public string USUcorreo { get; set; }

        [StringLength(10)]
        public string USUtelefono { get; set; }

        [StringLength(8)]
        public string USUusuario { get; set; }

        [StringLength(8)]
        public string USUcontrasena { get; set; }

        [StringLength(20)]
        public string USUnivel { get; set; }

        [StringLength(20)]
        public string USUestado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfPMIpProyectoMiembro> cnfPMIpProyectoMiembro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfPRYpProyecto> cnfPRYpProyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSOLpSolicitud> cnfSOLpSolicitud { get; set; }

        /*----------------------------------------*/
        public List<cnfUSUpUsuario> mtdCargarDatos()
        {
            List<cnfUSUpUsuario> LlstLista = new List<cnfUSUpUsuario>();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfUSUpUsuario>("exec usp_S_cnfUSUpUsuario_CargarDatos").ToList();
                LlstLista = LobjQuery;
            }

            return LlstLista;
        }

        public cnfUSUpUsuario mtdBuscar(int LintParametro)
        {
            cnfUSUpUsuario LobjUsuario = new cnfUSUpUsuario();

            using (var LobjContexto = new cnfModelo())
            {
                var LobjQuery = LobjContexto.Database.SqlQuery<cnfUSUpUsuario>("exec usp_S_cnfUSUpUsuario_Buscar " + LintParametro).Single();
                LobjUsuario = LobjQuery;
            }

            return LobjUsuario;
        }


        public string mtdGuardar(cnfUSUpUsuario LobjUsuario)
        {
            int LintMensajeRespuesta = -1;
            try
            {
                using (var LobjContexto = new cnfModelo())
                {


                    if (LobjUsuario.USUcodigo == 0)
                    {
                        LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_I_cnfUSUpUsuario_Guardar " + "'" + LobjUsuario.USUdni + "','" + LobjUsuario.USUnombre + "','" + LobjUsuario.USUapellido + "','" + LobjUsuario.USUcorreo + "','" + LobjUsuario.USUtelefono + "','" + LobjUsuario.USUusuario + "', '" + LobjUsuario.USUcontrasena + "', '" + LobjUsuario.USUnivel + "','" + LobjUsuario.USUestado + "';");
                    }
                }
            }
            catch (Exception)
            {

            }
            return mtdRespuestaMensaje(LintMensajeRespuesta);
        }

        public string mtdModificar(cnfUSUpUsuario LobjUsuario)
        {
            int LintMensajeRespuesta = -1;
            try
            {
                using (var LobjContexto = new cnfModelo())
                {


                    if (LobjUsuario.USUcodigo != 0)
                    {
                        LintMensajeRespuesta = LobjContexto.Database.ExecuteSqlCommand("exec usp_U_cnfUSUpUsuario_Modificar " + "'" + LobjUsuario.USUcodigo + "','" + LobjUsuario.USUdni + "','" + LobjUsuario.USUnombre + "','" + LobjUsuario.USUapellido + "','" + LobjUsuario.USUcorreo + "','" + LobjUsuario.USUtelefono + "','" + LobjUsuario.USUusuario + "', '" + LobjUsuario.USUcontrasena + "', '" + LobjUsuario.USUnivel + "','" + LobjUsuario.USUestado + "';");
                    }
                }
            }
            catch (Exception)
            {

            }
            return mtdRespuestaMensaje(LintMensajeRespuesta);
        }

        public string mtdRespuestaMensaje(int LintMensajeRespuesta)
        {
            string LstrMensajeRespuesta = "";
            if (LintMensajeRespuesta > 0)
            {
                LstrMensajeRespuesta = "Correcto";
            }
            else
            {
                LstrMensajeRespuesta = "Incorrecto";
            }
            return LstrMensajeRespuesta;
        }



        //INICIAR SESION
        public string mtdSeguridad(string LstrUsuario, string LstrPassword)
        {
            cnfUSUpUsuario LobjUsuario = new cnfUSUpUsuario();
            string LstrMensaje = "";
            try
            {
                using (var LobjContexto = new cnfModelo())
                {
                    LobjUsuario = LobjContexto.Database.SqlQuery<cnfUSUpUsuario>("exec usp_S_cnfUSUpUsuario_IniciarSesion " + "'" + LstrUsuario + "', '" + LstrPassword + "';").Single();

                    if(LobjUsuario != null)
                    {
                        if(LobjUsuario.USUestado.Equals("Activo"))
                        {
                            HttpContext.Current.Session["GintCodigoUsuario"] = LobjUsuario.USUcodigo;
                            LstrMensaje = "Bienvenido";
                        }
                        else
                        {
                            LstrMensaje = "Inactivo";
                        }
                    }
                    else
                    {
                        LstrMensaje = "Usuario o contrase�a incorrecta";
                        if(Convert.ToInt32(HttpContext.Current.Session["GintContadorLogin"]) == 3)
                        {
                            LobjContexto.Database.ExecuteSqlCommand("exec usp_U_cnfUSUpUsuario_IniciarSesion " + "'" + LobjUsuario.USUcodigo + "','" + LobjUsuario.USUdni + "','" + LobjUsuario.USUnombre + "','" + LobjUsuario.USUapellido + "','" + LobjUsuario.USUcorreo + "','" + LobjUsuario.USUtelefono + "','" + LobjUsuario.USUusuario + "', '" + LobjUsuario.USUcontrasena + "', '" + LobjUsuario.USUnivel + "','" + LobjUsuario.USUestado + "';");
                            LstrMensaje = "Usuario bloqueado, contacte al administrador";
                        }
                        try
                        {
                            HttpContext.Current.Session["GintContadorLogin"] = 0;
                            HttpContext.Current.Session["GintContadorLogin"] = Convert.ToInt32(HttpContext.Current.Session["GintContadorLogin"]) + 1;
                        }
                        catch
                        {
                            HttpContext.Current.Session["GintContadorLogin"] = Convert.ToInt32(HttpContext.Current.Session["GintContadorLogin"]) + 1;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return LstrMensaje;
        }
     
    }
}
