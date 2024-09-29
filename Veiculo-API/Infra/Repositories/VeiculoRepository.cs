using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veiculo_API.Dominio;
using Veiculo_API.Infra.Data;
using Veiculo_API.Infra.Repositories.Interfaces;

namespace Veiculo_API.Infra.Repositories;

public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
{
    public VeiculoRepository(ApiDbContext context, DbSet<Veiculo> dbSet) : base(context, dbSet)
    {
    }

    public virtual async Task<IEnumerable<Veiculo>> All()
    {
        return await _context.Veiculos.Where(x => x.Id < 100).ToListAsync();
    }

    public virtual async Task<Veiculo> GetById(int id)
    {
        return await _context.Veiculos.FindAsync(id);
    }

    public virtual async Task<bool> Add(Veiculo entity)
    {
        await _context.Veiculos.AddAsync(entity);
        return true;
    }

    public virtual async Task<bool> Update(Veiculo entity)
    {
        _context.Update(entity);
        return true;
    }

    public virtual async Task<bool> Delete(Veiculo entity)
    {
        _context.Remove(entity);
        return true;
    }

   
}