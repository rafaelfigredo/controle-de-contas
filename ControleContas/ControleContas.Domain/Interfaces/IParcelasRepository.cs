using ControleContas.Domain.Entities;
using ControleContas.Domain.ViewEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Domain.Interfaces
{
    public interface IParcelasRepository
    {
        Task<IEnumerable<Parcelas>> GetAll();
        Task<Parcelas> GetById(int? id);
        Task<IEnumerable<DashCategoriasViewEntity>> GetChartDashCategoriasParcelas(int ano, int mes);
        Task<IEnumerable<DashContasViewEntity>> GetChartDashContasParcelas(int ano, int mes);

        void Add(Parcelas parcelas);
        void Update(Parcelas parcelas);
        void Remove(Parcelas parcelas);
    }
}
