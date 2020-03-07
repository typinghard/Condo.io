using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CondominioService.WebApp.MVC.Models;
using CondominioService.DenunciaContext.Application.ViewModels;
using CondominioService.DenunciaContext.Application.Interfaces;
using System;
using Microsoft.AspNetCore.Http;

namespace CondominioService.WebApp.MVC.Controllers
{
    public class DenunciaController : Controller
    {
        private readonly ILogger<DenunciaController> _logger;
        private readonly IDenunciaAppService _denunciaAppService;

        public DenunciaController(ILogger<DenunciaController> logger, IDenunciaAppService denunciaAppService)
        {
            _logger = logger;
            _denunciaAppService = denunciaAppService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListaDenuncia()
        {
            return View(_denunciaAppService.ObterTodas());
        }

        [HttpGet]
        [Route("detalhe-denuncia/{id}")]
        public IActionResult DetalhesDenuncia(Guid id)
        {
            return View(_denunciaAppService.ObterPorId(id));
        }

        [HttpGet]
        [Route("nova-denuncia")]
        public IActionResult NovaDenuncia()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("nova-denuncia")]
        public IActionResult NovaDenuncia(CriarDenunciaViewModel criardenunciaViewModel)
        {
            if (!ModelState.IsValid)
                return View(criardenunciaViewModel);

            _denunciaAppService.AdicionarDenuncia(criardenunciaViewModel);

            return RedirectToAction("ListaDenuncia");
        }

        [HttpGet]
        [Route("editar-denuncia/{id:guid}")]
        public IActionResult EditarDenuncia(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denunciaViewModel = _denunciaAppService.ObterPorId(id.Value);
            if (denunciaViewModel == null)
            {
                return NotFound();
            }

            return View(denunciaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar-denuncia/{id:guid}")]
        public IActionResult EditarDenuncia(AtualizarDenunciaViewModel atualizarDenunciaViewModel)
        {
            if (!ModelState.IsValid)
                return View(atualizarDenunciaViewModel);

            _denunciaAppService.AtualizarDenuncia(atualizarDenunciaViewModel);

            return RedirectToAction("DetalhesDenuncia", new { atualizarDenunciaViewModel.Id });
        }


        [HttpGet]
        [Route("deletar-denuncia/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denunciaViewModel = _denunciaAppService.ObterPorId(id.Value);
            if (denunciaViewModel == null)
            {
                return NotFound();
            }

            return View(denunciaViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Route("deletar-denuncia/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _denunciaAppService.DeletarDenuncia(id);
            return RedirectToAction("ListaDenuncia");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}