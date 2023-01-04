using System;
using System.Reflection.Metadata.Ecma335;

namespace ByteBank1
{

    public class Program
    {

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Quantia armazenada no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("Digite a opção desejada: ");
        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos, List<string> historico)
        {
            Console.Clear();
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Digite a senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0);
            historico.Add(null);
            Console.WriteLine("Usuario cadastrado!");
            Console.ReadKey();
        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos, List<string> historico)
        {
            Console.Clear();
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
            historico.RemoveAt(indexParaDeletar);

            Console.WriteLine("Conta deletada com sucesso");
            Console.ReadKey();
        }

        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Clear();
            for (int i = 0; i < cpfs.Count; i++)
            {
                ApresentaConta(i, cpfs, titulares, saldos);
            }
            Console.ReadKey();
        }

        static void ApresentarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
        {
            Console.Clear();
            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int index = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);
            bool conta, contaDestinatario = false;
            conta = VerificarConta(index, titulares, saldos, senhas);

            if (conta == true)
            {
                ApresentaConta(index, cpfs, titulares, saldos);
            }
            Console.ReadKey();
        }

        static void ApresentarValorAcumulado(List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine($"Total acumulado no banco: {saldos.Sum()}");
            // saldos.Sum(); ou .Agregatte(0.0, (x, y) => x + y)
        }

        static void ApresentaConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:F2}");
        }

        static bool VerificarConta(int index, List<string> titulares, List<double> saldos, List<string> senhas)
        {
            Console.Clear();
            string senha;
            bool c1 = false, contaFinal = false;

            if (index == -1)
            {
                Console.WriteLine("Não foi possível realizar o deposito");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
                return false;
            }
            else
            {
                
                int aux = 0;
                Console.Write("Digite a senha da conta (Você tera 3 (TRÊS) tentativas): ");
                senha = Console.ReadLine();
                while (c1 == false)
                {
                   
                    if (senhas[index] != senha )
                    {
                        aux++;
                        if (aux<=2)
                        {
                            Console.WriteLine($"Senha incorreta!, você tem ainda {3 - aux} tentativas.");
                            Console.WriteLine($"Cuidado você tem apenas {3 - aux} tentativas.");
                            Console.WriteLine("Digite a senha novamente: ");
                            senha = Console.ReadLine();
                        }
                        else if (aux == 3)
                        {
                            Console.WriteLine("Tentativas exedidas!");
                            Console.WriteLine("Logue novamente.");
                            c1=true;
                            contaFinal = false;
                            
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine($"Bem vindo(a) {titulares[index]} !");
                        c1 = true;
                        contaFinal = true;
                    }
                }
            }
            return contaFinal;
            Console.ReadKey();
        }

        static void RealizarDeposito(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas, List<string> historico)
        {
            Console.Clear();
            bool conta;           
            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int index = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);
            double valor = 0;
            conta = VerificarConta(index, titulares, saldos, senhas);

            if (conta == true)
            {               
                Console.Write("Digite o valor a ser depositado em conta: ");
                valor = double.Parse(Console.ReadLine());
                saldos[index] += valor;
                string deposito = ($"Deposito realizado no valor de {valor.ToString("F2")}");
                Console.WriteLine(deposito);                
                historico[index] += ($"\n{deposito} \n");
            }
            Console.ReadKey();
        }

        static void RealizarSaque(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas, List<string> historico)
        {
            Console.Clear();
            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int index = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);
            bool conta;
            double valor = 0;
            conta = VerificarConta(index, titulares, saldos, senhas);

            if (conta == true)
            {
                Console.Write("Digite o valor a ser sacado em conta: ");
                valor = double.Parse(Console.ReadLine());
            }

            if (saldos[index] < valor)
            {
                Console.WriteLine("Não foi possível realizar o saque");
                Console.WriteLine("MOTIVO: saldo a baixo do valor de sauqe.");
            }
            else
            {
                string saque;
                saldos[index] -= valor;
                saque = ($"Saque realizado no valor de {valor.ToString("F2")}");
                Console.WriteLine(saque);
                historico[index] += ($"\n{saque} \n");
            }
            Console.ReadKey();
        }
        static void RealizarTransferencia(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas, List<string> historico)
        {
            Console.Clear();
            Console.Write("Digite o cpf da conta que realizara transferencia: ");
            string cpfParaApresentar = Console.ReadLine();
            int index = cpfs.FindIndex(cpf => cpf == cpfParaApresentar), index2=-1;
           
            bool conta, contaDestinatario = false;
            conta = VerificarConta(index, titulares, saldos, senhas);
            double valor = 0;
            if (conta == true)
            {
                Console.Write("Digite o cpf da conta que recebera a transferencia: ");
                string cpfParaApresentar2 = Console.ReadLine();
                index2 = cpfs.FindIndex(cpf => cpf == cpfParaApresentar2);


                if (index2 == -1)
                {
                    Console.WriteLine("Não foi possível realizar a transferencia");
                    Console.WriteLine("MOTIVO: Conta do destinatario não encontrada.");
                }
                else
                {
                    Console.Write("Digite o valor a ser transferencia para a conta: ");
                    valor = double.Parse(Console.ReadLine());
                    contaDestinatario = true;
                }
                Console.ReadKey();

            }
            

            if (saldos[index] < valor && contaDestinatario == true)
            {
                Console.WriteLine("Não foi possível realizar a transferencia");
                Console.WriteLine("MOTIVO: saldo a baixo do valor de transferencia.");
            }
            else if(saldos[index] > valor && contaDestinatario == true)
            {
                saldos[index] -= valor;
                saldos[index2] += valor;
                string transferencia = ($"Transferencia Realizada no valor de {valor.ToString("F2")}");
                Console.WriteLine(transferencia);

                historico[index] += ($"\n{transferencia} \n");
            }
        }
        
        static void ExtratoConta(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas, List<string> historico)
        {
            Console.Clear();
            Console.Write("Digite o cpf da conta que sera realizado o extrato: ");
            string cpfParaApresentar = Console.ReadLine();
            int index = cpfs.FindIndex(cpf => cpf == cpfParaApresentar), index2 = -1;

            bool conta, contaDestinatario = false;
            conta = VerificarConta(index, titulares, saldos, senhas);
            if (conta == true)
            {
                Console.WriteLine(historico[index]);
            }
            Console.ReadKey();
        }

        static void MenuSecundario(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas, List<string> historico)
        {
            Console.Clear();
            Console.WriteLine("Digite Uma Opçao");
            int option = 0;
            
            while (option != 9)
            {
                Console.Clear();
                Console.WriteLine("1 - Realizar um deposito");
                Console.WriteLine("2 - Realizar um saque");
                Console.WriteLine("3 - Realizar uma transfêrencia");
                Console.WriteLine("4 - Mostrar extrato");
                Console.WriteLine("9 - Voltar ao menu anterios");

               
                    option = int.Parse(Console.ReadLine());

                        Console.WriteLine("-----------------");

                        switch (option)
                        {
                            case 9:
                                Console.WriteLine("Estou voltando ao menu principal...");
                                break;
                            case 1:
                                RealizarDeposito(cpfs, titulares, saldos, senhas, historico);
                                break;
                            case 2:
                                RealizarSaque(cpfs, titulares, saldos, senhas, historico);
                                break;
                            case 3:
                                RealizarTransferencia(cpfs, titulares, saldos, senhas, historico);
                                break;
                             case 4:
                                ExtratoConta(cpfs, titulares, saldos, senhas, historico);
                                break;

                        }
                    
                
            }
            Console.ReadKey();
        }

       
        public static void Main(string[] args)
        {

            Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores: ");

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();
            List<string> historico = new List<string>();


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
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos, historico);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, senhas, saldos, historico);
                        break;
                    case 3:
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        break;
                    case 4:
                        ApresentarUsuario(cpfs, titulares, saldos, senhas);
                        break;
                    case 5:
                        ApresentarValorAcumulado(saldos);
                        break;
                    case 6:
                        MenuSecundario(cpfs, titulares, saldos, senhas, historico);
                        break;
                }

                Console.WriteLine("-----------------");

            } while (option != 0);



        }

    }

}