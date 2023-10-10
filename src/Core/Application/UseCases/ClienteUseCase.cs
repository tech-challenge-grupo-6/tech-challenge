using Domain;
using Microsoft.Extensions.Logging;

namespace Application.UseCases;

public class ClienteUseCase : IClienteUseCase
{
  private readonly IClienteRepository _clienteRepository;
  private readonly ILogger<ClienteUseCase> _logger;

  public ClienteUseCase(IClienteRepository clienteRepository, ILogger<ClienteUseCase> logger)
  {
    _clienteRepository = clienteRepository;
    _logger = logger;
  }

  public async Task CriarAsync(Cliente cliente)
  {
    _logger.LogInformation("Criando cliente");

    try
    {
      if (ClienteValidador.IsValid(cliente))
      {
        await _clienteRepository.Add(cliente);
      }
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Erro ao criar cliente");
      throw;
    }
  }
  public async Task<Cliente> BuscarPorCpf(string cpf)
  {
    _logger.LogInformation("Buscando cliente pelo CPF");

    try
    {
      if (CPFValidador.ValidarCpf(cpf))
      {
        var result = await _clienteRepository.GetByCpf(cpf) ?? throw new NotFoundException("Cliente não encontrado");
        return result;
      }
      return null;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Erro ao buscar cliente pelo cpf");
      throw;
    }

  }
}
