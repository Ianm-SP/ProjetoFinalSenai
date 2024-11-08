using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReal.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string TipoUsuario { get; set; }  // "Regular" ou "Premium"
        public int LimiteEmprestimos { get; private set; }
        public int EmprestimosAtivos { get; set; } = 0;

        public Usuario(string nome, string tipoUsuario)
        {
            Nome = nome;
            TipoUsuario = tipoUsuario;
            LimiteEmprestimos = tipoUsuario == "Premium" ? 10 : 5;
        }

        public void Atualizar()
        {
            Console.WriteLine("Insira o novo nome: ");
            Nome = Console.ReadLine();

            Console.WriteLine("Insira o tipo de usuário (Regular/Premium): ");
            TipoUsuario = Console.ReadLine();
            LimiteEmprestimos = TipoUsuario == "Premium" ? 10 : 5;
        }

        public void MostrarDetalhes()
        {
            Console.WriteLine($"ID: {Id}, Nome: {Nome}, Tipo: {TipoUsuario}, Limite de Empréstimos: {LimiteEmprestimos}, Empréstimos Ativos: {EmprestimosAtivos}");
        }

        public static Usuario CriarUsuario()
        {
            Console.WriteLine("Insira o nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Insira o tipo de usuário (Regular/Premium): ");
            string tipoUsuario = Console.ReadLine();

            return new Usuario(nome, tipoUsuario);
        }
    }
}


