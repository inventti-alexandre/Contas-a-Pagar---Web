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
    public class PagamentoesController : Controller
    {
        private CAPEntities db = new CAPEntities();

        // GET: Pagamentoes
        public ActionResult Index()
        {
            var pagamento = db.Pagamento.Include(p => p.FornecimentoMaterial);
            return View(pagamento.ToList());
        }

        // GET: Pagamentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamento pagamento = db.Pagamento.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            return View(pagamento);
        }

        // GET: Pagamentoes/Create
        public ActionResult Create()
        {
            ViewBag.Fornecimento = new SelectList(db.FornecimentoMaterial, "ID", "ID");
            return View();
        }

        // POST: Pagamentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fornecimento,Valor,DataEmissao")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                db.Pagamento.Add(pagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fornecimento = new SelectList(db.FornecimentoMaterial, "ID", "ID", pagamento.Fornecimento);
            return View(pagamento);
        }

        // GET: Pagamentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamento pagamento = db.Pagamento.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fornecimento = new SelectList(db.FornecimentoMaterial, "ID", "ID", pagamento.Fornecimento);
            return View(pagamento);
        }

        // POST: Pagamentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fornecimento,Valor,DataEmissao")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fornecimento = new SelectList(db.FornecimentoMaterial, "ID", "ID", pagamento.Fornecimento);
            return View(pagamento);
        }

        // GET: Pagamentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamento pagamento = db.Pagamento.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            return View(pagamento);
        }

        // POST: Pagamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pagamento pagamento = db.Pagamento.Find(id);
            db.Pagamento.Remove(pagamento);
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
