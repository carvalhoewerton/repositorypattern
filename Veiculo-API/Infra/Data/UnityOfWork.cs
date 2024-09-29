using Veiculo_API.Dominio;
using Veiculo_API.Infra.Repositories;
using Veiculo_API.Infra.Repositories.Interfaces;

namespace Veiculo_API.Infra.Data;

public class UnityOfWork : IUnityOfWork
{
    private readonly ApiDbContext _context;

    public UnityOfWork(ApiDbContext context)
    {
        _context = context;
        Veiculos = new VeiculoRepository(_context, _context.Set<Veiculo>()); 
    }

    public IVeiculoRepository Veiculos { get; private set; }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync(); 
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
