using AutoMapper;
using ControleContas.Application.ViewModels;
using ControleContas.Domain.Entities;

namespace ControleContas.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoriasViewModel, Categorias>();
            CreateMap<ContasTiposViewModel, ContasTipos>();
        }
    }
}