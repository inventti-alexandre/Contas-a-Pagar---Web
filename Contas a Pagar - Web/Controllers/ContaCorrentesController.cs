using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contas_a_Pagar___Web.Models;

namespace Contas_a_Pagar___Web.Controllers
{
    public class ContaCorrentesController : Controller
    {
        private CAPEntities db = new CAPEntities();

        // GET: ContaCorrentes
        public async Task<ActionResult> Index()
        {
            var contaCorrente = db.ContaCorrente.Include(c => c.Agencia1).Include(c => c.PlanoContas);
            return View(await contaCorrente.ToListAsync());
        }

        // GET: ContaCorrentes/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaCorrente contaCorrente = await db.ContaCorrente.FindAsync(id);
            if (contaCorrente == null)
            {
                return HttpNotFound();
            }
            return View(contaCorrente);
        }

        // GET: ContaCorrentes/Create
        public ActionResult Create()
        {
            ViewBag.Agencia = new SelectList(db.Agencia, "ID", "Endereco");
            ViewBag.Conta = new SelectList(db.PlanoContas, "Conta", "Descricao");
            return View();
        }

        // POST: ContaCorrentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Conta,Agencia,Limite")] ContaCorrente contaCorrente)
        {
            if (ModelState.IsValid)
            {
                db.ContaCorrente.Add(contaCorrente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Agencia = new SelectList(db.Agencia, "ID", "Endereco", contaCorrente.Agencia);
            ViewBag.Conta = new SelectList(db.PlanoContas, "Conta", "Descricao", contaCorrente.Conta);
            return View(contaCorrente);
        }

        // GET: ContaCorrentes/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaCorrente contaCorrente = await db.ContaCorrente.FindAsync(id);
            if (contaCorrente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Agencia = new SelectList(db.Agencia, "ID", "Endereco", contaCorrente.Agencia);
            ViewBag.Conta = new SelectList(db.PlanoContas, "Conta", "Descricao", contaCorrente.Conta);
            return View(contaCorrente);
        }

        // POST: ContaCorrentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Conta,Agencia,Limite")] ContaCorrente contaCorrente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contaCorrente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Agencia = new SelectList(db.Agencia, "ID", "Endereco", contaCorrente.Agencia);
            ViewBag.Conta = new SelectList(db.PlanoContas, "Conta", "Descricao", contaCorrente.Conta);
            return View(contaCorrente);
        }

        // GET: ContaCorrentes/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaCorrente contaCorrente = await db.ContaCorrente.FindAsync(id);
            if (contaCorrente == null)
            {
                return HttpNotFound();
            }
            return View(contaCorrente);
        }

        // POST: ContaCorrentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ContaCorrente contaCorrente = await db.ContaCorrente.FindAsync(id);
            db.ContaCorrente.Remove(contaCorrente);
            await db.SaveChangesAsync();
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
