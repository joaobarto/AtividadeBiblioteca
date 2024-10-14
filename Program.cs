using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Livro> livros = new List<Livro>();
        List<Usuario> usuarios = new List<Usuario>();
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("----------Biblioteca----------");
            Console.WriteLine("1- Administrador.");
            Console.WriteLine("2- Usuário.");
            Console.WriteLine("3- Sair.");

            if (int.TryParse(Console.ReadLine(), out int tipoConta))
            {
                switch (tipoConta)
                {
                    case 1:
                        Administrador(livros);
                        break;
                    case 2:
                        UsuarioMenu(livros, usuarios);
                        break;
                    case 3:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }

    static void Administrador(List<Livro> livros)
    {
        Console.Clear();
        Console.WriteLine("Cadastrar novo livro:");
        
        Console.Write("Título: ");
        string titulo = Console.ReadLine();
        
        Console.Write("Autor: ");
        string autor = Console.ReadLine();
        
        Console.Write("Gênero: ");
        string genero = Console.ReadLine();

        livros.Add(new Livro(titulo, autor, genero));
        Console.WriteLine("Livro cadastrado com sucesso!");

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void UsuarioMenu(List<Livro> livros, List<Usuario> usuarios)
    {
        Console.Write("Informe seu nome: ");
        string nome = Console.ReadLine();
        Usuario usuario = usuarios.Find(u => u.Nome == nome) ?? new Usuario(nome);
        
        if (!usuarios.Contains(usuario))
        {
            usuarios.Add(usuario);
        }

        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("1- Consultar catálogo.");
            Console.WriteLine("2- Pegar livro emprestado.");
            Console.WriteLine("3- Devolver livro.");
            Console.WriteLine("4- Sair.");

            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                switch (opcao)
                {
                    case 1:
                        ListarLivros(livros);
                        break;
                    case 2:
                        EmprestarLivro(usuario, livros);
                        break;
                    case 3:
                        DevolverLivro(usuario);
                        break;
                    case 4:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }

    static void ListarLivros(List<Livro> livros)
    {
        Console.WriteLine("Lista de Livros:");
        foreach (var livro in livros)
        {
            Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Gênero: {livro.Genero}, Disponível: {livro.QuantidadeDisponivel}");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void EmprestarLivro(Usuario usuario, List<Livro> livros)
    {
        if (usuario.LivrosEmprestados.Count >= 3)
        {
            Console.WriteLine("Limite de 3 livros emprestados atingido.");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            return;
        }

        Console.Write("Título do livro que deseja emprestar: ");
        string titulo = Console.ReadLine();
        Livro livro = livros.Find(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (livro != null && livro.QuantidadeDisponivel > 0)
        {
            usuario.LivrosEmprestados.Add(livro);
            livro.QuantidadeDisponivel--;
            Console.WriteLine("Livro emprestado com sucesso!");
        }
        else
        {
            Console.WriteLine("Livro não disponível ou não encontrado.");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void DevolverLivro(Usuario usuario)
    {
        if (usuario.LivrosEmprestados.Count == 0)
        {
            Console.WriteLine("Você não tem livros emprestados.");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            return;
        }

        Console.Write("Título do livro que deseja devolver: ");
        string titulo = Console.ReadLine();
        Livro livro = usuario.LivrosEmprestados.Find(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (livro != null)
        {
            usuario.LivrosEmprestados.Remove(livro);
            livro.QuantidadeDisponivel++;
            Console.WriteLine("Livro devolvido com sucesso!");
        }
        else
        {
            Console.WriteLine("Você não possui este livro emprestado.");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}

class Livro
{
    public string Titulo { get; }
    public string Autor { get; }
    public string Genero { get; }
    public int QuantidadeDisponivel { get; set; }

    public Livro(string titulo, string autor, string genero)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        QuantidadeDisponivel = 1;
    }
}

class Usuario
{
    public string Nome { get; }
    public List<Livro> LivrosEmprestados { get; } = new List<Livro>();

    public Usuario(string nome)
    {
        Nome = nome;
    }
}
