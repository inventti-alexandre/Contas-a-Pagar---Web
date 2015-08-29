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
    public class NumFornecimentosPorEmpresasController : Controller
    {
        private CAPEntities db = new CAPEntities();

        // GET: NumFornecimentosPorEmpresas
        public async Task<ActionResult> Index()
        {
            return View(await db.NumFornecimentosPorEmpresa.ToListAsync());
        }

        // GET: NumFornecimentosPorEmpresas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumFornecimentosPorEmpresa numFornecimentosPorEmpresa = await db.NumFornecimentosPorEmpresa.FindAsync(id);
            var b = new List<TodosFornecimentos_Result>();
            var c = new NumForViewModel();
            c.ListaFornecimentos = new List<TodosFornecimentos_Result>();
            foreach (var item in db.TodosFornecimentos(numFornecimentosPorEmpresa.FornecedorID))
            {
                c.ListaFornecimentos.Add(item);
            }
            if (numFornecimentosPorEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        // GET: NumFornecimentosPorEmpresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NumFornecimentosPorEmpresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FornecedorID,RazaoSocial,NumFornecimentos")] NumFornecimentosPorEmpresa numFornecimentosPorEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.NumFornecimentosPorEmpresa.Add(numFornecimentosPorEmpresa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(numFornecimentosPorEmpresa);
        }

        // GET: NumFornecimentosPorEmpresas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumFornecimentosPorEmpresa numFornecimentosPorEmpresa = await db.NumFornecimentosPorEmpresa.FindAsync(id);
            if (numFornecimentosPorEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(numFornecimentosPorEmpresa);
        }

        // POST: NumFornecimentosPorEmpresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FornecedorID,RazaoSocial,NumFornecimentos")] NumFornecimentosPorEmpresa numFornecimentosPorEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(numFornecimentosPorEmpresa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(numFornecimentosPorEmpresa);
        }

        // GET: NumFornecimentosPorEmpresas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumFornecimentosPorEmpresa numFornecimentosPorEmpresa = await db.NumFornecimentosPorEmpresa.FindAsync(id);
            if (numFornecimentosPorEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(numFornecimentosPorEmpresa);
        }

        // POST: NumFornecimentosPorEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NumFornecimentosPorEmpresa numFornecimentosPorEmpresa = await db.NumFornecimentosPorEmpresa.FindAsync(id);
            db.NumFornecimentosPorEmpresa.Remove(numFornecimentosPorEmpresa);
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
