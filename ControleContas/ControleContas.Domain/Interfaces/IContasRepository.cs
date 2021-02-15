using ControleContas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Domain.Interfaces
{
    public interface IContasRepository
    {
        Task<IEnumerable<Contas>> GetAll();
        Task<Contas> GetById(int? id);

        void Add(Contas contas);
        void Update(Contas contas);
        void Remove(Contas contas);
    }
}
