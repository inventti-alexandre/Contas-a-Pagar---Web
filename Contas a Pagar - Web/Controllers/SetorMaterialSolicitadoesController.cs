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
    public class SetorMaterialSolicitadoesController : Controller
    {
        private CAPEntities db = new CAPEntities();

        // GET: SetorMaterialSolicitadoes
        public ActionResult Index()
        {
            return View(db.SetorMaterialSolicitado.ToList());
        }

        // GET: SetorMaterialSolicitadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetorMaterialSolicitado setorMaterialSolicitado = db.SetorMaterialSolicitado.Find(id);
            if (setorMaterialSolicitado == null)
            {
                return HttpNotFound();
            }
            return View(setorMaterialSolicitado);
        }

        // GET: SetorMaterialSolicitadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetorMaterialSolicitadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoID,ProdutoNome,PrecoUnitario,Solicitacao,Descricao,Data")] SetorMaterialSolicitado setorMaterialSolicitado)
        {
            if (ModelState.IsValid)
            {
                db.SetorMaterialSolicitado.Add(setorMaterialSolicitado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setorMaterialSolicitado);
        }

        // GET: SetorMaterialSolicitadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetorMaterialSolicitado setorMaterialSolicitado = db.SetorMaterialSolicitado.Find(id);
            if (setorMaterialSolicitado == null)
            {
                return HttpNotFound();
            }
            return View(setorMaterialSolicitado);
        }

        // POST: SetorMaterialSolicitadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoID,ProdutoNome,PrecoUnitario,Solicitacao,Descricao,Data")] SetorMaterialSolicitado setorMaterialSolicitado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setorMaterialSolicitado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setorMaterialSolicitado);
        }

        // GET: SetorMaterialSolicitadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetorMaterialSolicitado setorMaterialSolicitado = db.SetorMaterialSolicitado.Find(id);
            if (setorMaterialSolicitado == null)
            {
                return HttpNotFound();
            }
            return View(setorMaterialSolicitado);
        }

        // POST: SetorMaterialSolicitadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SetorMaterialSolicitado setorMaterialSolicitado = db.SetorMaterialSolicitado.Find(id);
            db.SetorMaterialSolicitado.Remove(setorMaterialSolicitado);
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
