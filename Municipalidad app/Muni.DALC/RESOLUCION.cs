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
    
    public partial class RESOLUCION
    {
        public decimal ID_RESOLUCION { get; set; }
        public string DETALLE { get; set; }
        public decimal CORRELATIVO { get; set; }
        public decimal ID_PERMISO { get; set; }
        public string RUT { get; set; }
    
        public virtual FUNCIONARIO FUNCIONARIO { get; set; }
        public virtual PERMISO PERMISO { get; set; }
    }
}