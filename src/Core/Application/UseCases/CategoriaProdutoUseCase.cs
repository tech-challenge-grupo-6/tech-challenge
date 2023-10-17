using Domain;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class CategoriaProdutoUseCase : ICategoriaProdutoUseCase
    {
        private readonly ICategoriaProdutoRepository _categoriaRepository;

        public CategoriaProdutoUseCase(ICategoriaProdutoRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task CriarCategoriaAsync(CategoriaProduto categoria)
        {
            try
            {
                if (CategoriaProdutoValidador.IsValid(categoria))
                {
                    await _categoriaRepository.Add(categoria);
                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }
    }
}
