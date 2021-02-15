using ControleContas.Domain.Entities;
using ControleContas.Domain.Interfaces;
using ControleContas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Infra.Data.Repositories
{
    public class ContasRepository : IContasRepository
    {
        private ApplicationDbContext _context;

        public ContasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contas>> GetAll()
        {
            return await _context.Contas.Include(x => x.ContasTipos).Include(x => x.Lancamentos).ToListAsync();
        }

        public async Task<Contas> GetById(int? id)
        {
            return await _context.Contas.FindAsync(id);
        }


        public void Add(Contas Contas)
        {
            _context.Add(Contas);
            _context.SaveChanges();
        }

        public void Update(Contas Contas)
        {
            _context.Update(Contas);
            _context.SaveChanges();
        }

        public void Remove(Contas Contas)
        {
            _context.Remove(Contas);
            _context.SaveChanges();
        }
    }
}
