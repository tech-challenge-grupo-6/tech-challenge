using Domain;
using Microsoft.Extensions.Logging;

namespace Application.UseCases;

public class ClienteUseCase(IClienteRepository clienteRepository, ILogger<ClienteUseCase> logger) : IClienteUseCase
{
  public async Task CriarAsync(Cliente cliente)
  {
    logger.LogInformation("Criando cliente");

    try
    {
      if (ClienteValidador.IsValid(cliente))
      {
        await clienteRepository.Add(cliente);
      }
    }
    catch (Exception ex)
    {
      logger.LogError(ex, "Erro ao criar cliente");
      throw;
    }
  }
  public async Task<Cliente> BuscarPorCpf(string cpf)
  {
    logger.LogInformation("Buscando cliente pelo cpf");

    try
    {
      if (CPFValidador.ValidarCpf(cpf))
      {
        var result = await clienteRepository.GetByCpf(cpf) ?? throw new NotFoundException("Cliente não encontrado");
        return result;
      }
      else
      {
        throw new ArgumentException("Cpf inválido");
      }
    }
    catch (Exception ex)
    {
      logger.LogError(ex, "Erro ao buscar cliente pelo cpf");
      throw;
    }

  }
}
