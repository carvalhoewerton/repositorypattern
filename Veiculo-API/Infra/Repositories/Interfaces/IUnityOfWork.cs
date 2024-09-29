namespace Veiculo_API.Infra.Repositories.Interfaces;

public interface IUnityOfWork
{
    IVeiculoRepository Veiculos { get; }
    Task CompleteAsync();
}