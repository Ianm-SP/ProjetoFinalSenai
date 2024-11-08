using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReal.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public bool Disponibilidade { get; set; } = true;

        public void Atualizar()
        {
            Console.WriteLine("Insira o novo título: ");
            Titulo = Console.ReadLine();

            Console.WriteLine("Insira o novo autor: ");
            Autor = Console.ReadLine();

            Console.WriteLine("Insira o novo ano de publicação: ");
            AnoPublicacao = int.Parse(Console.ReadLine());

            Console.WriteLine("Disponível para empréstimo? (s/n): ");
            Disponibilidade = Console.ReadLine().ToLower() == "s";
        }

        public void MostrarDetalhes()
        {
            Console.WriteLine($"ID: {Id}, Título: {Titulo}, Autor: {Autor}, Ano: {AnoPublicacao}, Disponível: {(Disponibilidade ? "Sim" : "Não")}");
        }

        public static Livro CriarLivro()
        {
            Livro livro = new Livro();
            Console.WriteLine("Insira o título: ");
            livro.Titulo = Console.ReadLine();

            Console.WriteLine("Insira o autor: ");
            livro.Autor = Console.ReadLine();

            Console.WriteLine("Insira o ano de publicação: ");
            livro.AnoPublicacao = int.Parse(Console.ReadLine());

            return livro;
        }
    }
}
