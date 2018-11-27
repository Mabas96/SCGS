namespace cnfPrySGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("cnfSOLpSolicitud")]
    public partial class cnfSOLpSolicitud
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cnfSOLpSolicitud()
        {
            cnfSCCpSolicitudComiteCambio = new HashSet<cnfSCCpSolicitudComiteCambio>();
            cnfSEVpSolicitudEvaluador = new HashSet<cnfSEVpSolicitudEvaluador>();
            cnfSIApSolicitudInformeAprobacion = new HashSet<cnfSIApSolicitudInformeAprobacion>();
            cnfSICpSolicitudInformeCambio = new HashSet<cnfSICpSolicitudInformeCambio>();
            cnfSMCpSolicitudMiembroCambio = new HashSet<cnfSMCpSolicitudMiembroCambio>();
        }

        [Key]
        public int SOLcodigo { get; set; }

        public int? PRYcodigo { get; set; }

        public int? PECcodigo { get; set; }

        public int? MNTcodigo { get; set; }

        public int? USUcodigo { get; set; }

        [StringLength(250)]
        public string SOLsolicitud { get; set; }

        public int? SOLestado { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SOLfecha_Registro { get; set; }

        [StringLength(250)]
        public string SOLnivel { get; set; }

        public virtual cnfMNTpMetodologiaEntregable cnfMNTpMetodologiaEntregable { get; set; }

        public virtual cnfPECpProyectoElementoConfiguracion cnfPECpProyectoElementoConfiguracion { get; set; }

        public virtual cnfPRYpProyecto cnfPRYpProyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSCCpSolicitudComiteCambio> cnfSCCpSolicitudComiteCambio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSEVpSolicitudEvaluador> cnfSEVpSolicitudEvaluador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSIApSolicitudInformeAprobacion> cnfSIApSolicitudInformeAprobacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSICpSolicitudInformeCambio> cnfSICpSolicitudInformeCambio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnfSMCpSolicitudMiembroCambio> cnfSMCpSolicitudMiembroCambio { get; set; }

        public virtual cnfUSUpUsuario cnfUSUpUsuario { get; set; }
        public List<cnfSOLpSolicitud> Listar()
        {
            var solicitud = new List<cnfSOLpSolicitud>();
            try
            {
                using (var db = new cnfModelo())
                {
                    solicitud = db.cnfSOLpSolicitud.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return solicitud;
        }
        public cnfSOLpSolicitud Obtener(int id)
        {
            var categorias = new cnfSOLpSolicitud();
            try
            {
                using (var db = new cnfModelo())
                {
                    categorias = db.cnfSOLpSolicitud.Where(x => x.SOLcodigo == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return categorias;
        }
        public List<cnfSOLpSolicitud> buscar(string criterio)
        {
            var categorias = new List<cnfSOLpSolicitud>();
            try
            {
                using (var db = new cnfModelo())
                {
                    categorias = db.cnfSOLpSolicitud.Where(x => x.SOLsolicitud.Contains(criterio)).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return categorias;
        }
        public void guardar()
        {
            try
            {
                using (var db = new cnfModelo())
                {
                    if (this.SOLcodigo > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public void eliminar()
        {
            try
            {
                using (var db = new cnfModelo())
                {

                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        //public class cnfSOLpSolicitudes
        //{
        //    public int SOLcodigo { get; set; }

        //    public int? PRYcodigo { get; set; }

        //    public int? PECcodigo { get; set; }

        //    public int? MNTcodigo { get; set; }

        //    public int? USUcodigo { get; set; }

        //    [StringLength(250)]
        //    public string SOLsolicitud { get; set; }

        //    public int? SOLestado { get; set; }

        //    [Column(TypeName = "date")]
        //    public DateTime? SOLfecha_Registro { get; set; }

        //    [StringLength(250)]
        //    public string SOLnivel { get; set; }
        //}

    }
}
