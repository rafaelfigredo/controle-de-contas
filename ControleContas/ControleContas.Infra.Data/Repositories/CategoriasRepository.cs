using ControleContas.Domain.Entities;
using ControleContas.Domain.Interfaces;
using ControleContas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleContas.Infra.Data.Repositories
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private ApplicationDbContext _context;

        public CategoriasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categorias>> GetAll()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categorias> GetById(int? id)
        {
            return await _context.Categorias.FindAsync(id);
        }


        public void Add(Categorias categoria)
        {
            _context.Add(categoria);
            _context.SaveChanges();
        }

        public void Update(Categorias categoria)
        {
            _context.Update(categoria);
            _context.SaveChanges();
        }

        public void Remove(Categorias categoria)
        {
            _context.Remove(categoria);
            _context.SaveChanges();
        }
    }
}
