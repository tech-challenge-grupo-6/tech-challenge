using Domain;

namespace ControladorPedidos;

public record CriarCategoriaProdutoDto(string Nome)
{
    public static explicit operator CategoriaProduto(CriarCategoriaProdutoDto dto) => new()
    {
        Nome = dto.Nome
    };
}
