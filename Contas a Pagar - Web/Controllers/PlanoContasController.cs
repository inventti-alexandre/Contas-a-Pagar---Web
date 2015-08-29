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
    public class PlanoContasController : Controller
    {
        private CAPEntities db = new CAPEntities();

        // GET: PlanoContas
        public async Task<ActionResult> Index()
        {
            var planoContas = db.PlanoContas.Include(p => p.ContaCorrente);
            return View(await planoContas.ToListAsync());
        }

        // GET: PlanoContas/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoContas planoContas = await db.PlanoContas.FindAsync(id);
            if (planoContas == null)
            {
                return HttpNotFound();
            }
            return View(planoContas);
        }

        // GET: PlanoContas/Create
        public ActionResult Create()
        {
            ViewBag.Conta = new SelectList(db.ContaCorrente, "Conta", "Conta");
            return View();
        }

        // POST: PlanoContas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Conta,Descricao,Consolidacao")] PlanoContas planoContas)
        {
            if (ModelState.IsValid)
            {
                db.PlanoContas.Add(planoContas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Conta = new SelectList(db.ContaCorrente, "Conta", "Conta", planoContas.Conta);
            return View(planoContas);
        }

        // GET: PlanoContas/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoContas planoContas = await db.PlanoContas.FindAsync(id);
            if (planoContas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Conta = new SelectList(db.ContaCorrente, "Conta", "Conta", planoContas.Conta);
            return View(planoContas);
        }

        // POST: PlanoContas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Conta,Descricao,Consolidacao")] PlanoContas planoContas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planoContas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Conta = new SelectList(db.ContaCorrente, "Conta", "Conta", planoContas.Conta);
            return View(planoContas);
        }

        // GET: PlanoContas/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoContas planoContas = await db.PlanoContas.FindAsync(id);
            if (planoContas == null)
            {
                return HttpNotFound();
            }
            return View(planoContas);
        }

        // POST: PlanoContas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            PlanoContas planoContas = await db.PlanoContas.FindAsync(id);
            db.PlanoContas.Remove(planoContas);
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
