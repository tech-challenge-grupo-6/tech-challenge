# Tech Challenge - Fase 01

## Contexto do Negócio

A lanchonete de bairro, devido ao seu sucesso crescente, está expandindo suas operações. No entanto, sem um sistema de controle de pedidos eficiente, o atendimento aos clientes pode ser caótico e resultar em insatisfação. Para solucionar esse problema, a lanchonete está investindo em um sistema de autoatendimento de fast food, com as seguintes funcionalidades:

## Entidades e Agregados

### Cliente

- Nome
- CPF
- E-mail

### Pedido

- Cliente (identificado ou não)
- Status (em progresso, pronto, finalizado)
- Itens do pedido (produtos selecionados)
- Valor total
- Método de pagamento (Sempre QR Code)

### Produto

- Nome
- Categoria
- Preço
- Descrição
- Imagens

### Categoria de Produto

- Nome

### Usuário

- Nome
- Login
- Senha
- Email

## Interfaces

### Interface do Cliente

#### Pedido

- Identificação (CPF, cadastro com nome e e-mail ou sem identificação).
- Seleção de produtos e montagem do combo.
- Exibição de nome, descrição e preço de cada produto.

#### Pagamento

- Opção de pagamento via QRCode do Mercado Pago.

#### Acompanhamento

- Visualização do progresso do pedido.

### Interface da Cozinha

#### Preparação de Pedidos

- Recebimento de pedidos confirmados e pagos.
- Etapas de preparação dos pedidos. (Alteração de status do pedido)
- Notificação de pedido pronto para retirada.

### Interface Administrativa

#### Gerenciar Clientes

- Identificação de clientes para campanhas promocionais.
- Criação de campanhas promocionais.

#### Gerenciar Produtos e Categorias

- Definição de produtos (nome, categoria, preço, descrição, imagens).

#### Acompanhamento de Pedidos

- Acompanhamento dos pedidos em andamento e tempo de espera de cada pedido.

#### Relatórios

- Emissão de relatórios gerais

## Considerações Finais

O sistema de controle de pedidos é essencial para a expansão da lanchonete, garantindo eficiência operacional e satisfação do cliente. Com a devida implementação das funcionalidades e domínios descritos neste documento, a lanchonete estará preparada para atender seus clientes de maneira eficiente e gerenciar seus pedidos e estoques de forma adequada. Isso contribuirá para o sucesso contínuo do negócio e a satisfação dos clientes.

## Domínios

Na solução proposta, podemos identificar os seguintes domínios:

### Subdomínio Principal:

- **Cliente**: Este é o domínio central da solução, pois envolve os clientes que fazem pedidos e pagamentos, representando a principal interação do sistema.

- **Pedido**: Este domínio está intimamente relacionado ao domínio principal (Cliente) e abrange todas as informações relacionadas aos pedidos dos clientes, incluindo itens do pedido, status e método de pagamento.

### Subdomínios de Suporte:

- **Produto e Categoria de Produto**: Esses domínios suportam o processo de seleção de produtos pelos clientes, fornecendo informações sobre os produtos disponíveis e suas categorias.

- **Cozinha**: O domínio da cozinha está relacionado ao processo de preparação dos pedidos e ao monitoramento do progresso.

- **Administrativo**: Este domínio oferece funcionalidades para gerenciar clientes, produtos, categorias e acompanhar pedidos.

### Subdomínio Genérico:

- **Pagamento**: Embora o pagamento esteja associado ao domínio principal (Cliente), ele pode ser considerado um domínio genérico, pois é uma funcionalidade comum em muitos sistemas, não exclusiva desta solução.
  Portanto, o domínio principal é o "Cliente", com os domínios de suporte sendo "Pedido", "Produto e Categoria de Produto", "Cozinha" e "Administrativo". O "Pagamento" pode ser considerado um domínio genérico.

## Linguagem Pictográfica

### Realização do pedido e pagamento

![realizacao-do-pedido-e-pagamento](https://private-user-images.githubusercontent.com/13970639/268142145-eef6dc56-ff1c-443a-af28-ad26c73c720f.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTEiLCJleHAiOjE2OTU5NDUzNDEsIm5iZiI6MTY5NTk0NTA0MSwicGF0aCI6Ii8xMzk3MDYzOS8yNjgxNDIxNDUtZWVmNmRjNTYtZmYxYy00NDNhLWFmMjgtYWQyNmM3M2M3MjBmLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFJV05KWUFYNENTVkVINTNBJTJGMjAyMzA5MjglMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjMwOTI4VDIzNTA0MVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTY2YzQ0MmU4YjVhNTMzNTk3Y2RlMmM4YjIyMTQxNzU1NmMwNjcwNTc4NDQ2ZjM3NDVhNWMwNmU2NTMzNzM3OTYmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.h4QpV0cHjtB-5CBoz6rtEJCOHBxXBoQB3zILGwjOGvI)

### preparação e entrega do pedido

![preparacao-e-entrega-do-pedido](https://private-user-images.githubusercontent.com/13970639/268142144-cd45f1b0-2e47-42f4-a93b-d3c8e0ac5e13.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTEiLCJleHAiOjE2OTU5NDUzNDEsIm5iZiI6MTY5NTk0NTA0MSwicGF0aCI6Ii8xMzk3MDYzOS8yNjgxNDIxNDQtY2Q0NWYxYjAtMmU0Ny00MmY0LWE5M2ItZDNjOGUwYWM1ZTEzLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFJV05KWUFYNENTVkVINTNBJTJGMjAyMzA5MjglMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjMwOTI4VDIzNTA0MVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPWY1MjNhMTQ4MjJjMWIxYjhjMGQxYjUyZjM4ODUyNDBhYTlhZDcwZDEzNTlmYzQ1ZWRkYjA1ZDBlOTNjNTNlMzkmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.o01n_zUeNs7b6nmV_xQYtv2hXWLKLbL4YGYfSAIh7aY)

### Event Storming

[Link Event Storming](https://www.figma.com/file/269hzIucolU1KCX7Ra60O8/Event-storming-Tech-Challenge?type=whiteboard&node-id=157-854&t=3aA0WQGTuEu5vvrv-4)
![event-storming](https://private-user-images.githubusercontent.com/13970639/271441392-5d6c9439-a8ed-4c03-8848-688c008bbecc.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTEiLCJleHAiOjE2OTU5NDU1NzYsIm5iZiI6MTY5NTk0NTI3NiwicGF0aCI6Ii8xMzk3MDYzOS8yNzE0NDEzOTItNWQ2Yzk0MzktYThlZC00YzAzLTg4NDgtNjg4YzAwOGJiZWNjLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFJV05KWUFYNENTVkVINTNBJTJGMjAyMzA5MjglMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjMwOTI4VDIzNTQzNlomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPWU4NTQ5ZjdlYTRlMTE5NjM1ZjA1NWRlNTU2Y2VmN2QzZTI5YzQwNWU2NTFkNDQxNTdhMDdkNjg1YjVmYzU5ZmYmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.HYOySq8UIZaK1BxHWYuvvw4jv960k_w8meN36S7Nch8)
