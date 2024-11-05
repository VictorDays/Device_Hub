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
    public class LicencasController : Controller
    {
        private DeviceHubContext db = new DeviceHubContext();

        // GET: Licencas
        public ActionResult Index()
        {
            var licencas = db.Licencas.Include(l => l.Ativo);
            return View(licencas.ToList());
        }

        // GET: Licencas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licenca licenca = db.Licencas.Find(id);
            if (licenca == null)
            {
                return HttpNotFound();
            }
            return View(licenca);
        }

        // GET: Licencas/Create
        public ActionResult Create()
        {
            ViewBag.AtivoId = new SelectList(db.Ativos, "Id", "Nome");
            return View();
        }

        // POST: Licencas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Tipo,NumeroSerie,DataAquisicao,DataExpiracao,Software,AtivoId")] Licenca licenca)
        {
            if (ModelState.IsValid)
            {
                db.Licencas.Add(licenca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AtivoId = new SelectList(db.Ativos, "Id", "Nome", licenca.AtivoId);
            return View(licenca);
        }

        // GET: Licencas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licenca licenca = db.Licencas.Find(id);
            if (licenca == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtivoId = new SelectList(db.Ativos, "Id", "Nome", licenca.AtivoId);
            return View(licenca);
        }

        // POST: Licencas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Tipo,NumeroSerie,DataAquisicao,DataExpiracao,Software,AtivoId")] Licenca licenca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licenca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AtivoId = new SelectList(db.Ativos, "Id", "Nome", licenca.AtivoId);
            return View(licenca);
        }

        // GET: Licencas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licenca licenca = db.Licencas.Find(id);
            if (licenca == null)
            {
                return HttpNotFound();
            }
            return View(licenca);
        }

        // POST: Licencas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Licenca licenca = db.Licencas.Find(id);
            db.Licencas.Remove(licenca);
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
