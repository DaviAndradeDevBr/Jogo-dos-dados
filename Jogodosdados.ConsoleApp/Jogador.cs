using System.Security.Cryptography;

namespace Jogodosdados.ConsoleApp;

static class Jogador
{
    public static int ExecutarRodada(
        int posicaoJogador,
        int limiteLinhaChegada,
        int bonusAvancoExtra,
        int penalidadeRecuo
    )
    {
        do
        {
            ExibirCabecalho();

            Console.Write("Pressione ENTER para lançar um dado...");
            Console.ReadLine();

            int resultadoJogador = RandomNumberGenerator.GetInt32(1, 7);

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"O número sorteado foi: {resultadoJogador}");
            Console.WriteLine("-------------------------------------------");

            posicaoJogador += resultadoJogador;

            Console.WriteLine($"Você está na posição: {posicaoJogador} de {limiteLinhaChegada}");

            if (posicaoJogador == 5 || posicaoJogador == 10 || posicaoJogador == 15 || posicaoJogador == 25)
            {
                Console.WriteLine($"\nEVENTO: Avanço de {bonusAvancoExtra} casas!");
                posicaoJogador += bonusAvancoExtra;

                Console.WriteLine($"\nVocê está na posição: {posicaoJogador} de {limiteLinhaChegada}");
            }

            else if (posicaoJogador == 7 || posicaoJogador == 13 || posicaoJogador == 20)
            {
                Console.WriteLine($"\nEVENTO: Recuo de {penalidadeRecuo} casas");
                posicaoJogador -= penalidadeRecuo;

                Console.WriteLine($"\nVocê está na posição: {posicaoJogador} de {limiteLinhaChegada}");
            }

            if (posicaoJogador >= limiteLinhaChegada)
            {
                Console.WriteLine("\nParabéns! Você alcançou a linha de chegada.");

                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();

                break;
            }

            if (resultadoJogador == 6)
            {
                Console.WriteLine($"\nEVENTO: Rodada Extra!");
                Console.WriteLine("-------------------------------------------");

                Console.Write("\nPressione ENTER para jogar novamente...");
                Console.ReadLine();

                continue;
            }
            else
            {
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();

                break;
            }
        } while (true);

        return posicaoJogador;
    }

    private static void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine($"Rodada do Jogador");
        Console.WriteLine("-------------------------------------------");
    }
}
