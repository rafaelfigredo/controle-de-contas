using ControleContas.Application.Interfaces;
using ControleContas.Application.Interfaces.Utils;
using ControleContas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class LancamentosController : Controller
    {
        private readonly ILancamentosService _lancamentosService;
        private readonly IDropdownService _dropdownService;

        public LancamentosController(ILancamentosService lancamentosService, IDropdownService dropdownService)
        {
            _lancamentosService = lancamentosService;
            _dropdownService = dropdownService;
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
            ViewBag.ContasId = new SelectList(_dropdownService.GetContas().Result, "Id", "Nome");
            ViewBag.CategoriasId = new SelectList(_dropdownService.GetCategorias().Result, "Id", "Nome");
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

            ViewBag.ContasId = new SelectList(_dropdownService.GetContas().Result, "Id", "Nome");
            ViewBag.CategoriasId = new SelectList(_dropdownService.GetCategorias().Result, "Id", "Nome");
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

            ViewBag.ContasId = new SelectList(_dropdownService.GetContas().Result, "Id", "Nome");
            ViewBag.CategoriasId = new SelectList(_dropdownService.GetCategorias().Result, "Id", "Nome");
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

            ViewBag.ContasId = new SelectList(_dropdownService.GetContas().Result, "Id", "Nome");
            ViewBag.CategoriasId = new SelectList(_dropdownService.GetCategorias().Result, "Id", "Nome");
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
