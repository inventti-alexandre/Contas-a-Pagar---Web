//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Contas_a_Pagar___Web___WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Auditoria
    {
        public int ID { get; set; }
        public string Evento { get; set; }
        public string Usuario { get; set; }
        public System.DateTime DataHora { get; set; }
        public string Descricao { get; set; }
    
        public virtual Evento Evento1 { get; set; }
    }
}
