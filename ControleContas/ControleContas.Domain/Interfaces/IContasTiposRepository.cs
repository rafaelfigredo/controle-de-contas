using ControleContas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Domain.Interfaces
{
    public interface IContasTiposRepository
    {
        Task<IEnumerable<ContasTipos>> GetAll();
        Task<ContasTipos> GetById(int? id);

        void Add(ContasTipos contastipos);
        void Update(ContasTipos contastipos);
        void Remove(ContasTipos contastipos);
    }
}
