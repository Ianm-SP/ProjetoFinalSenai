using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheReal.Models;

namespace TheReal.Services
{
    public class BibliotecaService
    {
        private List<Livro> livros = new List<Livro>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Emprestimo> emprestimos = new List<Emprestimo>();
        private int livroIdCounter = 0;
        private int usuarioIdCounter = 0;

        public List<Emprestimo> Emprestimos => emprestimos;  // Propriedade pública para acessar a lista de empréstimos

        public void AdicionarLivro(Livro livro)
        {
            livro.Id = livroIdCounter++;
            livros.Add(livro);
        }

        public void ListarLivros()
        {
            foreach (var livro in livros)
            {
                livro.MostrarDetalhes();
            }
        }

        public Livro BuscarLivroPorId(int id)
        {
            return livros.Find(l => l.Id == id);
        }

        public void AtualizarLivro(Livro livro)
        {
            livro.Atualizar();
        }

        public void RemoverLivro(Livro livro)
        {
            livros.Remove(livro);
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            usuario.Id = usuarioIdCounter++;
            usuarios.Add(usuario);
        }

        public void ListarUsuarios()
        {
            foreach (var usuario in usuarios)
            {
                usuario.MostrarDetalhes();
            }
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            return usuarios.Find(u => u.Id == id);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            usuario.Atualizar();
        }

        public void RemoverUsuario(Usuario usuario)
        {
            usuarios.Remove(usuario);
        }

        public void EmprestarLivro(Usuario usuario, Livro livro, DateTime dataEmprestimo)
        {
            if (livro.Disponibilidade && usuario.EmprestimosAtivos < usuario.LimiteEmprestimos)
            {
                Emprestimo emprestimo = new Emprestimo(usuario, livro, dataEmprestimo);
                emprestimos.Add(emprestimo);
                livro.Disponibilidade = false;
                usuario.EmprestimosAtivos++;
                Console.WriteLine("Empréstimo realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Não é possível realizar o empréstimo. Verifique a disponibilidade do livro e o limite do usuário.");
            }
        }

        public void DevolverLivro(Emprestimo emprestimo, DateTime dataDevolucao)
        {
            emprestimo.RegistrarDevolucao(dataDevolucao);
            Console.WriteLine("Livro devolvido com sucesso!");
        }

        public void ListarEmprestimos()
        {
            foreach (var emprestimo in emprestimos)
            {
                emprestimo.MostrarDetalhes();
            }
        }
    }
}


