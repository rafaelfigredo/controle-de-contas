using ControleContas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Domain.Interfaces
{
    public interface IParcelasRepository
    {
        Task<IEnumerable<Parcelas>> GetAll();
        Task<Parcelas> GetById(int? id);

        void Add(Parcelas parcelas);
        void Update(Parcelas parcelas);
        void Remove(Parcelas parcelas);
    }
}
