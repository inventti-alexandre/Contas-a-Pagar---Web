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
    
    public partial class Despesa
    {
        public int Numero { get; set; }
        public int Lancamento { get; set; }
        public decimal ValorPrevisto { get; set; }
        public string Descricao { get; set; }
        public int Pagamento { get; set; }
    
        public virtual Lancamento Lancamento1 { get; set; }
        public virtual Pagamento Pagamento1 { get; set; }
    }
}
