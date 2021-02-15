using ControleContas.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Application.Interfaces
{
    public interface IParcelasService
    {
        Task<IEnumerable<ParcelasViewModel>> GetAll();
        Task<ParcelasViewModel> GetById(int? id);

        void Add(ParcelasViewModel parcelas);
        void Update(ParcelasViewModel parcelas);
        void Remove(int? id);
    }
}
