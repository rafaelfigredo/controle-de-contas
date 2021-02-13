using ControleContas.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Application.Interfaces
{
    public interface ICategoriasService
    {
        Task<IEnumerable<CategoriasViewModel>> GetAll();
        Task<CategoriasViewModel> GetById(int? id);

        void Add(CategoriasViewModel categoria);
        void Update(CategoriasViewModel categoria);
        void Remove(int? id);
    }
}
