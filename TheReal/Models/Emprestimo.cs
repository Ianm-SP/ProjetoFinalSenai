using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReal.Models
{
    public class Emprestimo
    {
        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public Emprestimo(Usuario usuario, Livro livro, DateTime dataEmprestimo)
        {
            Usuario = usuario;
            Livro = livro;
            DataEmprestimo = dataEmprestimo;
        }

        public void RegistrarDevolucao(DateTime dataDevolucao)
        {
            DataDevolucao = dataDevolucao;
            Livro.Disponibilidade = true;
            Usuario.EmprestimosAtivos--;
        }

        public void MostrarDetalhes()
        {
            Console.WriteLine($"Usuário: {Usuario.Nome}, Livro: {Livro.Titulo}, Data Empréstimo: {DataEmprestimo}, Data Devolução: {DataDevolucao?.ToShortDateString() ?? "Ainda emprestado"}");
        }
    }
}


