using ControleContas.Domain.Entities;
using ControleContas.Domain.Interfaces;
using ControleContas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Infra.Data.Repositories
{
    public class ContasTiposRepository : IContasTiposRepository
    {
        private ApplicationDbContext _context;

        public ContasTiposRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContasTipos>> GetAll()
        {
            return await _context.ContasTipos.Include(x => x.Contas).ToListAsync();
        }

        public async Task<ContasTipos> GetById(int? id)
        {
            return await _context.ContasTipos.FindAsync(id);
        }


        public void Add(ContasTipos contastipos)
        {
            _context.Add(contastipos);
            _context.SaveChanges();
        }

        public void Update(ContasTipos contastipos)
        {
            _context.Update(contastipos);
            _context.SaveChanges();
        }

        public void Remove(ContasTipos contastipos)
        {
            _context.Remove(contastipos);
            _context.SaveChanges();
        }
    }
}
