using ControladorPedidos.App.Entities;

namespace ControladorPedidos.App.Presenters;

public record CriarClienteDto(string Nome, string Cpf, string Email)
{
    public static explicit operator Cliente(CriarClienteDto dto) => new()
    {
        Nome = dto.Nome,
        Cpf = dto.Cpf,
        Email = dto.Email
    };
}
