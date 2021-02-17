using ControleContas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Domain.Interfaces.Utils
{
    public interface IDropdownRepository
    {
        Task<IEnumerable<Categorias>> GetCategorias();
        Task<IEnumerable<Contas>> GetContas();
        Task<IEnumerable<ContasTipos>> GetContasTipos();
    }
}
