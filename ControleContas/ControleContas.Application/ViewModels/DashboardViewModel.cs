using System;
using System.Collections.Generic;

namespace ControleContas.Application.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<CategoriasViewModel> Categorias { get; set; }
        public IEnumerable<ContasViewModel> Contas { get; set; }
        public IEnumerable<LancamentosViewModel> Lancamentos { get; set; }
        public List<DashboardCalendario> Calendario { get; set; }
    }

    public class DashboardCalendario
    {
        public int Mes { get; set; }
        public int Ano { get; set; }

        public string Descricao => $"{new DateTime(Ano, Mes, 1):MMM-yyyy}".ToUpper();
    }
}