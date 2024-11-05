using Device_Hub.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Device_Hub.Controllers
{
    public class HomeController : Controller
    {
        private DeviceHubContext db = new DeviceHubContext();

        public ActionResult Index()
        {
            var quantidadeAtivos = db.Ativos.Count();
            var ativosEmManutencao = db.Manutencoes.Select(m => m.AtivoId).Distinct().Count();
            var ativosVinculadosFuncionarios = db.Ativos.Where(a => a.ResponsavelId != null).Count();

            ViewBag.QuantidadeAtivos = quantidadeAtivos;
            ViewBag.AtivosEmManutencao = ativosEmManutencao;
            ViewBag.AtivosVinculadosFuncionarios = ativosVinculadosFuncionarios;

            var ativosPorFornecedor = db.Ativos
            .GroupBy(a => a.Fornecedor.Nome)
            .Select(g => new
            {
                Fornecedor = g.Key,
                Quantidade = g.Count()
            })
            .ToList();
            System.Diagnostics.Debug.WriteLine("Fora");
            // Adicione logs para verificar os dados agrupados
            foreach (var item in ativosPorFornecedor)
            {
                System.Diagnostics.Debug.WriteLine("Ativos - Fornecedor: " + item.Fornecedor + ", Quantidade: " + item.Quantidade);
            }

            ViewBag.AtivosPorFornecedor = ativosPorFornecedor;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}