using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Contas_a_Pagar___Web.Models
{
    public class FornecimentoMaterialViewModel
    {
        public FornecimentoMaterial FornecimentoMaterial { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public Material Material { get; set; }
        public Pagamento Pagamento { get; set; }
        public int Servico { get; set; }
        public Nullable<bool> Cancelado { get; set; }
        public System.DateTime Data { get; set; }
        public List<int> MateriaisIDs { get; set; }
        public List<Fornecedor> Fornecedores { get; set; }
        public List<Material> Materiais { get; set; }
        public IEnumerable<MultiSelectList> TodosMateriais { get; set; }
    }
}
