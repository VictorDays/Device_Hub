using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Device_Hub.App_Data;
using Device_Hub.Models;

namespace Device_Hub.Controllers
{
    [Authorize]
    public class GarantiasController : Controller
    {
        private DeviceHubContext db = new DeviceHubContext();

        // GET: Garantias
        public ActionResult Index()
        {
            var garantias = db.Garantias.Include(g => g.Fornecedor);
            return View(garantias.ToList());
        }

        // GET: Garantias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garantia garantia = db.Garantias.Find(id);
            if (garantia == null)
            {
                return HttpNotFound();
            }
            return View(garantia);
        }

        // GET: Garantias/Create
        public ActionResult Create()
        {
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "Id", "Nome");
            return View();
        }

        // POST: Garantias/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataInicio,DataFim,FornecedorId")] Garantia garantia)
        {
            if (ModelState.IsValid)
            {
                db.Garantias.Add(garantia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "Id", "Nome", garantia.FornecedorId);
            return View(garantia);
        }

        // GET: Garantias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garantia garantia = db.Garantias.Find(id);
            if (garantia == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "Id", "Nome", garantia.FornecedorId);
            return View(garantia);
        }

        // POST: Garantias/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataInicio,DataFim,FornecedorId")] Garantia garantia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garantia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "Id", "Nome", garantia.FornecedorId);
            return View(garantia);
        }

        // GET: Garantias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garantia garantia = db.Garantias.Find(id);
            if (garantia == null)
            {
                return HttpNotFound();
            }
            return View(garantia);
        }

        // POST: Garantias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Garantia garantia = db.Garantias.Find(id);
            db.Garantias.Remove(garantia);
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
