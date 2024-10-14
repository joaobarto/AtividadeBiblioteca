# Sistema de Gerenciamento de Biblioteca

Este é um sistema de gerenciamento de biblioteca desenvolvido em C#. O sistema permite que administradores cadastrem livros e usuários peguem livros emprestados ou devolvam livros, com um limite de até três livros por usuário.

## Funcionalidades

- **Administrador:**
  - Cadastrar novos livros na biblioteca.

- **Usuário:**
  - Pegar até 3 livros emprestados.
  - Devolver livros.

## Estrutura do Projeto

- **Classes:**
  - `Program`: Classe principal que contém a lógica do sistema.
  - `Livro`: Classe que representa um livro, com propriedades para autor, nome e gênero.

- **Listas e Dicionários:**
  - O sistema utiliza uma lista (`List<Livro>`) para armazenar os livros disponíveis.
  - Um dicionário (`Dictionary<string, int>`) armazena a contagem de livros emprestados por cada usuário.

