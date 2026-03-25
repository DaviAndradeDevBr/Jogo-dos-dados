using System.Security.Cryptography;

namespace Jogodosdados.ConsoleApp;

static class Computador
{
    public static int ExecutarRodada(
        int posicaoComputador,
        int limiteLinhaChegada,
        int bonusAvancoExtra,
        int penalidadeRecuo
    )
    {
        do
        {
            ExibirCabecalho();

            int resultadoComputador = RandomNumberGenerator.GetInt32(1, 7);

            Console.WriteLine($"O número sorteado foi: {resultadoComputador}");
            Console.WriteLine("-------------------------------------------");

            posicaoComputador += resultadoComputador;

            Console.WriteLine($"O computador está na posição: {posicaoComputador} de {limiteLinhaChegada}");

            if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15 || posicaoComputador == 25)
            {
                Console.WriteLine($"\nEVENTO: Avanço de {bonusAvancoExtra} casas!");
                posicaoComputador += bonusAvancoExtra;

                Console.WriteLine($"\nO computador está na posição: {posicaoComputador} de {limiteLinhaChegada}");
            }

            else if (posicaoComputador == 7 || posicaoComputador == 13 || posicaoComputador == 20)
            {
                Console.WriteLine($"\nEVENTO: Recuo de {penalidadeRecuo} casas");
                posicaoComputador -= penalidadeRecuo;

                Console.WriteLine($"\nO computador está na posição: {posicaoComputador} de {limiteLinhaChegada}");
            }

            if (posicaoComputador >= limiteLinhaChegada)
            {
                Console.WriteLine("\nQue pena! O computador alcançou a linha de chegada.");

                break;
            }

            if (resultadoComputador == 6)
            {
                Console.WriteLine($"\nEVENTO: Rodada Extra!");
                Console.WriteLine("-------------------------------------------");

                Console.Write("\nPressione ENTER para continuar...");
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

        return posicaoComputador;
    }

    private static void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine($"Rodada do Computador");
        Console.WriteLine("-------------------------------------------");
    }
}
