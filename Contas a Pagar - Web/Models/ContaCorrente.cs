//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Contas_a_Pagar___Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContaCorrente
    {
        public string Conta { get; set; }
        public int Agencia { get; set; }
        public decimal Limite { get; set; }
    
        public virtual Agencia Agencia1 { get; set; }
        public virtual PlanoContas PlanoContas { get; set; }
    }
}
