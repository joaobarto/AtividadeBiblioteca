# Sistema de Biblioteca

## Descrição do Projeto

Este projeto implementa um sistema de gerenciamento de biblioteca que permite a administração e os usuários interagirem com um catálogo de livros. O sistema permite que o administrador cadastre novos livros, enquanto os usuários podem emprestar e devolver livros, respeitando um limite de três empréstimos por usuário.

## Funcionalidades

### Administrador
- Cadastrar novos livros, especificando título, autor e gênero.
- Listar todos os livros disponíveis no catálogo.

### Usuário
- Consultar o catálogo da biblioteca.
- Pegar livros emprestados (até 3 por usuário).
- Devolver livros emprestados.

## Tecnologias Utilizadas
- **C#**: Linguagem de programação utilizada para desenvolver o sistema.
- **.NET**: Framework utilizado para executar o código.

## Estrutura do Código

O código é dividido em três classes principais:

1. **`Livro`**: Representa um livro com propriedades para título, autor, gênero e quantidade disponível.
2. **`Usuario`**: Representa um usuário da biblioteca, armazenando seu nome e uma lista de livros emprestados.
3. **`Program`**: Contém a lógica principal do sistema, incluindo menus e operações para administradores e usuários.

## Backlog

### Funcionalidades Futuras
- Adicionar persistência de dados (ex.: salvar em um banco de dados ou arquivo).
- Implementar um sistema de busca por título, autor ou gênero.
- Adicionar funcionalidades de avaliação e comentários para os livros.
- Permitir que os usuários visualizem seu histórico de empréstimos.

### Bugs Conhecidos
- Validação básica na entrada de dados do usuário.
- Mensagens de erro podem ser melhoradas para melhor usabilidade.

## Como Executar o Código

1. Clone o repositório:
   ```bash
   git clone <URL_DO_REPOSITORIO>
