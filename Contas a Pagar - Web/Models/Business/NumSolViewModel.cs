using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contas_a_Pagar___Web.Models
{
    public class NumSolViewModel
    {
        public List<TodasSolicitacoes_Result> ListaSolicitacoes { get; set; }
        public List<DetalhesSolicitacao_Result> ListaDetalhesSolicitacoes { get; set; }
    }
}
