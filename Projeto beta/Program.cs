internal class Program
{
    private static void Main(string[] args)
    {
        string messagem = "Seja bem vindo a Screen Sound";
        int opcao;
        
        //List<string> listaBandas = new List<string> {"Arctic Monkeys", "Twenty One Pilots" };
        Dictionary <string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
        bandasRegistradas.Add("Linkin Park", new List<int> {10, 9, 8, 10});
        bandasRegistradas.Add("Beatles", new List<int>());

        void MensagemDeBoasVindas()
        {
            Console.WriteLine(@"

    ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
    ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
    ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
    ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
    ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
    ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
            Console.WriteLine(messagem);
        }

        void MenuDeOpcoes()
        {
            Console.Clear();
            MensagemDeBoasVindas();
            Console.WriteLine("\nDigite 1 para registrar uma banda");
            Console.WriteLine("Digite 2 para mostrar todas as bandas");
            Console.WriteLine("Digite 3 para avaliar uma banda");
            Console.WriteLine("Digite 4 para exibir a média de uma banda");
            Console.WriteLine("Digite -1 para sair");

            Console.Write("Digite sua opção: ");
            opcao = int.Parse(Console.ReadLine()!);

            switch (opcao)
            {
                case 1:
                    RegistrarBanda();
                    break;
                case 2:
                    MostrarBandas();
                    break;
                case 3:
                    AvaliarBanda();
                    break;
                case 4:
                    MediaBanda();
                    break;
                case -1:
                    Console.WriteLine($"Você digitou a opção {opcao}");
                    break;
                default:
                    Console.WriteLine("Opção invalida");
                    break;
            }
        }

        void TituloDeOpcoes(string titulo)
        {
            int vQuantidadeCaracteres = titulo.Length;
            string vAsteriscos = string.Empty.PadLeft(vQuantidadeCaracteres, '*');
            Console.WriteLine(vAsteriscos);
            Console.WriteLine(titulo);
            Console.WriteLine(vAsteriscos + "\n");

        }

        void RegistrarBanda()
        {
            string nomeDaBanda;
            Console.Clear();
            TituloDeOpcoes("Registro das Bandas");
            Console.Write("\nDigite a banda que deseja registrar: ");
            nomeDaBanda = Console.ReadLine()!;
            bandasRegistradas.Add(nomeDaBanda, new List<int>());
            Console.WriteLine($"{nomeDaBanda} foi registrado com sucesso");
            Thread.Sleep(2000);
            MenuDeOpcoes();
        }

        void MostrarBandas()
        {
            Console.Clear();
            TituloDeOpcoes("Mostrar Bandas");
            /*
            for(int i = 0; i < listaBandas.Count; i++)
            {
                Console.WriteLine(listaBandas[i]);
            }
            */

            foreach(var banda in bandasRegistradas.Keys) 
            {
                Console.WriteLine($"Banda: {banda} ");
            }
            Console.WriteLine("\nPrecione qualquer tecla para voltar ao menu");
            Console.ReadKey();
            MenuDeOpcoes();
        }

        void AvaliarBanda()
        {
            Console.Clear();
            TituloDeOpcoes("Avaliar banda");

            Console.Write("Qual Banda você deseja avaliar: ");
            string vKeyDicionario = Console.ReadLine()!;
            
            if(bandasRegistradas.ContainsKey(vKeyDicionario))
            {
                Console.Write($"Qual nota a banda {vKeyDicionario} merece: ");
                int vNota = int.Parse(Console.ReadLine()!);
                bandasRegistradas[vKeyDicionario].Add(vNota);
                Console.WriteLine($"\nA nota {vNota} para a Banda {vKeyDicionario} foi registrada com sucesso!");
                Thread.Sleep(4000);
                MenuDeOpcoes();

            }
            else
            {
                Console.WriteLine($"\nA banda {vKeyDicionario} não foi encontrada");
                Console.WriteLine("Clique em uma tecla para voltar ao menos principal!");
                Console.ReadKey();
                MenuDeOpcoes();
            }

        }

        void MediaBanda()
        {
            Console.Clear();
            TituloDeOpcoes("Media das Bandas");

            Console.Write("Qual Banda você deseja ver a média: ");
            string vNomeBanda = Console.ReadLine()!;

            if (bandasRegistradas.ContainsKey(vNomeBanda))
            {
                double vMediaBanda = bandasRegistradas[vNomeBanda].Average();
                Console.WriteLine($"A média da banda {vNomeBanda} é {vMediaBanda}");
                Console.WriteLine("Digite uma tecla para voltar a tela principal");
                Console.ReadKey();
                Thread.Sleep(3000); 
            }
            else 
            {
                Console.WriteLine($"A banda {vNomeBanda} não foi registrada");
                Console.WriteLine("Clique em uma tecla para voltar");
                Console.ReadKey();
                MenuDeOpcoes();


            }

        }

        MenuDeOpcoes();
    }
}