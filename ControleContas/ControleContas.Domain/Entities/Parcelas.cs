using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas.Domain.Entities
{
    public class Parcelas
    {
        public int Id { get; set; }
        public int ParcelaNumero { get; set; }
        public decimal ParcelaValor { get; set; }
        public int AnoCobranca { get; set; }
        public int MesCobranca { get; set; }
        public int LancamentosId { get; set; }

        public virtual Lancamentos Lancamentos { get; set; }
    }
}