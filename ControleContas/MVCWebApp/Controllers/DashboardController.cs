using ControleContas.Application.Interfaces;
using ControleContas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            DashboardViewModel result = await _dashboardService.GetDashboard();
            return View(result);
        }

        [HttpGet]
        public async Task<JsonResult> ChartCategorias()
        {
            ChartDashCatogorias result = await _dashboardService.GetChartDashCatogorias();
            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> ChartContas()
        {
            ChartDashContas result = await _dashboardService.GetChartDashContas();
            return Json(result);
        }
    }
}