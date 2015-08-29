using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contas_a_Pagar___Web.Models;

namespace Contas_a_Pagar___Web.Controllers
{
    public class FornecimentoMaterialsController : Controller
    {
        private CAPEntities db = new CAPEntities();

        // GET: FornecimentoMaterials
        public ActionResult Index()
        {
            var fornecimentoMaterial = db.FornecimentoMaterial.Include(f => f.Fornecedor1).Include(f => f.Pagamento);
            return View(fornecimentoMaterial.ToList());
        }
        public ActionResult NaoCancelados()
        {
            var fornecimentoMaterial = db.FornecimentoMaterial.Include(f => f.Fornecedor1).Include(f => f.Pagamento).Where(f=>f.Cancelado==false);
            return View(fornecimentoMaterial.ToList());
        }
        // GET: FornecimentoMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecimentoMaterial fornecimentoMaterial = db.FornecimentoMaterial.Find(id);
            var a = db.DetalhesFornecimento(fornecimentoMaterial.ID);
            if (fornecimentoMaterial == null)
            {
                return HttpNotFound();
            }
            return View(fornecimentoMaterial);
        }
        private List<Material> CarregarMateriais()
        {
            List<Material> materiais = new List<Material>();
            materiais = db.Material.ToList();
            return materiais;
        }
        // GET: FornecimentoMaterials/Create
        public ActionResult Create()
        {
            ViewBag.Fornecedor = new SelectList(db.Fornecedor.ToList(), "ID", "RazaoSocial");
            ViewBag.ID = new SelectList(db.Pagamento, "Fornecimento", "Fornecimento");
            ViewBag.Material = new MultiSelectList(CarregarMateriais(), "ID", "Descricao");
            return View();
        }
        public ActionResult Cancelar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecimentoMaterial fornecimentoMaterial = db.FornecimentoMaterial.Find(id);
            var a = db.DetalhesFornecimento(fornecimentoMaterial.ID);
            if (fornecimentoMaterial == null)
            {
                return HttpNotFound();
            }
            return View(fornecimentoMaterial);
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancelar([Bind(Include = "Fornecedor,Servico,Data,ID,Cancelado,Material")] FornecimentoMaterial fornecimentoMaterial)
        {
            if (ModelState.IsValid)
            {
                var a = db.FornecimentoMaterial.Find(fornecimentoMaterial.ID);
                a.Cancelado = fornecimentoMaterial.Cancelado;
                db.FornecimentoMaterial.Attach(a);
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("NaoCancelados");
            }
            ViewBag.Fornecedor = new SelectList(db.Fornecedor, "ID", "RazaoSocial", fornecimentoMaterial.Fornecedor);
            ViewBag.ID = new SelectList(db.Pagamento, "Fornecimento", "Fornecimento", fornecimentoMaterial.ID);
            return View(fornecimentoMaterial);
        }
        // POST: FornecimentoMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fornecedor,Servico,Data,ID,Cancelado")] FornecimentoMaterial fornecimentoMaterial, int[] Material)
        {
            if (ModelState.IsValid)
            {
                db.RealizarFornecimento(fornecimentoMaterial.Fornecedor, fornecimentoMaterial.Servico, DateTime.Now);
                foreach (var item in Material)
                {
                    db.ItensFornecimentoRealizado(item);
                }
                return RedirectToAction("Index");
            }
            ViewBag.Fornecedor = new SelectList(db.Fornecedor.ToList(), "ID", "RazaoSocial");
            ViewBag.ID = new SelectList(db.Pagamento, "Fornecimento", "Fornecimento");
            ViewBag.Material = new MultiSelectList(CarregarMateriais(), "ID", "Descricao");
            return View();
        }

        // GET: FornecimentoMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecimentoMaterial fornecimentoMaterial = db.FornecimentoMaterial.Find(id);
            if (fornecimentoMaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fornecedor = new SelectList(db.Fornecedor, "ID", "RazaoSocial", fornecimentoMaterial.Fornecedor);
            ViewBag.ID = new SelectList(db.Pagamento, "Fornecimento", "Fornecimento", fornecimentoMaterial.ID);
            return View(fornecimentoMaterial);
        }

        // POST: FornecimentoMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fornecedor,Servico,Data,ID,Cancelado,Material")] FornecimentoMaterial fornecimentoMaterial)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(fornecimentoMaterial).State = EntityState.Modified;
                //db.SaveChanges();
                var a = fornecimentoMaterial.Material;
                db.RealizarFornecimento(fornecimentoMaterial.Fornecedor, fornecimentoMaterial.Servico, fornecimentoMaterial.Data);
                foreach (var item in fornecimentoMaterial.Material)
                {
                    db.ItensFornecimentoRealizado(item.ID);
                }
                return RedirectToAction("Index");
            }
            ViewBag.Fornecedor = new SelectList(db.Fornecedor, "ID", "RazaoSocial", fornecimentoMaterial.Fornecedor);
            ViewBag.ID = new SelectList(db.Pagamento, "Fornecimento", "Fornecimento", fornecimentoMaterial.ID);
            return View(fornecimentoMaterial);
        }

        // GET: FornecimentoMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecimentoMaterial fornecimentoMaterial = db.FornecimentoMaterial.Find(id);
            if (fornecimentoMaterial == null)
            {
                return HttpNotFound();
            }
            return View(fornecimentoMaterial);
        }

        // POST: FornecimentoMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FornecimentoMaterial fornecimentoMaterial = db.FornecimentoMaterial.Find(id);
            db.FornecimentoMaterial.Remove(fornecimentoMaterial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
