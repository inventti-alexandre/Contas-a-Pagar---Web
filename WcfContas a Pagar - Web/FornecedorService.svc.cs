using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfContas_a_Pagar___Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FornecedorService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FornecedorService.svc or FornecedorService.svc.cs at the Solution Explorer and start debugging.
    public class FornecedorService : IFornecedorService
    {

        public void Inserir(Fornecedor oFornecedor)
        {
            Fornecedor.Inserir(oFornecedor);
        }

        public List<Fornecedor> SelecionarTodos()
        {
            return Fornecedor.SelecionarTodos();
        }
    }
}
