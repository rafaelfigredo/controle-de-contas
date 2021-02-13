using ControleContas.Application.Interfaces;
using ControleContas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
                _categoriasService.Add(categoria);
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }
    }
}