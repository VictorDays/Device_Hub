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
    [RoutePrefix("Departamentos")]
    public class DepartamentosController : Controller
    {
        private DeviceHubContext db = new DeviceHubContext();

        [HttpGet]
        public JsonResult VerificarUnicidade(string nome)
        {
            bool existe = db.Departamentos.Any(m => m.Nome == nome);
            return Json(!existe, JsonRequestBehavior.AllowGet);
        }

        // GET: Departamentos
        public ActionResult Index()
        {
            var departamentos = db.Departamentos;

            return View(departamentos.ToList());
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamentos.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // GET: Departamentos/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(db.Ativos, "Id", "Nome");
            return View();
        }

        // POST: Departamentos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,EmpresaId")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                // Verificar unicidade do nome
                bool nomeExiste = db.Departamentos.Any(d => d.Nome == departamento.Nome);
                if (nomeExiste)
                {
                    ModelState.AddModelError("Nome", "O nome já existe. Por favor, escolha outro.");
                    ViewBag.EmpresaId = new SelectList(db.Ativos, "Id", "Nome");
                    return View(departamento);
                }

                db.Departamentos.Add(departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaId = new SelectList(db.Ativos, "Id", "Nome");
            return View(departamento);
        }

        // GET: Departamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamentos.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            
            return View(departamento);
        }

        // POST: Departamentos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,EmpresaId")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(departamento);
        }

        // GET: Departamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamentos.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departamento departamento = db.Departamentos.Find(id);
            db.Departamentos.Remove(departamento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult VerificarVinculos(int id)
        {
            // Log para verificar o ID recebido
            System.Diagnostics.Debug.WriteLine($"Verificando vínculos para o departamento ID: {id}");

            var funcionariosVinculadosFuncionario = db.Funcionarios.Any(f => f.DepartamentoId == id);
            if (funcionariosVinculadosFuncionario)
            {
                return Json(new { sucesso = false, mensagem = "O departamento não pode ser excluído porque há funcionários vinculados a ele." }, JsonRequestBehavior.AllowGet);
            }
            var funcionariosVinculadosAtivo = db.Ativos.Any(f => f.DepartamentoId == id);
            if (funcionariosVinculadosAtivo)
            {
                return Json(new { sucesso = false, mensagem = "O departamento não pode ser excluído porque há ativos vinculados a ele." }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { sucesso = true }, JsonRequestBehavior.AllowGet);
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
