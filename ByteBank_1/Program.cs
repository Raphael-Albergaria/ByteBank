using System.Collections.Specialized;

namespace ByteBank_1;
class Program
{

    static void ShowMenu()
    {
        Console.WriteLine("Bem Vindo(a) ao ByteBank");
        Console.WriteLine();
        Console.WriteLine("Qual operação gostaria de realizar?");
        Console.WriteLine();
        Console.WriteLine("[1] - Inserir novo usuário");
        Console.WriteLine("[2] - Deletar um usuário");
        Console.WriteLine("[3] - Listar todas as contas registradas");
        Console.WriteLine("[4] - Detalhe de um usuário");
        Console.WriteLine("[5] - Quantia armazenada no banco");
        Console.WriteLine("[6] - Manipular a conta");
        Console.WriteLine("[0] - Para sair do programa");
        Console.WriteLine();
        Console.Write("Digite a opção desejada: ");
    }

    static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.Write("Digite seu CPF: ");
        string cpf = Console.ReadLine();
        if (cpfs.Contains(cpf))
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Esse CPF já está cadastrado.");
            Console.WriteLine();
            Console.WriteLine("O que gostaria de fazer?");
            Console.WriteLine("1 - Digitar novamente seu CPF");
            Console.WriteLine("2 - Voltar ao menu principal");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    RegistrarNovoUsuario(cpfs, titulares, saldos, senhas);
                    break;
                case 2:
                    ShowMenu();
                    break;
            }
        }
        else
        {
            cpfs.Add(cpf);
            Console.WriteLine();

            Console.Write("Digite seu Nome: ");
            titulares.Add(Console.ReadLine());
            Console.WriteLine();

            saldos.Add(0);

            Console.WriteLine("Digite sua senha: ");
            senhas.Add(Console.ReadLine());
            Console.WriteLine();
        }
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Conta criada com sucesso");
        Console.WriteLine("Agradecemos pela confiança!");
        Console.WriteLine("---------------------------------");
    }

    static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
    {
        Console.Clear();
        Console.Write("Digite seu CPF: ");
        string cpfParaDeletar = Console.ReadLine();
        int indexParaDeletar = cpfs.FindIndex(d => d == cpfParaDeletar);
        if (indexParaDeletar == -1)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Não foi possivel deletar essa conta.");
            Console.WriteLine("MOTIVO - Não foi possivel encontrar o cpf selecionado.");
            Console.WriteLine("---------------------------------");
        }
        else
        {
            Console.Write("Digite sua senha para confirmar a exclusão: ");
            string confirmacaoSenha = Console.ReadLine();

            if (confirmacaoSenha != senhas[indexParaDeletar])
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Não foi possivel deletar essa conta.");
                Console.WriteLine("MOTIVO - Senha incorreta");
                Console.WriteLine("---------------------------------");
                RedirecionarAoMenu();
                ShowMenu();

            }
            else
            {
                cpfs.RemoveAt(indexParaDeletar);
                titulares.RemoveAt(indexParaDeletar);
                saldos.RemoveAt(indexParaDeletar);
                senhas.RemoveAt(indexParaDeletar);
            }
        }
    }
    static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
    {
    Console.Clear();
        for (int i = 0; i < cpfs.Count; i++)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
            Console.WriteLine($"CPF = {cpfs[i]} | Titular = {titulares[i]} | Saldo = R${saldos[i]:f2}");
            Console.WriteLine();
        }
    }

    static void DetalheDeUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.Write("Digite o CPF para consulta: ");
        string cpf = Console.ReadLine();
        if (!cpfs.Contains(cpf))
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Não foi encontrado esse CPF.");
            Console.WriteLine();
            Console.WriteLine("O que gostaria de fazer?");
            Console.WriteLine("1 - Digitar novamente o CPF");
            Console.WriteLine("2 - Voltar ao menu principal");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    DetalheDeUsuario(cpfs, titulares, saldos);
                    break;
                case 2:
                    ShowMenu();
                    break;
            }
        }
        else
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
            int index = cpfs.FindIndex(d => d == cpf);
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:f2}");
            Console.WriteLine();
            Console.WriteLine("---------------------------------");

        }
    }

    static void QuantiaNoBanco(List<double> saldos)
    {
        Console.Clear();
        double quantia = 0;
        for (int i = 0; i < saldos.Count; i++)
        {
            quantia += saldos[i];
        }
        Console.WriteLine($"A quantia armazenada no ByteBank é R$ {quantia:F2}");
    }

    private static void ManipularConta(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
    {
        Console.Clear();
        Console.Write("Digite o CPF do titular da conta: ");
        string CpfParaManipulacao = Console.ReadLine();
        if (cpfs.Contains(CpfParaManipulacao))
        {
            int indexParaManipulacao = cpfs.FindIndex(d => d == CpfParaManipulacao);
            Console.Write("Digite sua senha para confirmar a manipulação: ");
            string confirmacaoSenha = Console.ReadLine();

            if (confirmacaoSenha != senhas[indexParaManipulacao])
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Não foi possivel acessar essa conta.");
                Console.WriteLine("MOTIVO - Senha incorreta");
                Console.WriteLine("---------------------------------");
                RedirecionarAoMenu();
                ManipularConta(cpfs, titulares, saldos, senhas);

            }
            MenuManipulacao(cpfs, titulares, saldos, indexParaManipulacao);

        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Não foi encontrado esse CPF.");
            Console.WriteLine();
            Console.WriteLine("O que gostaria de fazer?");
            Console.WriteLine("1 - Digitar novamente o CPF");
            Console.WriteLine("2 - Voltar ao menu principal");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    ManipularConta(cpfs, titulares, saldos, senhas);
                    break;
                case 2:
                    RedirecionarAoMenu();
                    ShowMenu();
                    break;
            }
        }
    }

    private static void MenuManipulacao(List<string> cpfs, List<string> titulares, List<double> saldos, int indexParaManipulacao)
    {
        Console.Clear();
        Console.WriteLine("O que gostaria de fazer?");
        Console.WriteLine("[1] - Depositar");
        Console.WriteLine("[2] - Sacar");
        Console.WriteLine("[3] - Transferir");
        Console.WriteLine("[0] - Voltar ao Menu anterior");
        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 0:
                RedirecionarAoMenu();
                ShowMenu();
                break;
            case 1:
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Nessa conta você possui R${saldos[indexParaManipulacao]:F2}");
                Console.WriteLine();
                Console.Write("Quando gostaria de depositar? ");
                double quantiaDeposito = double.Parse(Console.ReadLine());
                Console.WriteLine($"Você gostaria de depositar R${quantiaDeposito:F2}?");
                Console.WriteLine("1 - Sim | 2 - Não ");
                int confirmaDeposito = int.Parse(Console.ReadLine());
                if (confirmaDeposito == 1)
                {
                    saldos[indexParaManipulacao] += quantiaDeposito;
                    Console.WriteLine($"Foi depositado o valor de R${quantiaDeposito:F2} em sua conta.");
                    Console.WriteLine($"Agora seu saldo é R${saldos[indexParaManipulacao]:F2}");
                }
                else
                {
                    RedirecionarAoMenu();
                    MenuManipulacao(cpfs, titulares, saldos, indexParaManipulacao);
                }
                break;
            case 2:
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Nessa conta você possui R${saldos[indexParaManipulacao]:F2}");
                Console.WriteLine();
                Console.Write("Quando gostaria de sacar? ");
                double quantiaSaque = double.Parse(Console.ReadLine());
                Console.WriteLine($"Você gostaria de depositar R${quantiaSaque:F2}?");
                Console.WriteLine("1 - Sim | 2 - Não ");
                int confirmaSaque = int.Parse(Console.ReadLine());
                if (confirmaSaque == 1)
                {
                    if (saldos[indexParaManipulacao] < quantiaSaque)
                    {
                        Console.WriteLine("Saldo insuficiente para completar essa oeração.");
                        RedirecionarAoMenu();
                        MenuManipulacao(cpfs, titulares, saldos, indexParaManipulacao);

                    }
                    else
                    {
                        saldos[indexParaManipulacao] -= quantiaSaque;
                        Console.WriteLine($"Foi efetuado um saque no valor de R${quantiaSaque:F2} de sua conta.");
                        Console.WriteLine($"Agora seu saldo é R${saldos[indexParaManipulacao]:F2}");
                        RedirecionarAoMenu();
                        ShowMenu();
                    }
                }
                else
                {
                    RedirecionarAoMenu();
                    MenuManipulacao(cpfs, titulares, saldos, indexParaManipulacao);
                }
                break;
            case 3:
                Console.Write("Digite aqui o CPF da pessoa que gostaria: ");
                string cpfBeneficiario = Console.ReadLine();
                if (cpfs.Contains(cpfBeneficiario))
                {
                    int indexBeneficiario = cpfs.FindIndex(d => d == cpfBeneficiario);
                    Console.WriteLine();
                    Console.Write("Qual a quantia que gostaria de transferir? ");
                    double quantiaTransferencia = double.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine($"Você gostaria de transferir R${quantiaTransferencia:F2} para {titulares[indexBeneficiario]}. Confirma?");
                    Console.WriteLine("1 - Sim | 2 - Não ");
                    int confirmaTransferencia = int.Parse(Console.ReadLine());
                    if (confirmaTransferencia == 1)
                    {
                        if (saldos[indexParaManipulacao] < quantiaTransferencia)
                        {
                            Console.WriteLine("Saldo insuficiente para completar essa oeração.");
                            RedirecionarAoMenu();
                            MenuManipulacao(cpfs, titulares, saldos, indexParaManipulacao);

                        }
                        else
                        {
                            saldos[indexParaManipulacao] -= quantiaTransferencia;
                            saldos[indexBeneficiario] += quantiaTransferencia;

                            Console.WriteLine($"Foi efetuado uma transferencia no valor de R${quantiaTransferencia:F2} da sua conta.");
                            Console.WriteLine($"para a conta de {titulares[indexBeneficiario]}");
                            Console.WriteLine($"Agora seu saldo é R${saldos[indexParaManipulacao]:F2}");
                            RedirecionarAoMenu();
                            ShowMenu();
                        }
                    }
                    else
                    {
                        RedirecionarAoMenu();
                        MenuManipulacao(cpfs, titulares, saldos, indexParaManipulacao);
                    }

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Não foi encontrado esse CPF.");
                    Console.WriteLine();
                    RedirecionarAoMenu();
                    MenuManipulacao(cpfs, titulares, saldos, indexParaManipulacao);
                }

                break;
        }
    }

    static void RedirecionarAoMenu()
    {
        Console.WriteLine();
        Console.Write("Você será redirecionado ao menu anterior");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        return;
    }

    static void Main(string[] args)
    {
        List<string> cpfs = new List<string>();
        List<string> titulares = new List<string>();
        List<double> saldos = new List<double>();
        List<string> senhas = new List<string>();

        int option;

        do
        {
            ShowMenu();
            option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:
                        RegistrarNovoUsuario(cpfs, titulares, saldos, senhas);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, saldos, senhas);
                        break;
                    case 3:
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        break;
                    case 4:
                        DetalheDeUsuario(cpfs, titulares, saldos);
                        break;
                    case 5:
                        QuantiaNoBanco(saldos);
                        break;
                    case 6:
                        ManipularConta(cpfs, titulares, saldos, senhas);
                        break;

                }

                Console.WriteLine("-----------------");

        } while (option != 0);
    }
}

