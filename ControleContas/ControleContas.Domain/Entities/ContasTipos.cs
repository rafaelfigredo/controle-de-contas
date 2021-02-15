using System.Collections.Generic;

namespace ControleContas.Domain.Entities
{
    public class ContasTipos
    {
        public ContasTipos()
        {
            Contas = new HashSet<Contas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Contas> Contas { get; set; }
    }
}
