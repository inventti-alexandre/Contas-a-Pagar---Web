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
    public class DespesasController : Controller
    {
        private CAPEntities db = new CAPEntities();

        // GET: Despesas
        public ActionResult Index()
        {
            var despesa = db.Despesa.Include(d => d.Lancamento1).Include(d => d.Pagamento1);
            return View(despesa.ToList());
        }

        // GET: Despesas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despesa despesa = db.Despesa.Find(id);
            if (despesa == null)
            {
                return HttpNotFound();
            }
            return View(despesa);
        }

        // GET: Despesas/Create
        public ActionResult Create()
        {
            ViewBag.Lancamento = new SelectList(db.Lancamento, "Numero", "ContaCredito");
            ViewBag.Pagamento = new SelectList(db.Pagamento, "Fornecimento", "Fornecimento");
            return View();
        }

        // POST: Despesas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Numero,Lancamento,ValorPrevisto,Descricao,Pagamento")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                db.Despesa.Add(despesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Lancamento = new SelectList(db.Lancamento, "Numero", "ContaCredito", despesa.Lancamento);
            ViewBag.Pagamento = new SelectList(db.Pagamento, "Fornecimento", "Fornecimento", despesa.Pagamento);
            return View(despesa);
        }

        // GET: Despesas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despesa despesa = db.Despesa.Find(id);
            if (despesa == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lancamento = new SelectList(db.Lancamento, "Numero", "ContaCredito", despesa.Lancamento);
            ViewBag.Pagamento = new SelectList(db.Pagamento, "Fornecimento", "Fornecimento", despesa.Pagamento);
            return View(despesa);
        }

        // POST: Despesas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Numero,Lancamento,ValorPrevisto,Descricao,Pagamento")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(despesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Lancamento = new SelectList(db.Lancamento, "Numero", "ContaCredito", despesa.Lancamento);
            ViewBag.Pagamento = new SelectList(db.Pagamento, "Fornecimento", "Fornecimento", despesa.Pagamento);
            return View(despesa);
        }

        // GET: Despesas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despesa despesa = db.Despesa.Find(id);
            if (despesa == null)
            {
                return HttpNotFound();
            }
            return View(despesa);
        }

        // POST: Despesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Despesa despesa = db.Despesa.Find(id);
            db.Despesa.Remove(despesa);
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
