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
    
    public partial class SolicitacoesMateriais
    {
        public int SolicitacaoID { get; set; }
        public System.DateTime Data { get; set; }
        public string Material { get; set; }
        public int MaterialID { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int SetorID { get; set; }
        public string Setor { get; set; }
    }
}