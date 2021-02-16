using ControleContas.Application.Interfaces;
using ControleContas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class LancamentosController : Controller
    {
        private readonly ILancamentosService _lancamentosService;

        public LancamentosController(ILancamentosService lancamentosService)
        {
            _lancamentosService = lancamentosService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _lancamentosService.GetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(LancamentosViewModel lancamentos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _lancamentosService.AddAndCreateParcelas(lancamentos);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(lancamentos);
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null) return NotFound();

            var lancamentos = await _lancamentosService.GetById(id);

            if (lancamentos == null) return NotFound();

            return View(lancamentos);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return NotFound();

            var lancamentos = await _lancamentosService.GetById(id);

            if (lancamentos == null) return NotFound();

            return View(lancamentos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(LancamentosViewModel lancamentos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _lancamentosService.Update(lancamentos);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(lancamentos);
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null) return NotFound();

            var lancamentos = await _lancamentosService.GetById(id);

            if (lancamentos == null) return NotFound();

            return View(lancamentos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(LancamentosViewModel lancamentos)
        {
            _lancamentosService.Remove(lancamentos.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
