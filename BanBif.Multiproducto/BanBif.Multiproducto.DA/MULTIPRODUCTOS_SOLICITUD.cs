//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BanBif.Multiproducto.DA
{
    using System;
    using System.Collections.Generic;
    
    public partial class MULTIPRODUCTOS_SOLICITUD
    {
        public int registroid { get; set; }
        public Nullable<int> productoid { get; set; }
        public Nullable<int> clienteid { get; set; }
        public Nullable<System.DateTime> fecsol { get; set; }
        public string ipcliente { get; set; }
        public Nullable<int> estado { get; set; }
    
        public virtual MULTIPRODUCTOS_PRODUCTO MULTIPRODUCTOS_PRODUCTO { get; set; }
        public virtual MULTIPRODUCTOS_CLIENTE MULTIPRODUCTOS_CLIENTE { get; set; }
    }
}
