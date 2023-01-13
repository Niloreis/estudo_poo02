using ProjetoAula02.Entities;
using ProjetoAula02.Repository;
using System.Reflection.Metadata;

namespace ProjetoAula02
{
    ///\<summary>
    ///classe de inicialização do projeto
    ///</summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n ***CADASTRO DE FUNCIONARIO***\n");

            var funcionario = new Funcionario();
            funcionario.Funcao = new Funcao();

            try
            {
                funcionario.Id = Guid.NewGuid();
                funcionario.Funcao.Id = Guid.NewGuid();

                Console.Write("INFORME O NOME DO FUNCIONARIO...:");
                funcionario.Nome = Console.ReadLine();

                Console.Write("INFORME O CPF DO FUNCIONARIO...:");
                funcionario.Cpf = Console.ReadLine();

                Console.Write("INFORME A MATRICULA DO FUNCIONARIO...:");
                funcionario.Matricula = Console.ReadLine();

                Console.Write("INFORME A DATA DE ADIMISSSÃO DO FUNCIONARIO...:");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                Console.Write("INFORME A DESCRIÇÃO DA FUNÇÃO..:");
                funcionario.Funcao.Descricao = Console.ReadLine();


                Console.WriteLine("\n DADOS DO FUNCIONÁRIO:");
                Console.WriteLine($"\nID......:{funcionario.Id}");
                Console.WriteLine($"\nNOME......:{funcionario.Nome}");
                Console.WriteLine($"\nCPF......:{funcionario.Cpf}");
                Console.WriteLine($"\nMATRICULA......:{funcionario.Matricula}");
                Console.WriteLine($"\nDATA DE AMISSÃO......:{funcionario.DataAdmissao}");
                Console.WriteLine($"\nID DA FUNÇÃO ......:{funcionario.Funcao.Id}");
                Console.WriteLine($"\nDESCRIÇÃO ......:{funcionario.Funcao.Descricao}");

                Console.Write("\n ESCOLHA (1)JASON OU (2)XML....:");
                var opcao= int.Parse(Console.ReadLine());

                //crindo um obnjeto para a classe  FuncionarioRepositoty//
                var funcionarioRepository = new FuncionarioRepository();

                switch (opcao)
                {
                    case 1:
                        funcionarioRepository.ExportarJson(funcionario);
                        Console.WriteLine("\nARQUIVO JSON GRAVADO COM SUCESSO!");

                        break;

                    case 2:
                        funcionarioRepository.ExportarXml(funcionario);
                        Console.WriteLine("\nARQUIVO XML GRAVADO COM SUCESSO!");
                        break;

                        default:
                        Console.WriteLine("\nOPÇÃO INVÁLIDA.");
                        break;

                        
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\n ERRO DE VALIDAÇÃO");
                Console.WriteLine(e.Message);

                Console.WriteLine("\n DESEJA TENTE NOVAMENTE? (S,N)");
                var opcao =Console.ReadLine();

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    Main(args);
                }
                else
                {
                    Console.WriteLine("FIM!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\n FALHA AO EXECUTAR O PROGRAMA:");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Console.ReadKey();
        }

    }

}