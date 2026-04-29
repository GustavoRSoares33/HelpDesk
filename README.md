# Help Desk System

Este repositório contém uma solução completa de **Help Desk** desenvolvida para atender a uma necessidade real de gestão de suporte e, simultaneamente, servir como um projeto de aprimoramento técnico em desenvolvimento full-stack.

## Sobre o Projeto

O sistema foi concebido para centralizar e organizar o atendimento ao cliente, permitindo a abertura e o acompanhamento de tickets de suporte. A arquitetura foi pensada de forma modular, separando a lógica de dados das interfaces, o que permitiu explorar o desenvolvimento multiplataforma (Desktop e Web) utilizando uma base compartilhada.

### Estrutura do Repositório

* **AcessoDados:** Biblioteca de classes responsável pela persistência, modelos de dados e comunicação com o banco de dados.
* **HelpDesk.Desktop:** Aplicação administrativa robusta desenvolvida em **Windows Forms**, focada em alta produtividade para operadores internos.
* **HelpDesk.Web:** Interface leve e acessível desenvolvida com tecnologias web (**HTML/CSS/JS**), facilitando o acesso de usuários e clientes via navegador.
* **Backup Banco de Dados:** Scripts necessários para a replicação do ambiente de dados (SQL Server/MySQL).

## Tecnologias e Aprendizados

O desenvolvimento deste projeto permitiu aplicar e aprofundar conhecimentos em:

* **Linguagem:** C# e a plataforma .NET.
* **Desenvolvimento Desktop:** Construção de interfaces ricas com Windows Forms.
* **Desenvolvimento Web:** Integração de front-end estático com lógica de back-end.
* **Arquitetura de Software:** Separação em camadas (Layered Architecture).
* **Banco de Dados:** Modelagem e manipulação de dados com foco em integridade e performance.

## Funcionalidades Principais

* Gerenciamento centralizado de usuários e permissões.
* Fluxo completo de tickets (Abertura, Atendimento e Encerramento).
* Interface intuitiva para usuários finais e ferramentas avançadas para administradores.
* Histórico detalhado de solicitações para auditoria e controle.

## Como Executar

1. Clone o repositório:
   ```bash
   git clone [https://github.com/GustavoRSoares33/pim_4.git](https://github.com/GustavoRSoares33/pim_4.git)

2. Configure o banco de dados utilizando os scripts na pasta Backup Banco de Dados.

3. Abra a solução no Visual Studio.

4. Ajuste as strings de conexão no arquivo de configuração conforme sua instância local de banco de dados.

5. Execute o projeto HelpDesk.Desktop ou HelpDesk.Web para iniciar.
