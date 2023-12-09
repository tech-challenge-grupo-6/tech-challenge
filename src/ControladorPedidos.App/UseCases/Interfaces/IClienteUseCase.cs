using ControladorPedidos.App.Entities;

namespace ControladorPedidos.App.UseCases.Interfaces;

public interface IClienteUseCase
{
  Task CriarAsync(Cliente cliente);
  Task<Cliente> BuscarPorCpf(string cpf);
}
