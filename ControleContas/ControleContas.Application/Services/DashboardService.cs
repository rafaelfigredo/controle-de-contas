using AutoMapper;
using ControleContas.Application.Interfaces;
using ControleContas.Application.ViewModels;
using ControleContas.Domain.Entities;
using ControleContas.Domain.Interfaces;
using ControleContas.Domain.ViewEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleContas.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private ILancamentosRepository _lancamentosRepository;
        private ICategoriasRepository _categoriasRepository;
        private IContasRepository _contasRepository;
        private IParcelasRepository _parcelasRepository;
        private readonly IMapper _mapper;

        public DashboardService(ILancamentosRepository lancamentosRepository,
            ICategoriasRepository categoriasRepository, IContasRepository contasRepository,
            IParcelasRepository parcelasRepository, IMapper mapper)
        {
            _lancamentosRepository = lancamentosRepository;
            _categoriasRepository = categoriasRepository;
            _contasRepository = contasRepository;
            _parcelasRepository = parcelasRepository;
            _mapper = mapper;
        }

        public async Task<DashboardViewModel> GetDashboard()
        {
            DashboardViewModel dashboard = new DashboardViewModel();
            DateTime today = DateTime.Today;

            dashboard.Lancamentos = await GetLancamentos();
            dashboard.Categorias = await GetCategorias();
            dashboard.Contas = await GetContas();
            dashboard.Calendario = CreateCalendarioSequences(today.Year, today.Month, 12).OrderBy(x => x.Ano).ThenBy(x => x.Mes).ToList();

            return dashboard;
        }

        public async Task<ChartDashCatogorias> GetChartDashCatogorias()
        {
            ChartDashCatogorias chart = new ChartDashCatogorias();
            DateTime today = DateTime.Today;

            IEnumerable<DashCategoriasViewEntity> result = await _parcelasRepository.GetChartDashCategoriasParcelas(today.Year, today.Month);
            result = result.OrderBy(x => x.NomeCategoria).ThenBy(x => x.IdCategoria).ToList();

            foreach (DashCategoriasViewEntity item in result)
            {
                chart.Categorias.Add(item.NomeCategoria);
                chart.Valores.Add(item.Valor);
            }

            return chart;
        }

        private async Task<IEnumerable<CategoriasViewModel>> GetCategorias()
        {
            IEnumerable<Categorias> result = await _categoriasRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoriasViewModel>>(result).ToList().OrderBy(x => x.Nome);
        }

        private async Task<IEnumerable<ContasViewModel>> GetContas()
        {
            IEnumerable<Contas> result = await _contasRepository.GetAll();
            return _mapper.Map<IEnumerable<ContasViewModel>>(result).ToList().OrderBy(x => x.Nome);
        }

        private async Task<IEnumerable<LancamentosViewModel>> GetLancamentos()
        {
            IEnumerable<Lancamentos> result = await _lancamentosRepository.GetParcelasDashboard();
            return _mapper.Map<IEnumerable<LancamentosViewModel>>(result).ToList().OrderBy(x => x.Contas.Nome).ThenBy(x => x.Descricao);
        }

        private List<DashboardCalendario> CreateCalendarioSequences(int ano, int mes, int difMeses)
        {
            List<DashboardCalendario> calendario = new List<DashboardCalendario>();

            DateTime dataAtual = new DateTime(ano, mes, 1);
            DateTime dataInicial = dataAtual.AddMonths(difMeses * -1);
            DateTime dataFinal = dataAtual.AddMonths(difMeses);

            while (dataInicial <= dataFinal)
            {
                calendario.Add(new DashboardCalendario { Ano = dataInicial.Year, Mes = dataInicial.Month });
                dataInicial = dataInicial.AddMonths(1);
            }

            return calendario;
        }
    }
}