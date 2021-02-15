using ControleContas.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Application.Interfaces
{
    public interface IContasService
    {
        Task<IEnumerable<ContasViewModel>> GetAll();
        Task<ContasViewModel> GetById(int? id);

        void Add(ContasViewModel contas);
        void Update(ContasViewModel contas);
        void Remove(int? id);
    }
}
