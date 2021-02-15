using System.Collections.Generic;

namespace ControleContas.Domain.Entities
{
    public class Categorias
    {
        public Categorias()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }

        public virtual ICollection<Lancamentos> Lancamentos { get; set; }
    }
}
