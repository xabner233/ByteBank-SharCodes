using System.Reflection.Metadata.Ecma335;

namespace ByteBank1
{

    public class Program
    {

        static void ShowMenu()
        {
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Quantia armazenada no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("Digite a opção desejada: ");
        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Digite a senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0);
        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfParaDeletar);

            if (indexParaDeletar == -1)
            {
                Console.WriteLine("Não foi possível deletar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }

            cpfs.Remove(cpfParaDeletar);
            titulares.RemoveAt(indexParaDeletar);
            senhas.RemoveAt(indexParaDeletar);
            saldos.RemoveAt(indexParaDeletar);

            Console.WriteLine("Conta deletada com sucesso");
        }

        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            for (int i = 0; i < cpfs.Count; i++)
            {
                ApresentaConta(i, cpfs, titulares, saldos);
            }
        }

        static void ApresentarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);

            if (indexParaApresentar == -1)
            {
                Console.WriteLine("Não foi possível apresentar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }

            ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);
        }

        static void ApresentarValorAcumulado(List<double> saldos)
        {
            Console.WriteLine($"Total acumulado no banco: {saldos.Sum()}");
            // saldos.Sum(); ou .Agregatte(0.0, (x, y) => x + y)
        }

        static void ApresentaConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:F2}");
        }

        static void RealizarDeposito(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int index = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);
            double valor = 0;
            if (index == -1)
            {
                Console.WriteLine("Não foi possível realizar o deposito");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }
            else
            {
                Console.Write("Digite o valor a ser depositado em conta: ");
                valor = double.Parse(Console.ReadLine());
                saldos[index] += valor;
                Console.WriteLine($"Deposito realizado no valor de {valor.ToString("F2")}");
            }

           
        }
        static void RealizarSaque(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int index = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);


            double valor = 0;
            if (index == -1)
            {
                Console.WriteLine("Não foi possível realizar o deposito");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }
            else
            {
                Console.Write("Digite o valor a ser depositado em conta: ");
                valor = double.Parse(Console.ReadLine());
            }

            if (saldos[index] < valor)
            {
                Console.WriteLine("Não foi possível realizar o deposito");
                Console.WriteLine("MOTIVO: saldo a baixo do valor de sauqe.");
            }
            else
            {
                saldos[index] -= valor;
                Console.WriteLine($"Deposito realizado no valor de {valor.ToString("F2")}");
            }
        }
        static void RealizarTransferencia(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o cpf da conta que realizara transferencia: ");
            string cpfParaApresentar = Console.ReadLine();
            int index = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);
            Console.Write("Digite o cpf da conta que recebera a transferencia: ");
            string cpfParaApresentar2 = Console.ReadLine();
            int index2 = cpfs.FindIndex(cpf => cpf == cpfParaApresentar2);

            double valor = 0;
            if (index == -1 || index2 == -1)
            {
                Console.WriteLine("Não foi possível realizar a transferencia");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }
            else
            {
                Console.Write("Digite o valor a ser transferencia para a conta: ");
                valor = double.Parse(Console.ReadLine());
            }

            if (saldos[index] < valor)
            {
                Console.WriteLine("Não foi possível realizar a transferencia");
                Console.WriteLine("MOTIVO: saldo a baixo do valor de transferencia.");
            }
            else
            {
                saldos[index] -= valor;
                saldos[index] -= valor;
                saldos[index2] += valor;
                Console.WriteLine($"Transferencia Realizada no valor de {valor.ToString("F2")}");
                
                
            }
        }

        static void MenuSecundario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.WriteLine("Digite Uma Opçao");
            int option = 0;
            
            while (option != 9)
            {
                Console.WriteLine("1 - Realizar um deposito");
                Console.WriteLine("2 - Realizar um saque");
                Console.WriteLine("3 - Realizar uma transfêrencia");
                Console.WriteLine("9 - Voltar ao menu anterios");

               
                    option = int.Parse(Console.ReadLine());

                        Console.WriteLine("-----------------");

                        switch (option)
                        {
                            case 9:
                                Console.WriteLine("Estou voltando ao menu principal...");
                                break;
                            case 1:
                                RealizarDeposito(cpfs, titulares, saldos);
                                break;
                            case 2:
                                RealizarSaque(cpfs, titulares, saldos);
                                break;
                            case 3:
                                RealizarTransferencia(cpfs, titulares, saldos);
                                break;

                        }
                    
                
            }
        }

       
        public static void Main(string[] args)
        {

            Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores: ");

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            int option;

            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine());

                Console.WriteLine("-----------------");

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        break;
                    case 4:
                        ApresentarUsuario(cpfs, titulares, saldos);
                        break;
                    case 5:
                        ApresentarValorAcumulado(saldos);
                        break;
                    case 6:
                        MenuSecundario(cpfs, titulares, saldos);
                        break;
                }

                Console.WriteLine("-----------------");

            } while (option != 0);



        }

    }

}