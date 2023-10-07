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
}
