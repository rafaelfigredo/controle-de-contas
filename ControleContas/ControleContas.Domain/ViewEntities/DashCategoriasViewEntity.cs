﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas.Domain.ViewEntities
{
    public class DashCategoriasViewEntity
    {
        public int IdCategoria { get; set; }

        public string NomeCategoria { get; set; }

        public decimal Valor { get; set; }
    }
}
