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
    public class BancoesController : Controller
    {
        private CAPEntities db = new CAPEntities();

        // GET: Bancoes
        public async Task<ActionResult> Index()
        {
            return View(await db.Banco.ToListAsync());
        }

        // GET: Bancoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banco banco = await db.Banco.FindAsync(id);
            if (banco == null)
            {
                return HttpNotFound();
            }
            return View(banco);
        }

        // GET: Bancoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bancoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Nome,Numero")] Banco banco)
        {
            if (ModelState.IsValid)
            {
                db.Banco.Add(banco);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(banco);
        }

        // GET: Bancoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banco banco = await db.Banco.FindAsync(id);
            if (banco == null)
            {
                return HttpNotFound();
            }
            return View(banco);
        }

        // POST: Bancoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Nome,Numero")] Banco banco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banco).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(banco);
        }

        // GET: Bancoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banco banco = await db.Banco.FindAsync(id);
            if (banco == null)
            {
                return HttpNotFound();
            }
            return View(banco);
        }

        // POST: Bancoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Banco banco = await db.Banco.FindAsync(id);
            db.Banco.Remove(banco);
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
