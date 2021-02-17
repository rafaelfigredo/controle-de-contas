using ControleContas.Domain.Entities;
using ControleContas.Domain.Interfaces.Utils;
using ControleContas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Infra.Data.Repositories.Utils
{
    public class DropdownRepository : IDropdownRepository
    {
        private ApplicationDbContext _context;

        public DropdownRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categorias>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<IEnumerable<Contas>> GetContas()
        {
            return await _context.Contas.ToListAsync();
        }

        public async Task<IEnumerable<ContasTipos>> GetContasTipos()
        {
            return await _context.ContasTipos.ToListAsync();
        }
    }
}
