using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static List<Livro> biblioteca = new List<Livro>();

    static void Main()
    {
        bool opcaoc = true;

        while (opcaoc)
        {
            Console.Clear();
            Console.WriteLine("----------Biblioteca----------");
            Console.WriteLine("Escolha com qual tipo conta entrar:");
            Console.WriteLine("1- Administrador.");
            Console.WriteLine("2- Usuário.");
            Console.WriteLine("3- Sair.");
            
            if (int.TryParse(Console.ReadLine(), out int tipoConta))
            {
                switch (tipoConta)
                {
                    case 1: // Administrador
                        Console.WriteLine("Escolha o que deseja fazer:");
                        Console.WriteLine("1- Cadastrar novos livros.");
                        Console.WriteLine("2- Sair.");
                        
                        if (int.TryParse(Console.ReadLine(), out int opcaoadm))
                        {
                            switch (opcaoadm)
                            {
                                case 1: // Cadastrar novos livros
                                    CadastrarLivro();
                                    break;

                                case 2: // Sair
                                    Console.WriteLine("Saindo...");
                                    Thread.Sleep(1800);
                                    break;
                            }
                        }
                        break;

                    case 2: // Usuário
                        Console.WriteLine("Escolha o que deseja fazer:");
                        Console.WriteLine("1- Pegar um livro emprestado.");
                        Console.WriteLine("2- Devolver um livro.");
                        Console.WriteLine("3- Sair.");
                        
                        if (int.TryParse(Console.ReadLine(), out int opcaousu))
                        {
                            switch (opcaousu)
                            {
                                case 1: // Pegar um livro emprestado
                                    PegarEmprestado();
                                    break;

                                case 2: // Devolver um livro
                                    DevolverLivro();
                                    break;

                                case 3: // Sair
                                    opcaoc = false;
                                    break;
                            }
                        }
                        break;

                    case 3: // Sair
                        opcaoc = false;
                        break;
                }
            }
        }
    }

    static void CadastrarLivro()
    {
        Console.WriteLine("Autor do livro:");
        string autor = Console.ReadLine();
        Console.WriteLine("Nome do livro:");
        string nomel = Console.ReadLine();
        Console.WriteLine("Gênero do livro:");
        string generol = Console.ReadLine();

        biblioteca.Add(new Livro(autor, nomel, generol));
        Console.WriteLine("Livro cadastrado com sucesso!");
        Console.ReadLine(); // Pausa para visualizar a mensagem
    }

    static void PegarEmprestado()
    {
        Console.WriteLine("Livros disponíveis:");
        foreach (var livro in biblioteca)
        {
            Console.WriteLine($"Autor: {livro.Autor}, Nome: {livro.Nome}, Gênero: {livro.Genero}");
        }

        Console.WriteLine("Digite o nome do livro que deseja pegar emprestado:");
        string nomeLivro = Console.ReadLine();

        // Verifica se o livro está na biblioteca
        var livroEncontrado = biblioteca.Find(l => l.Nome.Equals(nomeLivro, StringComparison.OrdinalIgnoreCase));
        if (livroEncontrado != null)
        {
            biblioteca.Remove(livroEncontrado);
            Console.WriteLine($"Você pegou '{livroEncontrado.Nome}' emprestado com sucesso!");
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }

        Console.ReadLine(); // Pausa para visualizar a mensagem
    }

    static void DevolverLivro()
    {
        Console.WriteLine("Digite o nome do livro que deseja devolver:");
        string nomeLivro = Console.ReadLine();

        Console.WriteLine("Autor do livro:");
        string autor = Console.ReadLine();
        Console.WriteLine("Gênero do livro:");
        string genero = Console.ReadLine();

        // Adiciona o livro de volta à biblioteca
        biblioteca.Add(new Livro(autor, nomeLivro, genero));
        Console.WriteLine($"Você devolveu '{nomeLivro}' com sucesso!");
        Console.ReadLine(); // Pausa para visualizar a mensagem
    }
}

class Livro
{
    public string Autor { get; set; }
    public string Nome { get; set; }
    public string Genero { get; set; }

    public Livro(string autor, string nome, string genero)
    {
        Autor = autor;
        Nome = nome;
        Genero = genero;
    }
}
