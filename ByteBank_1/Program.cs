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
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;

            }

            Console.WriteLine("-----------------");

        } while (option != 0);


    }

    
}

