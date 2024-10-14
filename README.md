# Sistema de Gerenciamento de Biblioteca

Este é um sistema simples de gerenciamento de biblioteca desenvolvido em C#. O sistema permite que administradores cadastrem livros e usuários peguem livros emprestados ou devolvam livros.

## Funcionalidades

- **Administrador:**
  - Cadastrar novos livros na biblioteca.
  
- **Usuário:**
  - Pegar um livro emprestado.
  - Devolver um livro.

## Estrutura do Projeto

- **Classes:**
  - `Program`: Classe principal que contém a lógica do sistema.
  - `Livro`: Classe que representa um livro, com propriedades para autor, nome e gênero.

- **Listas:**
  - O sistema utiliza uma lista (`List<Livro>`) para armazenar os livros disponíveis.

