using System.Collections.Generic;

namespace ControleContas.Domain.Entities
{
    public class Contas
    {
        public Contas()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int ContasTiposId { get; set; }
        public string Cor { get; set; }
        public int VencimentoDia { get; set; }

        public virtual ContasTipos ContasTipos { get; set; }
        public virtual ICollection<Lancamentos> Lancamentos { get; set; }
    }
}
