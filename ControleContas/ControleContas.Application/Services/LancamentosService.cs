using AutoMapper;
using ControleContas.Application.Interfaces;
using ControleContas.Application.ViewModels;
using ControleContas.Domain.Entities;
using ControleContas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Application.Services
{
    public class LancamentosService : ILancamentosService
    {
        private ILancamentosRepository _lancamentosRepository;
        private readonly IMapper _mapper;

        public LancamentosService(ILancamentosRepository lancamentosRepository, IMapper mapper)
        {
            _lancamentosRepository = lancamentosRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LancamentosViewModel>> GetAll()
        {
            IEnumerable<Lancamentos> result = await _lancamentosRepository.GetAll();
            return _mapper.Map<IEnumerable<LancamentosViewModel>>(result);
        }

        public async Task<LancamentosViewModel> GetById(int? id)
        {
            Lancamentos lancamentos = await _lancamentosRepository.GetById(id);
            return _mapper.Map<LancamentosViewModel>(lancamentos);
        }

        public void Add(LancamentosViewModel lancamentos)
        {
            Lancamentos mapLancamentos = _mapper.Map<Lancamentos>(lancamentos);
            _lancamentosRepository.Add(mapLancamentos);
        }

        public void Update(LancamentosViewModel lancamentos)
        {
            Lancamentos mapLancamentos = _mapper.Map<Lancamentos>(lancamentos);
            _lancamentosRepository.Update(mapLancamentos);
        }

        public void Remove(int? id)
        {
            Lancamentos lancamentos = _lancamentosRepository.GetById(id).Result;
            _lancamentosRepository.Remove(lancamentos);
        }

        public void AddAndCreateParcelas(LancamentosViewModel lancamentos)
        {
            lancamentos.Parcelas = new List<ParcelasViewModel>();
            for (int parcela = 1; parcela <= lancamentos.ParcelasTotal; parcela++)
            {
                lancamentos.Parcelas.Add(new ParcelasViewModel
                {
                    ParcelaNumero = parcela,
                    ParcelaValor = lancamentos.ValorTotal / lancamentos.ParcelasTotal,
                    AnoCobranca = getAnoCobranca(lancamentos.DataPrimeiraParcela, parcela),
                    MesCobranca = getMesCobranca(lancamentos.DataPrimeiraParcela, parcela)
                });
            }

            Lancamentos mapLancamentos = _mapper.Map<Lancamentos>(lancamentos);
            _lancamentosRepository.Add(mapLancamentos);
        }

        private int getAnoCobranca(DateTime dataPrimeiraParcela, int parcela)
        {
            return dataPrimeiraParcela.AddMonths(parcela - 1).Year;
        }

        private int getMesCobranca(DateTime dataPrimeiraParcela, int parcela)
        {
            return dataPrimeiraParcela.AddMonths(parcela - 1).Month;
        }
    }
}
