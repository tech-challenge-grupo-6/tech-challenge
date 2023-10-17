using Domain;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class CategoriaProdutoUseCase : ICategoriaProdutoUseCase
    {
        private readonly ICategoriaProdutoRepository _categoriaRepository;
        private readonly ILogger<CategoriaProdutoUseCase> _logger;

        public CategoriaProdutoUseCase(ICategoriaProdutoRepository categoriaRepository, ILogger<CategoriaProdutoUseCase> logger)
        {
            _categoriaRepository = categoriaRepository;
            _logger = logger;
        }

        public async Task CriarCategoriaAsync(CategoriaProduto categoria)
        {
            _logger.LogInformation("Criando categoria de produto");

            try
            {
                if (CategoriaProdutoValidador.IsValid(categoria))
                {
                    await _categoriaRepository.Add(categoria);
                }
                else
                {
                    _logger.LogError("Categoria de produto inválida");
                    throw new ArgumentException("Categoria de produto inválida");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar categoria de produto");
                throw;
            }
        }
    }
}
