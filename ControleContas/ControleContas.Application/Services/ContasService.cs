using AutoMapper;
using ControleContas.Application.Interfaces;
using ControleContas.Application.ViewModels;
using ControleContas.Domain.Entities;
using ControleContas.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Application.Services
{
    public class ContasService : IContasService
    {
        private IContasRepository _contasRepository;
        private readonly IMapper _mapper;

        public ContasService(IContasRepository contasRepository, IMapper mapper)
        {
            _contasRepository = contasRepository;
            _mapper = mapper;
        }

        public void Add(ContasViewModel contas)
        {
            Contas mapContas = _mapper.Map<Contas>(contas);
            _contasRepository.Add(mapContas);
        }

        public async Task<IEnumerable<ContasViewModel>> GetAll()
        {
            IEnumerable<Contas> result = await _contasRepository.GetAll();
            return _mapper.Map<IEnumerable<ContasViewModel>>(result);
        }

        public async Task<ContasViewModel> GetById(int? id)
        {
            Contas contas = await _contasRepository.GetById(id);
            return _mapper.Map<ContasViewModel>(contas);
        }

        public void Remove(int? id)
        {
            Contas contas = _contasRepository.GetById(id).Result;
            _contasRepository.Remove(contas);
        }

        public void Update(ContasViewModel contas)
        {
            Contas mapContas = _mapper.Map<Contas>(contas);
            _contasRepository.Update(mapContas);
        }
    }
}
