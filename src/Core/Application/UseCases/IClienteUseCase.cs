using Domain;

namespace Application.UseCases;

public interface IClienteUseCase
{
  Task CriarAsync(Cliente cliente);
  Task<Cliente> BuscarPorCpf(string cpf);
}