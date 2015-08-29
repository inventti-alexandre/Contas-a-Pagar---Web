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
    public class RelacaoFornecimentoesController : Controller
    {
        private CAPEntities db = new CAPEntities();

        // GET: RelacaoFornecimentoes
        public async Task<ActionResult> Index()
        {
            return View(await db.RelacaoFornecimento.ToListAsync());
        }

        // GET: RelacaoFornecimentoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelacaoFornecimento relacaoFornecimento = await db.RelacaoFornecimento.FindAsync(id);
            if (relacaoFornecimento == null)
            {
                return HttpNotFound();
            }
            return View(relacaoFornecimento);
        }

        // GET: RelacaoFornecimentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RelacaoFornecimentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FornecimentoID,RazaoSocial,FornecedorID,Data,PrecoTotalFornecimento")] RelacaoFornecimento relacaoFornecimento)
        {
            if (ModelState.IsValid)
            {
                db.RelacaoFornecimento.Add(relacaoFornecimento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(relacaoFornecimento);
        }

        // GET: RelacaoFornecimentoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelacaoFornecimento relacaoFornecimento = await db.RelacaoFornecimento.FindAsync(id);
            if (relacaoFornecimento == null)
            {
                return HttpNotFound();
            }
            return View(relacaoFornecimento);
        }

        // POST: RelacaoFornecimentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FornecimentoID,RazaoSocial,FornecedorID,Data,PrecoTotalFornecimento")] RelacaoFornecimento relacaoFornecimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relacaoFornecimento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(relacaoFornecimento);
        }

        // GET: RelacaoFornecimentoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelacaoFornecimento relacaoFornecimento = await db.RelacaoFornecimento.FindAsync(id);
            if (relacaoFornecimento == null)
            {
                return HttpNotFound();
            }
            return View(relacaoFornecimento);
        }

        // POST: RelacaoFornecimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RelacaoFornecimento relacaoFornecimento = await db.RelacaoFornecimento.FindAsync(id);
            db.RelacaoFornecimento.Remove(relacaoFornecimento);
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
