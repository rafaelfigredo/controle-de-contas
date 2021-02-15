using ControleContas.Application.Interfaces;
using ControleContas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class ContasTiposController : Controller
    {
        private readonly IContasTiposService _contastiposService;

        public ContasTiposController(IContasTiposService contastiposService)
        {
            _contastiposService = contastiposService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _contastiposService.GetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar([Bind("Id,Nome")] ContasTiposViewModel contastipos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contastiposService.Add(contastipos);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(contastipos);
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null) return NotFound();

            var contastipos = await _contastiposService.GetById(id);

            if (contastipos == null) return NotFound();

            return View(contastipos);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return NotFound();

            var contastipos = await _contastiposService.GetById(id);

            if (contastipos == null) return NotFound();

            return View(contastipos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar([Bind("Id,Nome")] ContasTiposViewModel contatipos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contastiposService.Update(contatipos);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(contatipos);
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null) return NotFound();

            var contastipos = await _contastiposService.GetById(id);

            if (contastipos == null) return NotFound();

            return View(contastipos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir([Bind("Id,Nome")] ContasTiposViewModel contatipos)
        {
            _contastiposService.Remove(contatipos.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}