using AutoMapper;
using ControleContas.Application.Interfaces;
using ControleContas.Application.ViewModels;
using ControleContas.Domain.Entities;
using ControleContas.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Application.Services
{
    public class ParcelasService : IParcelasService
    {
        private IParcelasRepository _parcelasRepository;
        private readonly IMapper _mapper;

        public ParcelasService(IParcelasRepository parcelasRepository, IMapper mapper)
        {
            _parcelasRepository = parcelasRepository;
            _mapper = mapper;
        }

        public void Add(ParcelasViewModel parcelas)
        {
            Parcelas mapParcelas = _mapper.Map<Parcelas>(parcelas);
            _parcelasRepository.Add(mapParcelas);
        }

        public async Task<IEnumerable<ParcelasViewModel>> GetAll()
        {
            IEnumerable<Parcelas> result = await _parcelasRepository.GetAll();
            return _mapper.Map<IEnumerable<ParcelasViewModel>>(result);
        }

        public async Task<ParcelasViewModel> GetById(int? id)
        {
            Parcelas parcelas = await _parcelasRepository.GetById(id);
            return _mapper.Map<ParcelasViewModel>(parcelas);
        }

        public void Remove(int? id)
        {
            Parcelas parcelas = _parcelasRepository.GetById(id).Result;
            _parcelasRepository.Remove(parcelas);
        }

        public void Update(ParcelasViewModel parcelas)
        {
            Parcelas mapParcelas = _mapper.Map<Parcelas>(parcelas);
            _parcelasRepository.Update(mapParcelas);
        }
    }
}
