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
    public class ManutencoesController : Controller
    {
        private DeviceHubContext db = new DeviceHubContext();

        // GET: Manutencoes
        public ActionResult Index()
        {
            var manutencoes = db.Manutencoes.Include(m => m.Ativo);
            return View(manutencoes.ToList());
        }

        // GET: Manutencoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manutencao manutencao = db.Manutencoes.Find(id);
            if (manutencao == null)
            {
                return HttpNotFound();
            }
            return View(manutencao);
        }

        // GET: Manutencoes/Create
        public ActionResult Create()
        {
            ViewBag.AtivoId = new SelectList(db.Ativos, "Id", "Nome");
            return View();
        }

        // POST: Manutencoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data,Descricao,Custo,AtivoId")] Manutencao manutencao)
        {
            if (ModelState.IsValid)
            {
                db.Manutencoes.Add(manutencao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AtivoId = new SelectList(db.Ativos, "Id", "Nome", manutencao.AtivoId);
            return View(manutencao);
        }

        // GET: Manutencoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manutencao manutencao = db.Manutencoes.Find(id);
            if (manutencao == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtivoId = new SelectList(db.Ativos, "Id", "Nome", manutencao.AtivoId);
            return View(manutencao);
        }

        // POST: Manutencoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,Descricao,Custo,AtivoId")] Manutencao manutencao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manutencao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AtivoId = new SelectList(db.Ativos, "Id", "Nome", manutencao.AtivoId);
            return View(manutencao);
        }

        // GET: Manutencoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manutencao manutencao = db.Manutencoes.Find(id);
            if (manutencao == null)
            {
                return HttpNotFound();
            }
            return View(manutencao);
        }

        // POST: Manutencoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manutencao manutencao = db.Manutencoes.Find(id);
            db.Manutencoes.Remove(manutencao);
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
