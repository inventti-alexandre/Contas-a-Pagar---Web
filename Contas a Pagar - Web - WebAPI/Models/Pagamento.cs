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
    
    public partial class Pagamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pagamento()
        {
            this.Despesa = new HashSet<Despesa>();
        }
    
        public int Fornecimento { get; set; }
        public decimal Valor { get; set; }
        public System.DateTime DataEmissao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Despesa> Despesa { get; set; }
        public virtual FornecimentoMaterial FornecimentoMaterial { get; set; }
    }
}
