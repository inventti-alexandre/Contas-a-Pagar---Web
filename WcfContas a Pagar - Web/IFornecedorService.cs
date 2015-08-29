using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfContas_a_Pagar___Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFornecedorService" in both code and config file together.
    [ServiceContract]
    public interface IFornecedorService
    {
        [OperationContract]
        void Inserir(Fornecedor oFornecedor);
        [OperationContract]
        List<Fornecedor> SelecionarTodos();
    }
}
