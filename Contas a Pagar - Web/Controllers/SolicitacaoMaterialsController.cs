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
    public class SolicitacaoMaterialsController : Controller
    {
        private CAPEntities db = new CAPEntities();

        // GET: SolicitacaoMaterials
        public ActionResult Index()
        {
            var solicitacaoMaterial = db.SolicitacaoMaterial.Include(s => s.Setor1);
            return View(solicitacaoMaterial.ToList());
        }
        public ActionResult NaoAprovados()
        {
            var solicitacaoMaterial = db.SolicitacaoMaterial.Include(s => s.Setor1).Where(f => f.Aprovado == false);
            return View(solicitacaoMaterial.ToList());
        }
        // GET: SolicitacaoMaterials/Details/5
        public ActionResult Details(int? id)
        {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                SolicitacaoMaterial solicitacaoMaterial = db.SolicitacaoMaterial.Find(id);
            var c = new NumSolViewModel();
            c.ListaSolicitacoes = new List<TodasSolicitacoes_Result>();
            c.ListaDetalhesSolicitacoes = new List<DetalhesSolicitacao_Result>();
            foreach (var item in db.DetalhesSolicitacao(solicitacaoMaterial.ID))
            {
                c.ListaDetalhesSolicitacoes.Add(item);
            }
                return View(solicitacaoMaterial);
            
        }
        public ActionResult Detalhes(int? id)
        {
            var c = new NumSolViewModel();
            c.ListaDetalhesSolicitacoes = new List<DetalhesSolicitacao_Result>();
            foreach (var item in db.DetalhesSolicitacao(id))
            {
                c.ListaDetalhesSolicitacoes.Add(item);
            }
            return View(c);
        }
        private List<Material> CarregarMateriais()
        {
            List<Material> materiais = new List<Material>();
            materiais = db.Material.ToList();
            return materiais;
        }
        public ActionResult Aprovar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitacaoMaterial solicitacaoMaterial = db.SolicitacaoMaterial.Find(id);
            if (solicitacaoMaterial == null)
            {
                return HttpNotFound();
            }
            return View(solicitacaoMaterial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Aprovar([Bind(Include = "Setor,ID,Data,Aprovado")] SolicitacaoMaterial solicitacaoMaterial)
        {
            if (ModelState.IsValid)
            {
                var a = db.SolicitacaoMaterial.Find(solicitacaoMaterial.ID);
                a.Aprovado = solicitacaoMaterial.Aprovado;
                db.SolicitacaoMaterial.Attach(a);
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("NaoAprovados");
            }
            ViewBag.Setor = new SelectList(db.Setor, "ID", "Descricao");
            ViewBag.Material = new MultiSelectList(CarregarMateriais(), "ID", "Descricao");
            return View(solicitacaoMaterial);
        }
        // GET: SolicitacaoMaterials/Create
        public ActionResult Create()
        {
            ViewBag.Setor = new SelectList(db.Setor, "ID", "Descricao");
            ViewBag.Material = new MultiSelectList(CarregarMateriais(), "ID", "Descricao");
            return View();
        }

        // POST: SolicitacaoMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Setor,ID,Data,Aprovado")] SolicitacaoMaterial oSolicitacaoMaterial, int[] Material)
        {
            if (ModelState.IsValid)
            {
                db.RealizarSolicitacao(oSolicitacaoMaterial.Setor, DateTime.Now, false);
                foreach (var item in Material)
                {
                    db.ItensSolicitacaoRealizada(item);
                }
                //db.SolicitacaoMaterial.Add(solicitacaoMaterial);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Setor = new SelectList(db.Setor, "ID", "Descricao", oSolicitacaoMaterial.Setor);
            ViewBag.Material = new MultiSelectList(CarregarMateriais(), "ID", "Descricao");
            return View(oSolicitacaoMaterial);
        }

        // GET: SolicitacaoMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitacaoMaterial solicitacaoMaterial = db.SolicitacaoMaterial.Find(id);
            if (solicitacaoMaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.Setor = new SelectList(db.Setor, "ID", "Descricao", solicitacaoMaterial.Setor);
            return View(solicitacaoMaterial);
        }

        // POST: SolicitacaoMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Setor,ID,Data,Aprovado")] SolicitacaoMaterial solicitacaoMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitacaoMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Setor = new SelectList(db.Setor, "ID", "Descricao", solicitacaoMaterial.Setor);
            return View(solicitacaoMaterial);
        }

        // GET: SolicitacaoMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitacaoMaterial solicitacaoMaterial = db.SolicitacaoMaterial.Find(id);
            if (solicitacaoMaterial == null)
            {
                return HttpNotFound();
            }
            return View(solicitacaoMaterial);
        }

        // POST: SolicitacaoMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitacaoMaterial solicitacaoMaterial = db.SolicitacaoMaterial.Find(id);
            db.SolicitacaoMaterial.Remove(solicitacaoMaterial);
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
