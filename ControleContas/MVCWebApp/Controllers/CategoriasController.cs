using ControleContas.Application.Interfaces;
using ControleContas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriasService _categoriasService;

        public CategoriasController(ICategoriasService categoriasService)
        {
            _categoriasService = categoriasService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _categoriasService.GetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar([Bind("Id,Nome,Cor")] CategoriasViewModel categoria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoriasService.Add(categoria);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return NotFound();

            var categoria = await _categoriasService.GetById(id);

            if (categoria == null) return NotFound();

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar([Bind("Id,Nome,Cor")] CategoriasViewModel categoria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoriasService.Update(categoria);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }
    }
}