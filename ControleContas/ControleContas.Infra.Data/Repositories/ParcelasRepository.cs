using ControleContas.Domain.Entities;
using ControleContas.Domain.Interfaces;
using ControleContas.Domain.ViewEntities;
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

        public async Task<IEnumerable<DashCategoriasViewEntity>> GetChartDashCategoriasParcelas(int ano, int mes)
        {
            return await _context.Parcelas
                .Include(x => x.Lancamentos.Categorias)
                .Where(x => x.MesCobranca == mes)
                .Where(x => x.AnoCobranca == ano)
                .GroupBy(t => new { t.Lancamentos.Categorias.Id, t.Lancamentos.Categorias.Nome, t.Lancamentos.Categorias.Cor })
                .Select(gp => new DashCategoriasViewEntity
                {
                    IdCategoria = gp.Key.Id,
                    NomeCategoria = gp.Key.Nome,
                    Cor = gp.Key.Cor,
                    Valor = gp.Sum(x => x.ParcelaValor)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<DashContasViewEntity>> GetChartDashContasParcelas(int ano, int mes)
        {
            return await _context.Parcelas
                .Include(x => x.Lancamentos.Categorias)
                .Where(x => x.MesCobranca == mes)
                .Where(x => x.AnoCobranca == ano)
                .GroupBy(t => new { t.Lancamentos.Contas.Id, t.Lancamentos.Contas.Nome, t.Lancamentos.Contas.Cor })
                .Select(gp => new DashContasViewEntity
                {
                    IdConta = gp.Key.Id,
                    NomeConta = gp.Key.Nome,
                    Cor = gp.Key.Cor,
                    Valor = gp.Sum(x => x.ParcelaValor)
                })
                .ToListAsync();
        }
    }
}