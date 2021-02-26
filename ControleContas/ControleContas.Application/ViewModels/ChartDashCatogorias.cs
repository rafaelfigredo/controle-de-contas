using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas.Application.ViewModels
{
    public class ChartDashCatogorias
    {
        public List<string> Categorias { get; set; } = new List<string>();
        public List<decimal> Valores { get; set; } = new List<decimal>();
    }
}
