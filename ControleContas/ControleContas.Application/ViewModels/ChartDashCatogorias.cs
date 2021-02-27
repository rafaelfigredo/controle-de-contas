using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas.Application.ViewModels
{
    public class ChartDashCatogorias
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public string Descricao => $"{new DateTime(Ano, Mes, 1):MMM-yyyy}".ToUpper();
        public List<string> Categorias { get; set; } = new List<string>();
        public List<decimal> Valores { get; set; } = new List<decimal>();
    }
}
