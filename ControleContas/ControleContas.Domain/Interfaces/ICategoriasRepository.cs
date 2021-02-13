using ControleContas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Domain.Interfaces
{
    public interface ICategoriasRepository
    {
        Task<IEnumerable<Categorias>> GetAll();
        Task<Categorias> GetById(int? id);

        void Add(Categorias categoria);
        void Update(Categorias categoria);
        void Remove(Categorias categoria);
    }
}
