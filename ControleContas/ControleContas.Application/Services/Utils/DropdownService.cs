using AutoMapper;
using ControleContas.Application.Interfaces.Utils;
using ControleContas.Application.ViewModels;
using ControleContas.Domain.Entities;
using ControleContas.Domain.Interfaces.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Application.Services.Utils
{
    public class DropdownService : IDropdownService
    {
        private IDropdownRepository _dropdownRepository;
        private readonly IMapper _mapper;

        public DropdownService(IDropdownRepository dropdownRepository, IMapper mapper)
        {
            _dropdownRepository = dropdownRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriasViewModel>> GetCategorias()
        {
            IEnumerable<Categorias> result = await _dropdownRepository.GetCategorias();
            return _mapper.Map<IEnumerable<CategoriasViewModel>>(result);
        }

        public async Task<IEnumerable<ContasViewModel>> GetContas()
        {
            IEnumerable<Contas> result = await _dropdownRepository.GetContas();
            return _mapper.Map<IEnumerable<ContasViewModel>>(result);
        }

        public async Task<IEnumerable<ContasTiposViewModel>> GetContasTipos()
        {
            IEnumerable<ContasTipos> result = await _dropdownRepository.GetContasTipos();
            return _mapper.Map<IEnumerable<ContasTiposViewModel>>(result);
        }
    }
}
