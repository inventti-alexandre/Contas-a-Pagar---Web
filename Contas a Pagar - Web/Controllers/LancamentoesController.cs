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
    public class LancamentoesController : Controller
    {
        private CAPEntities db = new CAPEntities();

        // GET: Lancamentoes
        public ActionResult Index()
        {
            var lancamento = db.Lancamento.Include(l => l.PlanoContas);
            return View(lancamento.ToList());
        }

        // GET: Lancamentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lancamento lancamento = db.Lancamento.Find(id);
            if (lancamento == null)
            {
                return HttpNotFound();
            }
            return View(lancamento);
        }

        // GET: Lancamentoes/Create
        public ActionResult Create()
        {
            ViewBag.ContaCredito = new SelectList(db.PlanoContas, "Conta", "Descricao");
            return View();
        }

        // POST: Lancamentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Numero,DataLancamento,ContaCredito,Descricao,Valor")] Lancamento lancamento)
        {
            if (ModelState.IsValid)
            {
                db.Lancamento.Add(lancamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContaCredito = new SelectList(db.PlanoContas, "Conta", "Descricao", lancamento.ContaCredito);
            return View(lancamento);
        }

        // GET: Lancamentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lancamento lancamento = db.Lancamento.Find(id);
            if (lancamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContaCredito = new SelectList(db.PlanoContas, "Conta", "Descricao", lancamento.ContaCredito);
            return View(lancamento);
        }

        // POST: Lancamentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Numero,DataLancamento,ContaCredito,Descricao,Valor")] Lancamento lancamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lancamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContaCredito = new SelectList(db.PlanoContas, "Conta", "Descricao", lancamento.ContaCredito);
            return View(lancamento);
        }

        // GET: Lancamentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lancamento lancamento = db.Lancamento.Find(id);
            if (lancamento == null)
            {
                return HttpNotFound();
            }
            return View(lancamento);
        }

        // POST: Lancamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lancamento lancamento = db.Lancamento.Find(id);
            db.Lancamento.Remove(lancamento);
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
