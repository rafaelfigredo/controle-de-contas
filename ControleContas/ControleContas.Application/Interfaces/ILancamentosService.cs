using ControleContas.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Application.Interfaces
{
    public interface ILancamentosService
    {
        Task<IEnumerable<LancamentosViewModel>> GetAll();
        Task<LancamentosViewModel> GetById(int? id);

        void Add(LancamentosViewModel lancamentos);
        void Update(LancamentosViewModel lancamentos);
        void Remove(int? id);
    }
}
