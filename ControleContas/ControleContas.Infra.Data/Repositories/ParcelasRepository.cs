using ControleContas.Domain.Entities;
using ControleContas.Domain.Interfaces;
using ControleContas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleContas.Infra.Data.Repositories
{
    public class ParcelasRepository : IParcelasRepository
    {
        private ApplicationDbContext _context;

        public ParcelasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parcelas>> GetAll()
        {
            return await _context.Parcelas
                .Include(x => x.Lancamentos)
                .ToListAsync();
        }

        public async Task<Parcelas> GetById(int? id)
        {
            return await _context.Parcelas
                .Include(x => x.Lancamentos)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }


        public void Add(Parcelas parcelas)
        {
            _context.Add(parcelas);
            _context.SaveChanges();
        }

        public void Update(Parcelas parcelas)
        {
            _context.Update(parcelas);
            _context.SaveChanges();
        }

        public void Remove(Parcelas parcelas)
        {
            _context.Remove(parcelas);
            _context.SaveChanges();
        }
    }
}