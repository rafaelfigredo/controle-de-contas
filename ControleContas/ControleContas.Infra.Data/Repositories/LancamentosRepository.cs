using ControleContas.Domain.Entities;
using ControleContas.Domain.Interfaces;
using ControleContas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Infra.Data.Repositories
{
    public class LancamentosRepository : ILancamentosRepository
    {
        private ApplicationDbContext _context;

        public LancamentosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lancamentos>> GetAll()
        {
            return await _context.Lancamentos.ToListAsync();
        }

        public async Task<Lancamentos> GetById(int? id)
        {
            return await _context.Lancamentos.FindAsync(id);
        }


        public void Add(Lancamentos lancamentos)
        {
            _context.Add(lancamentos);
            _context.SaveChanges();
        }

        public void Update(Lancamentos lancamentos)
        {
            _context.Update(lancamentos);
            _context.SaveChanges();
        }

        public void Remove(Lancamentos lancamentos)
        {
            _context.Remove(lancamentos);
            _context.SaveChanges();
        }
    }
}
