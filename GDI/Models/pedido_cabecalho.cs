//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GDI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pedido_cabecalho
    {
        public pedido_cabecalho()
        {
            this.pedido_itens = new HashSet<pedido_itens>();
        }
    
        public int idpedido_cabecalho { get; set; }
        public int idcliente { get; set; }
        public Nullable<decimal> valor_total_pedido { get; set; }
        public Nullable<int> qtde_itens { get; set; }
        public string status_pedido { get; set; }
        public Nullable<System.DateTime> data_pedido { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual ICollection<pedido_itens> pedido_itens { get; set; }
    }
}