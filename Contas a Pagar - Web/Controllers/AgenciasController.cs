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
    public class AgenciasController : Controller
    {
        private CAPEntities db = new CAPEntities();

        // GET: Agencias
        public async Task<ActionResult> Index()
        {
            var agencia = db.Agencia.Include(a => a.Banco1);
            return View(await agencia.ToListAsync());
        }

        // GET: Agencias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencia agencia = await db.Agencia.FindAsync(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // GET: Agencias/Create
        public ActionResult Create()
        {
            ViewBag.Banco = new SelectList(db.Banco, "ID", "Nome");
            return View();
        }

        // POST: Agencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Banco,Endereco,Cidade,Gerente,Telefone,Email")] Agencia agencia)
        {
            if (ModelState.IsValid)
            {
                db.Agencia.Add(agencia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Banco = new SelectList(db.Banco, "ID", "Nome", agencia.Banco);
            return View(agencia);
        }

        // GET: Agencias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencia agencia = await db.Agencia.FindAsync(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Banco = new SelectList(db.Banco, "ID", "Nome", agencia.Banco);
            return View(agencia);
        }

        // POST: Agencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Banco,Endereco,Cidade,Gerente,Telefone,Email")] Agencia agencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agencia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Banco = new SelectList(db.Banco, "ID", "Nome", agencia.Banco);
            return View(agencia);
        }

        // GET: Agencias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencia agencia = await db.Agencia.FindAsync(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // POST: Agencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Agencia agencia = await db.Agencia.FindAsync(id);
            db.Agencia.Remove(agencia);
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
