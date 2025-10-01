using FolhaDePagamento;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace FolhaDePagamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var funcionarios = new List<Funcionario>();

            char tipoFuncionario = '\0';
            String descricaoFuncionario = "";
            bool continua = true;
            Console.WriteLine("---- Cadastro de Funcionários ----");
            while (continua)
            {
                // definindo o tipo do funcionario a ser cadastrado
                Console.WriteLine();
                Console.WriteLine("Informe 'H' para Horista, 'A' para Assalariado, 'C' para Comissionado ou 'F' para finalizar o cadastro de Funcionários: ");
                String opcao = Console.ReadLine() ?? "";
                if (!String.IsNullOrEmpty(opcao))
                {
                    tipoFuncionario = char.ToUpper(opcao[0]);
                    if (tipoFuncionario == 'F')
                    {
                        continua = false;
                        continue;
                    }
                    else if (tipoFuncionario != 'H' && tipoFuncionario != 'A' && tipoFuncionario != 'C')
                    {
                        Console.WriteLine();
                        Console.WriteLine("Tipo de Funcionário inexistente. Tente novamente!");
                        continue;
                    }
                    else
                    {
                        // monta a descricao do tipo de funcionario para exibir na tela
                        descricaoFuncionario = "";
                        switch (tipoFuncionario)
                        {
                            case 'H':
                                descricaoFuncionario = "Horista";
                                break;

                            case 'A':
                                descricaoFuncionario = "Assalariado";
                                break;

                            default:
                                descricaoFuncionario = "Comissionado";
                                break;
                        }
                    }
                }

                // recebe os dados do funcionario e adiciona na lista
                Funcionario funcionario = RecebeDadosFuncionario(tipoFuncionario, descricaoFuncionario);
                funcionarios.Add(funcionario);
            }

            // exibe a lista de funcionarios cadastrados
            ExibirListaFuncionarios(funcionarios);

        }

        // recebe os dados do funcionario conforme o tipo e retorna o objeto do tipo Funcionario
        static Funcionario RecebeDadosFuncionario(char tipoFuncionario, string descricaoFuncionario)
        {
            Funcionario? funcionario = null;
            String nomeFuncionario = "";
            double salario = 0.0;
            bool temComissao = false;
            int qtdHoras = 0;
            bool continua = true;

            while (continua)
            {
                // recebendo o nome do funcionario
                Console.WriteLine();
                Console.WriteLine($"Funcionário do tipo {descricaoFuncionario}");
                Console.Write($"Informe o nome do funcionário:  ");
                nomeFuncionario = Console.ReadLine() ?? "";
                if (String.IsNullOrEmpty(nomeFuncionario))
                {
                    Console.WriteLine();
                    Console.WriteLine("O nome do funcionário não pode ser vazio. Tente novamente!");
                    continue;
                }

                // recebendo o salario do funcionario
                Console.Write($"Informe o salário de {nomeFuncionario}:  ");
                bool isConvertido = double.TryParse(Console.ReadLine(), out salario);
                if (!isConvertido)
                {
                    Console.WriteLine();
                    Console.WriteLine("O salário informado está incorreto. Tente novamente!");
                    continue;
                }
                else if (salario < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("O salário informado não pode ser negativo!");
                    continue;
                }
                else if (tipoFuncionario.Equals('C'))
                {
                    // define comissao
                    Console.Write($"Este funcionário tem comissão ('S'im ou 'N'ão): ");
                    String opcaoComissao = Console.ReadLine() ?? "";
                    temComissao = opcaoComissao.ToUpper().StartsWith('N') ? false : true;
                }
                else if (tipoFuncionario.Equals('H'))
                {
                    // define as horas trabalhadas
                    Console.Write($"Informe a quantidade de horas trabalhadas de {nomeFuncionario}: ");
                    qtdHoras = int.Parse(Console.ReadLine() ?? "0");
                }

                continua = false;
            }

            // cria os funcionarios conforme o tipo e armazena na variavel do tipo Funcionario
            switch (tipoFuncionario)
            {
                case 'H':
                    funcionario = new Horista(nomeFuncionario, salario, qtdHoras);
                    break;
                case 'A':
                    funcionario = new Assalariado(nomeFuncionario, salario);
                    break;
                default:
                    funcionario = new Comissionado(nomeFuncionario, salario, temComissao);
                    break;
            }

            // retorna o funcionario criado
            return funcionario;
        }

        // exibe a lista de funcionarios cadastrados e o total da folha de pagamento
        static void ExibirListaFuncionarios(List<Funcionario> funcionarios)
        {
            double totalFolhaPagamento = 0.0;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---- Lista de Funcionários ----");
            if (funcionarios.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Nenhum funcionário foi cadastrado!");
            }
            else
            {
                // apresenta a lista de Funcionarios
                foreach (Funcionario f in funcionarios)
                {
                    // Obtem o tipo do objeto cadastrado na lista (Horista, Assalariado ou Comissionado)
                    // imprime os dados do funcionario e acumula o valor da folha de pagamento conforme o tipo
                    System.Type tipo = f.GetType();
                    switch (tipo.Name)
                    {
                        case "Horista":
                            // recupera o objeto do tipo Horista da variavel do tipo Funcionario (realiza um cast)
                            Horista horista = (Horista) f;
                            
                            Console.WriteLine($"Funcionário {horista.Nome.ToUpper()}, Tipo: Horista, Salário: R$ {horista.RetornarSalario():F2}, Horas Trabalhadas: {horista.Horas}h");
                            
                            totalFolhaPagamento = totalFolhaPagamento + horista.RetornarSalario();
                            break;

                        case "Assalariado":
                            // recupera o objeto do tipo Assalariado da variavel do tipo Funcionario (realiza um cast)
                            Assalariado assalariado = (Assalariado) f;
                            Console.WriteLine($"Funcionário {assalariado.Nome.ToUpper()}, Tipo: Assalariado, Salário: R$ {assalariado.RetornarSalario():F2}");
                            
                            totalFolhaPagamento = totalFolhaPagamento + assalariado.RetornarSalario();
                            break;
                        default:
                            // recupera o objeto do tipo Comissionado da variavel do tipo Funcionario (realiza um cast)
                            Comissionado comissionado = (Comissionado)f;
                            Console.WriteLine($"Funcionário {comissionado.Nome.ToUpper()}, Tipo: Comissionado, Salário: R$ {comissionado.RetornarSalario():F2}, Tem Comissão: {(comissionado.Comissao ? "SIM":"Não")}");
                            
                            totalFolhaPagamento = totalFolhaPagamento + comissionado.RetornarSalario();
                            break;
                    }
                }
            }

            // apresenta o total da folha de pagamento
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---- Total da Folha de Pagamento ----");
            Console.WriteLine($"Valor da Folha no mês: R$ {totalFolhaPagamento:F2}");
        }
    }
}





