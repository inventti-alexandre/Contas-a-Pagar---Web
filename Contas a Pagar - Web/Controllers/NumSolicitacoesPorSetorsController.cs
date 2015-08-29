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
    public class NumSolicitacoesPorSetorsController : Controller
    {
        private CAPEntities db = new CAPEntities();

        // GET: NumSolicitacoesPorSetors
        public async Task<ActionResult> Index()
        {
            return View(await db.NumSolicitacoesPorSetor.ToListAsync());
        }

        // GET: NumSolicitacoesPorSetors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumSolicitacoesPorSetor numSolicitacoesPorSetor = await db.NumSolicitacoesPorSetor.FindAsync(id);
            var a = db.TodasSolicitacoes(numSolicitacoesPorSetor.SetorID);
            var b = new List<TodasSolicitacoes_Result>();
            var c = new NumSolViewModel();
            c.ListaSolicitacoes = new List<TodasSolicitacoes_Result>();
            c.ListaDetalhesSolicitacoes = new List<DetalhesSolicitacao_Result>();
            foreach (var item in db.TodasSolicitacoes(numSolicitacoesPorSetor.SetorID))
            {
                c.ListaSolicitacoes.Add(item);
            }
            foreach (var item in db.DetalhesSolicitacao(id))
            {
                c.ListaDetalhesSolicitacoes.Add(item);
            }
            if (numSolicitacoesPorSetor == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        // GET: NumSolicitacoesPorSetors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NumSolicitacoesPorSetors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SetorID,Setor,NumSolicitacoes")] NumSolicitacoesPorSetor numSolicitacoesPorSetor)
        {
            if (ModelState.IsValid)
            {
                db.NumSolicitacoesPorSetor.Add(numSolicitacoesPorSetor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(numSolicitacoesPorSetor);
        }

        // GET: NumSolicitacoesPorSetors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumSolicitacoesPorSetor numSolicitacoesPorSetor = await db.NumSolicitacoesPorSetor.FindAsync(id);
            if (numSolicitacoesPorSetor == null)
            {
                return HttpNotFound();
            }
            return View(numSolicitacoesPorSetor);
        }

        // POST: NumSolicitacoesPorSetors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SetorID,Setor,NumSolicitacoes")] NumSolicitacoesPorSetor numSolicitacoesPorSetor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(numSolicitacoesPorSetor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(numSolicitacoesPorSetor);
        }

        // GET: NumSolicitacoesPorSetors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumSolicitacoesPorSetor numSolicitacoesPorSetor = await db.NumSolicitacoesPorSetor.FindAsync(id);
            if (numSolicitacoesPorSetor == null)
            {
                return HttpNotFound();
            }
            return View(numSolicitacoesPorSetor);
        }

        // POST: NumSolicitacoesPorSetors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NumSolicitacoesPorSetor numSolicitacoesPorSetor = await db.NumSolicitacoesPorSetor.FindAsync(id);
            db.NumSolicitacoesPorSetor.Remove(numSolicitacoesPorSetor);
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
