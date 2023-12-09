using ControladorPedidos.App.Entities;

namespace ControladorPedidos.App.Presenters;

public record CriarCategoriaProdutoDto(string Nome)
{
    public static explicit operator CategoriaProduto(CriarCategoriaProdutoDto dto) => new()
    {
        Nome = dto.Nome
    };
}
