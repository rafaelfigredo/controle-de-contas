using System;
using System.Collections.Generic;

namespace ControleContas.Domain.Entities
{
    public class Lancamentos
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorTotal { get; set; }
        public int ParcelasTotal { get; set; }
        public int ContasId { get; set; }
        public int CategoriasId { get; set; }
        public DateTime DataCompra { get; set; }

        public virtual Contas Contas { get; set; }
        public virtual Categorias Categorias { get; set; }
        public virtual ICollection<Parcelas> Parcelas { get; set; }
    }
}
