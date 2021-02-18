using ControleContas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Domain.Interfaces
{
    public interface ILancamentosRepository
    {
        Task<IEnumerable<Lancamentos>> GetAll();
        Task<Lancamentos> GetById(int? id);
        Task<IEnumerable<Lancamentos>> GetParcelasDashboard();

        void Add(Lancamentos lancamentos);
        void Update(Lancamentos lancamentos);
        void Remove(Lancamentos lancamentos);
    }
}
