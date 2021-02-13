﻿using AutoMapper;
using ControleContas.Application.ViewModels;
using ControleContas.Domain.Entities;

namespace ControleContas.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Categorias, CategoriasViewModel>();
        }
    }
}
