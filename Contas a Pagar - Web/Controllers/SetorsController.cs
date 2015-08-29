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
    public class SetorsController : Controller
    {
        private CAPEntities db = new CAPEntities();

        // GET: Setors
        public async Task<ActionResult> Index()
        {
            return View(await db.Setor.ToListAsync());
        }

        // GET: Setors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setor setor = await db.Setor.FindAsync(id);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

        // GET: Setors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Descricao")] Setor setor)
        {
            if (ModelState.IsValid)
            {
                db.Setor.Add(setor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(setor);
        }

        // GET: Setors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setor setor = await db.Setor.FindAsync(id);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

        // POST: Setors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Descricao")] Setor setor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(setor);
        }

        // GET: Setors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setor setor = await db.Setor.FindAsync(id);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

        // POST: Setors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Setor setor = await db.Setor.FindAsync(id);
            db.Setor.Remove(setor);
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
