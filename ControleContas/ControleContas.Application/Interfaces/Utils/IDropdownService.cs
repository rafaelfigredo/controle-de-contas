using ControleContas.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Application.Interfaces.Utils
{
    public interface IDropdownService
    {
        Task<IEnumerable<CategoriasViewModel>> GetCategorias();
        Task<IEnumerable<ContasViewModel>> GetContas();
        Task<IEnumerable<ContasTiposViewModel>> GetContasTipos();
    }
}
