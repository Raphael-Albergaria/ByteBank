using System.Collections.Specialized;

namespace ByteBank_1;
class Program
{

    static void ShowMenu()
    {
        Console.WriteLine("1 - Inserir novo usuário");
        Console.WriteLine("2 - Deletar um usuário");
        Console.WriteLine("3 - Listar todas as contas registradas");
        Console.WriteLine("4 - Detalhe de um usuário");
        Console.WriteLine("5 - Quantia armazenado no banco");
        Console.WriteLine("6 - Manipular a conta");
        Console.WriteLine("0 - Para sair do programa");
        Console.Write("Digite a opção desejada: ");
    }

    static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
    {
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
    }

    static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
    {
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
                Console.WriteLine();
                Console.Write("Você será redirecionado ao menu principal");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
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
        double quantia = 0;
        for (int i = 0; i < saldos.Count; i++)
        {
            quantia += saldos[i];
        }
        Console.WriteLine($"A quantia armazenada no ByteBank é R$ {quantia:F2}");
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
                    break;

            }

            Console.WriteLine("-----------------");

        } while (option != 0);


    }

    
}

