using System;
using TheReal.Models;
using TheReal.Services;

namespace TheReal
{
    class Program
    {
        static void Main(string[] args)
        {
            BibliotecaService bibliotecaService = new BibliotecaService();
            bool executando = true;

            while (executando)
            {
                Console.Clear();  // Limpa o console antes de exibir o menu

                Console.WriteLine("--- Sistema de Gerenciamento da Biblioteca ---");
                Console.WriteLine("1. Adicionar Livro");
                Console.WriteLine("2. Listar Livros");
                Console.WriteLine("3. Atualizar Livro");
                Console.WriteLine("4. Remover Livro");
                Console.WriteLine("5. Adicionar Usuário");
                Console.WriteLine("6. Listar Usuários");
                Console.WriteLine("7. Atualizar Usuário");
                Console.WriteLine("8. Remover Usuário");
                Console.WriteLine("9. Emprestar Livro");
                Console.WriteLine("10. Devolver Livro");
                Console.WriteLine("11. Listar Empréstimos");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Livro novoLivro = Livro.CriarLivro();
                        bibliotecaService.AdicionarLivro(novoLivro);
                        Console.WriteLine("Livro adicionado com sucesso!");
                        break;
                    case "2":
                        bibliotecaService.ListarLivros();
                        break;
                    case "3":
                        Console.Write("Insira o ID do livro para atualizar: ");
                        int idLivroAtualizar = int.Parse(Console.ReadLine());
                        Livro livroAtualizar = bibliotecaService.BuscarLivroPorId(idLivroAtualizar);
                        if (livroAtualizar != null)
                        {
                            bibliotecaService.AtualizarLivro(livroAtualizar);
                            Console.WriteLine("Livro atualizado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                        break;
                    case "4":
                        Console.Write("Insira o ID do livro para remover: ");
                        int idLivroRemover = int.Parse(Console.ReadLine());
                        Livro livroRemover = bibliotecaService.BuscarLivroPorId(idLivroRemover);
                        if (livroRemover != null)
                        {
                            bibliotecaService.RemoverLivro(livroRemover);
                            Console.WriteLine("Livro removido com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                        break;
                    case "5":
                        Usuario novoUsuario = Usuario.CriarUsuario();
                        bibliotecaService.AdicionarUsuario(novoUsuario);
                        Console.WriteLine("Usuário adicionado com sucesso!");
                        break;
                    case "6":
                        bibliotecaService.ListarUsuarios();
                        break;
                    case "7":
                        Console.Write("Insira o ID do usuário para atualizar: ");
                        int idUsuarioAtualizar = int.Parse(Console.ReadLine());
                        Usuario usuarioAtualizar = bibliotecaService.BuscarUsuarioPorId(idUsuarioAtualizar);
                        if (usuarioAtualizar != null)
                        {
                            usuarioAtualizar.Atualizar();
                            Console.WriteLine("Usuário atualizado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Usuário não encontrado.");
                        }
                        break;
                    case "8":
                        Console.Write("Insira o ID do usuário para remover: ");
                        int idUsuarioRemover = int.Parse(Console.ReadLine());
                        Usuario usuarioRemover = bibliotecaService.BuscarUsuarioPorId(idUsuarioRemover);
                        if (usuarioRemover != null)
                        {
                            bibliotecaService.RemoverUsuario(usuarioRemover);
                            Console.WriteLine("Usuário removido com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Usuário não encontrado.");
                        }
                        break;
                    case "9":
                        Console.Write("Insira o ID do usuário que deseja fazer o empréstimo: ");
                        int idUsuarioEmprestimo = int.Parse(Console.ReadLine());
                        Usuario usuarioEmprestimo = bibliotecaService.BuscarUsuarioPorId(idUsuarioEmprestimo);
                        if (usuarioEmprestimo != null)
                        {
                            Console.Write("Insira o ID do livro para emprestar: ");
                            int idLivroEmprestimo = int.Parse(Console.ReadLine());
                            Livro livroEmprestimo = bibliotecaService.BuscarLivroPorId(idLivroEmprestimo);
                            if (livroEmprestimo != null && livroEmprestimo.Disponibilidade)
                            {
                                bibliotecaService.EmprestarLivro(usuarioEmprestimo, livroEmprestimo, DateTime.Now);
                            }
                            else
                            {
                                Console.WriteLine("Livro indisponível ou não encontrado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Usuário não encontrado.");
                        }
                        break;
                    case "10":
                        Console.Write("Insira o ID do usuário que deseja devolver o livro: ");
                        int idUsuarioDevolucao = int.Parse(Console.ReadLine());
                        Usuario usuarioDevolucao = bibliotecaService.BuscarUsuarioPorId(idUsuarioDevolucao);
                        if (usuarioDevolucao != null)
                        {
                            Console.Write("Insira o ID do livro a ser devolvido: ");
                            int idLivroDevolucao = int.Parse(Console.ReadLine());
                            Livro livroDevolucao = bibliotecaService.BuscarLivroPorId(idLivroDevolucao);
                            Emprestimo emprestimo = bibliotecaService.Emprestimos.Find(e => e.Usuario == usuarioDevolucao && e.Livro == livroDevolucao && e.DataDevolucao == null);

                            if (emprestimo != null)
                            {
                                bibliotecaService.DevolverLivro(emprestimo, DateTime.Now);
                            }
                            else
                            {
                                Console.WriteLine("Empréstimo não encontrado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Usuário não encontrado.");
                        }
                        break;
                    case "11":
                        bibliotecaService.ListarEmprestimos();
                        break;
                    case "0":
                        executando = false;
                        Console.WriteLine("Saindo do sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }

                // Espera o usuário pressionar Enter antes de limpar o console
                Console.WriteLine("\nPressione Enter para voltar ao menu principal...");
                Console.ReadLine();
            }
        }
    }
}
