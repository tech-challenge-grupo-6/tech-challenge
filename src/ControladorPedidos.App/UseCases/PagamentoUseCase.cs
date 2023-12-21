﻿using ControladorPedidos.App.Contracts;
using ControladorPedidos.App.Entities;
using ControladorPedidos.App.Entities.Repositories;
using ControladorPedidos.App.Entities.Shared;
using ControladorPedidos.App.Entities.Exceptions;

namespace ControladorPedidos.App.UseCases;

public class PagamentoUseCase(IPedidoRepository pedidoRepository, ILogger<PagamentoUseCase> logger, IPagamentoRepository pagamentoRepository) : IPagamentoUseCase
{
    public async Task EfetuarMercadoPagoQRCodeAsync(Guid pedidoId)
    {
        logger.LogInformation("Efetuando pagamento do pedido {PedidoId}", pedidoId);
        try
        {
            Pedido? pedido = await pedidoRepository.GetById(pedidoId);

            if (pedido is null)
            {
                logger.LogError("Pedido {PedidoId} não encontrado", pedidoId);
                throw new Exception($"Pedido {pedidoId} não encontrado");
            }

            if (pedido.Status != Status.Criado)
            {
                logger.LogError("Pedido {PedidoId} não pode ser pago", pedidoId);
                throw new Exception($"Pedido {pedidoId} não pode ser pago");
            }

            Pagamento pagamento = pedido.GerarPagamento(MetodoPagamento.MercadoPagoQRCode);

            //ToDo
            //Futuramente introduzir lógica de pagamento externo

            await pagamentoRepository.Add(pagamento);
            await pedidoRepository.UpdateStatus(pedido);

            logger.LogInformation("Pagamento do pedido {PedidoId} efetuado com sucesso", pedidoId);

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao efetuar pagamento do pedido {PedidoId}", pedidoId);
            throw;
        }
    }

    public async Task<Pagamento> ConsultarPagamentoPeloPedido(Guid pedidoId)
    {
        logger.LogInformation("Consultando status do pagamento do pedido");
        try
        {
            var result = await pagamentoRepository.GetByPedidoId(pedidoId) ?? throw new NotFoundException("Pagamento não encontrado.");
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao consultar status de pagamento do pedido {PedidoId}", pedidoId);
            throw;
        }
    }

}
