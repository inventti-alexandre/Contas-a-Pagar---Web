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
    public class PesquisarCCsController : Controller
    {
        private CAPEntities db = new CAPEntities();

        // GET: PesquisarCCs
        public ActionResult Index()
        {
            return View(db.PesquisarCC.ToList());
        }

        // GET: PesquisarCCs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesquisarCC pesquisarCC = db.PesquisarCC.Find(id);
            if (pesquisarCC == null)
            {
                return HttpNotFound();
            }
            return View(pesquisarCC);
        }

        // GET: PesquisarCCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PesquisarCCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Conta,Limite,Cidade,AgenciaID,Email,Endereco,Gerente,Telefone,Nome,Numero")] PesquisarCC pesquisarCC)
        {
            if (ModelState.IsValid)
            {
                db.PesquisarCC.Add(pesquisarCC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pesquisarCC);
        }

        // GET: PesquisarCCs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesquisarCC pesquisarCC = db.PesquisarCC.Find(id);
            if (pesquisarCC == null)
            {
                return HttpNotFound();
            }
            return View(pesquisarCC);
        }

        // POST: PesquisarCCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Conta,Limite,Cidade,AgenciaID,Email,Endereco,Gerente,Telefone,Nome,Numero")] PesquisarCC pesquisarCC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pesquisarCC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pesquisarCC);
        }

        // GET: PesquisarCCs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesquisarCC pesquisarCC = db.PesquisarCC.Find(id);
            if (pesquisarCC == null)
            {
                return HttpNotFound();
            }
            return View(pesquisarCC);
        }

        // POST: PesquisarCCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PesquisarCC pesquisarCC = db.PesquisarCC.Find(id);
            db.PesquisarCC.Remove(pesquisarCC);
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
