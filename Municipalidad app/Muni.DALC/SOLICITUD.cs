//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Muni.DALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class SOLICITUD
    {
        public SOLICITUD()
        {
            this.PERMISO = new HashSet<PERMISO>();
        }
    
        public decimal ID_SOLICITUD { get; set; }
        public System.DateTime FECHA_INICIO { get; set; }
        public System.DateTime FECHA_FIN { get; set; }
        public decimal ID_TIPO_PERMISO { get; set; }
        public string RUT { get; set; }
    
        public virtual FUNCIONARIO FUNCIONARIO { get; set; }
        public virtual ICollection<PERMISO> PERMISO { get; set; }
        public virtual TIPO_PERMISO TIPO_PERMISO { get; set; }
    }
}
