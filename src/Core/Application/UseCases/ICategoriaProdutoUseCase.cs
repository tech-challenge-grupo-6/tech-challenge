using Domain;

namespace Application.UseCases
{
    public interface ICategoriaProdutoUseCase
    {
        Task CriarCategoriaAsync(CategoriaProduto categoria);
    }
}