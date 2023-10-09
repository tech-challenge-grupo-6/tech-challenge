using Domain;

namespace ControladorPedidos;

public record CriarClienteDto(string Nome, string Cpf, string Email)
{
    public static explicit operator Cliente(CriarClienteDto dto) => new()
    {
        Nome = dto.Nome,
        Cpf = dto.Cpf,
        Email = dto.Email
    };
}
