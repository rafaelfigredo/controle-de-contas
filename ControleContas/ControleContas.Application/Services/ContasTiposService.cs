using AutoMapper;
using ControleContas.Application.Interfaces;
using ControleContas.Application.ViewModels;
using ControleContas.Domain.Entities;
using ControleContas.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Application.Services
{
    public class ContasTiposService : IContasTiposService
    {
        private IContasTiposRepository _contastiposRepository;
        private readonly IMapper _mapper;

        public ContasTiposService(IContasTiposRepository contastiposRepository, IMapper mapper)
        {
            _contastiposRepository = contastiposRepository;
            _mapper = mapper;
        }

        public void Add(ContasTiposViewModel contastipos)
        {
            ContasTipos mapContastipos = _mapper.Map<ContasTipos>(contastipos);
            _contastiposRepository.Add(mapContastipos);
        }

        public async Task<IEnumerable<ContasTiposViewModel>> GetAll()
        {
            IEnumerable<ContasTipos> result = await _contastiposRepository.GetAll();
            return _mapper.Map<IEnumerable<ContasTiposViewModel>>(result);
        }

        public async Task<ContasTiposViewModel> GetById(int? id)
        {
            ContasTipos contastipos = await _contastiposRepository.GetById(id);
            return _mapper.Map<ContasTiposViewModel>(contastipos);
        }

        public void Remove(int? id)
        {
            ContasTipos contastipos = _contastiposRepository.GetById(id).Result;
            _contastiposRepository.Remove(contastipos);
        }

        public void Update(ContasTiposViewModel contastipos)
        {
            ContasTipos mapContastipos = _mapper.Map<ContasTipos>(contastipos);
            _contastiposRepository.Update(mapContastipos);
        }
    }
}
