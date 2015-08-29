using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WcfContas_a_Pagar___Web
{
    
    public partial class Fornecedor
    {
        public static void Inserir(Fornecedor oFornecedor)
        {
            using (var oDB = new CAPEntities())
            {
                oDB.Fornecedor.Add(oFornecedor);
                oDB.SaveChanges();
            }
        }
        public static void Alterar(Fornecedor oFornecedor)
        {
            using (var oDB = new CAPEntities())
            {
                oDB.Fornecedor.Attach(oFornecedor);
                oDB.Entry(oFornecedor).State = EntityState.Modified;
                oDB.SaveChanges();
            }
        }
        public static void Excluir(int ID)
        {
            using (var oDB = new CAPEntities())
            {
                var oFornecedor = oDB.Fornecedor.Find(ID);
                oDB.Fornecedor.Attach(oFornecedor);
                oDB.Fornecedor.Remove(oFornecedor);
                oDB.SaveChanges();
            }
        }
        
        public static List<Fornecedor> SelecionarTodos()
        {
            using (var oDB = new CAPEntities())
            {
                return oDB.Fornecedor.ToList();
            }
        }
    }
}
