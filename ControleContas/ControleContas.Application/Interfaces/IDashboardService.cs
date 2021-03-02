using ControleContas.Application.ViewModels;
using System.Threading.Tasks;

namespace ControleContas.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardViewModel> GetDashboard();
        Task<ChartDashCatogorias> GetChartDashCatogorias();
        Task<ChartDashContas> GetChartDashContas();
    }
}
