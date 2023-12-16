using ControladorPedidos.App.Entities;

namespace ControladorPedidos.App.Presenters;

public record CriarEditarProdutoDto(string Nome, Guid CategoriaId, double Preco, string Descricao, string Imagem)
{
    public static explicit operator Produto(CriarEditarProdutoDto dto) => new()
    {
        Nome = dto.Nome,
        CategoriaId = dto.CategoriaId,
        Preco = dto.Preco,
        Descricao = dto.Descricao,
        Imagem = dto.Imagem,
    };
}
