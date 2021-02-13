using AutoMapper;
using ControleContas.Application.Interfaces;
using ControleContas.Application.ViewModels;
using ControleContas.Domain.Entities;
using ControleContas.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Application.Services
{
    public class CategoriasService : ICategoriasService
    {
        private ICategoriasRepository _categoriasRepository;
        private readonly IMapper _mapper;

        public CategoriasService(ICategoriasRepository categoriasRepository, IMapper mapper)
        {
            _categoriasRepository = categoriasRepository;
            _mapper = mapper;
        }

        public void Add(CategoriasViewModel categoria)
        {
            Categorias mapCategoria = _mapper.Map<Categorias>(categoria);
            _categoriasRepository.Add(mapCategoria);
        }

        public async Task<IEnumerable<CategoriasViewModel>> GetAll()
        {
            IEnumerable<Categorias> result = await _categoriasRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoriasViewModel>>(result);
        }

        public async Task<CategoriasViewModel> GetById(int? id)
        {
            Categorias categoria = await _categoriasRepository.GetById(id);
            return _mapper.Map<CategoriasViewModel>(categoria);
        }

        public void Remove(int? id)
        {
            Categorias categoria = _categoriasRepository.GetById(id).Result;
            _categoriasRepository.Remove(categoria);
        }

        public void Update(CategoriasViewModel categoria)
        {
            Categorias mapCategoria = _mapper.Map<Categorias>(categoria);
            _categoriasRepository.Update(mapCategoria);
        }
    }
}
