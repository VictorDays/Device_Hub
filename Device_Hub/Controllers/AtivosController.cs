using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Device_Hub.Models;
using Device_Hub.App_Data;

namespace Device_Hub.Controllers
{
    [Authorize]
    public class AtivosController : Controller
    {
        private DeviceHubContext db = new DeviceHubContext();

        // GET: Ativos
        public ActionResult Index()
        {
            var ativos = db.Ativos.Include(a => a.Departamento).Include(a => a.Fornecedor).Include(a => a.Responsavel);
            return View(ativos.ToList());
        }

        // GET: Ativos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ativo ativo = db.Ativos.Find(id);
            if (ativo == null)
            {
                return HttpNotFound();
            }
            return View(ativo);
        }

        // GET: Ativos/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nome");
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "Id", "Nome");
            ViewBag.ResponsavelId = new SelectList(db.Funcionarios, "Id", "Nome");
            return View();
        }

        // POST: Ativos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Fabricante,Modelo,NumeroSerie,DataAquisicao,Valor,Localizacao,Status,ResponsavelId,DepartamentoId,FornecedorId,EmpresaId")] Ativo ativo)
        {
            if (ModelState.IsValid)
            {
                db.Ativos.Add(ativo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nome", ativo.DepartamentoId);
            
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "Id", "Nome", ativo.FornecedorId);
            ViewBag.ResponsavelId = new SelectList(db.Funcionarios, "Id", "Nome", ativo.ResponsavelId);
            return View(ativo);
        }

        // GET: Ativos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ativo ativo = db.Ativos.Find(id);
            if (ativo == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nome", ativo.DepartamentoId);
            
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "Id", "Nome", ativo.FornecedorId);
            ViewBag.ResponsavelId = new SelectList(db.Funcionarios, "Id", "Nome", ativo.ResponsavelId);
            return View(ativo);
        }

        // POST: Ativos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Fabricante,Modelo,NumeroSerie,DataAquisicao,Valor,Localizacao,Status,ResponsavelId,DepartamentoId,FornecedorId,EmpresaId")] Ativo ativo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ativo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nome", ativo.DepartamentoId);
            
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "Id", "Nome", ativo.FornecedorId);
            ViewBag.ResponsavelId = new SelectList(db.Funcionarios, "Id", "Nome", ativo.ResponsavelId);
            return View(ativo);
        }

        // GET: Ativos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ativo ativo = db.Ativos.Find(id);
            if (ativo == null)
            {
                return HttpNotFound();
            }
            return View(ativo);
        }

        // POST: Ativos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ativo ativo = db.Ativos.Find(id);
            db.Ativos.Remove(ativo);
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
