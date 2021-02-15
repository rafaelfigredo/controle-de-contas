using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas.Domain.Entities
{
    public class ContasTipos
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Contas> Contas { get; set; }
    }
}
