# Fluxo de Eventos da Lanchonetes (Totem)

## Grupo 6: 
- RM350836 (3SOAT): Marcio Lages Silva - marciolages@msn.com
- RM351061 (3SOAT): Renan Silva Xavier - renansx2013@hotmail.com 
- RM351631 (3SOAT): Victor Sadao Higa Nagahara - viih.higa@gmail.com
- RM351041 (3SOAT): Vitor de Souza - vitordesolza@gmail.com

Repositório: https://github.com/RenanSX/tech-challenge

Event Storm: [Link para Figma](https://www.figma.com/file/269hzIucolU1KCX7Ra60O8/Event-storming-Tech-Challenge?type=whiteboard&node-id=103-111)

Diagramas Linguagem Ubíqua: [Link para diagramas](https://github.com/RenanSX/tech-challenge/tree/main/documentation/linguagem-ubiuqua)

Swagger (localhost): [Link para Swagger](http://localhost:5003/swagger/index.html)
> Para acessar o Swagger, é necessário rodar o projeto e acessar o link acima.

Postman Collections: [Link para Postman Collections](https://github.com/RenanSX/tech-challenge/tree/main/documentation/postman)

## Fluxo de Eventos

### Contexto: Identificação do Cliente

> ATENÇÃO: Os IDs usados nos exemplos abaixo são IDs gerados pelo sistema, portanto, os IDs podem ser diferentes dos exemplos.

1. O cliente realiza seu cadastro
    - Postman endpoint: Tech Challenge -> Cliente -> Criar POST
    - Swagger endpoint: Cliente -> POST
    - Ex:
        ```bash
        curl --location 'http://localhost:5003/Cliente' \
        --header 'accept: */*' \
        --header 'Content-Type: application/json' \
        --data-raw '{
        "nome": "Teste",
        "cpf": "96828696840",
        "email": "ko50f@fjsku.com"
        }'
        ```

2. Clientes cadastrados podem buscar suas informações pelo CPF
    - Postman endpoint: Tech Challenge -> Cliente -> Buscar por CPF GET
    - Swagger endpoint: Cliente/{cpf} -> GET
    - Ex:
        ```bash
        curl --location 'http://localhost:5003/Cliente/35042084061' \
        --header 'accept: */*'
        ```

### Contexto: Realização de Pedido

1. O cliente inicia seu pedido, o sistema busca as informações das categorias de produtos
    - Postman endpoint: Tech Challenge -> CategoriaProduto -> Listar GET
    - Swagger endpoint: CategoriaProduto -> GET
    - Ex:
        ```bash
        curl --location 'http://localhost:5003/CategoriaProduto' \
        --header 'accept: */*'
        ```
2. O cliente seleciona a categoria de produto desejada e o sistema lista os produtos conforme a categoria selecionada
    - Postman endpoint: Tech Challenge -> Produto -> Listar por Categoria GET
    - Swagger endpoint: Produto/{categoriaId} -> GET
    - Ex:
        ```bash
        curl --location 'http://localhost:5003/Produto/3635150d-02f2-4311-b97a-0b9f29593db8' \
        --header 'accept: */*'
        ```

3. O cliente seleciona os produtos desejados e o sistema relaciona os ids para criar o pedido
    - Postman endpoint: Tech Challenge -> Pedido -> Criar POST
    - Swagger endpoint: Pedido -> POST
    - Ex:
        ```bash
        # precisamos adicionar um exemplo aqui
        ```

4. O sistema busca as informações do pedido para visualização
    - Postman endpoint: Tech Challenge -> Pedido -> Listar GET
    - Swagger endpoint: Pedido -> GET
    - Ex:
        ```bash
        curl --location 'http://localhost:5003/Pedido' \
        --header 'accept: */*'
        ```

### Contexto: Pagamento do Pedido

1. O cliente inicia a operação de pagamento e o sistema usa o ID do pedido para realizar a operação
    - Postman endpoint: Tech Challenge -> Pagamento -> Pagar Pedido PUT
    - Swagger endpoint: Pagamento/pagar/{pedidoId} -> PUT
    - Ex:
        ```bash
        curl --location --request PUT 'http://localhost:5003/Pagamento/pagar/228e61bc-9f42-4a4f-95f5-521068e0c682' \
        --header 'accept: */*'
        ```

### Contexto: Cozinha prepara o pedido

1. A cozinha recebe o pedido pago e indica no sistema o início de sua preparação
    - Postman endpoint: Tech Challenge -> Pedido -> Por em progresso PATCH
    - Swagger endpoint: Pedido/{id}/status/emprogresso -> PATCH
    - Ex:
        ```bash
        curl --location --request PATCH 'http://localhost:5003/Pedido/228e61bc-9f42-4a4f-95f5-521068e0c682/status/emprogresso' \
        --header 'accept: */*'
        ```

2. A cozinha indica no sistema o fim da preparação do pedido
    - Postman endpoint: Tech Challenge -> Pedido -> Mudar para pronto PATCH
    - Swagger endpoint: Pedido/{id}/status/pronto -> PATCH
    - Ex:
        ```bash
        curl --location --request PATCH 'http://localhost:5003/Pedido/228e61bc-9f42-4a4f-95f5-521068e0c682/status/pronto' \
        --header 'accept: */*'
        ```

### Contexto: Entrega do Pedido

1. O cliente retira seu pedido concluído com o atendente que sinaliza no sistema a finalização do pedido
    - Postman endpoint: Tech Challenge -> Pedido -> Finalizar PATCH
    - Swagger endpoint: Pedido/{id}/status/finalizado -> PATCH
    - Ex:
        ```bash
        curl --location --request PATCH 'http://localhost:5003/Pedido/228e61bc-9f42-4a4f-95f5-521068e0c682/status/finalizado' \
        --header 'accept: */*'
        ```