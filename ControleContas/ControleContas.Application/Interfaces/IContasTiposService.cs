using ControleContas.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Application.Interfaces
{
    public interface IContasTiposService
    {
        Task<IEnumerable<ContasTiposViewModel>> GetAll();
        Task<ContasTiposViewModel> GetById(int? id);

        void Add(ContasTiposViewModel contastipos);
        void Update(ContasTiposViewModel contastipos);
        void Remove(int? id);
    }
}
