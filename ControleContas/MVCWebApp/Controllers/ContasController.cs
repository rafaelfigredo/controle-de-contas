using ControleContas.Application.Interfaces;
using ControleContas.Application.Interfaces.Utils;
using ControleContas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class ContasController : Controller
    {
        private readonly IContasService _contasService;
        private readonly IDropdownService _dropdownService;

        public ContasController(IContasService contasService, IDropdownService dropdownService)
        {
            _contasService = contasService;
            _dropdownService = dropdownService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _contasService.GetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.ContasTiposId = new SelectList(_dropdownService.GetContasTipos().Result, "Id", "Nome");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(ContasViewModel contas)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contasService.Add(contas);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.ContasTiposId = new SelectList(_dropdownService.GetContasTipos().Result, "Id", "Nome");
            return View(contas);
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null) return NotFound();

            var contas = await _contasService.GetById(id);

            if (contas == null) return NotFound();

            return View(contas);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return NotFound();

            var contas = await _contasService.GetById(id);

            if (contas == null) return NotFound();

            ViewBag.ContasTiposId = new SelectList(_dropdownService.GetContasTipos().Result, "Id", "Nome");
            return View(contas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ContasViewModel contas)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contasService.Update(contas);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.ContasTiposId = new SelectList(_dropdownService.GetContasTipos().Result, "Id", "Nome");
            return View(contas);
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null) return NotFound();

            var contas = await _contasService.GetById(id);

            if (contas == null) return NotFound();

            return View(contas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(ContasViewModel contas)
        {
            _contasService.Remove(contas.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
