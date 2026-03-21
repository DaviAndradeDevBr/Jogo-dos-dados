using System.Security.Cryptography;

namespace Jogodosdados.ConsoleApp;


/*
1. Pista:
    ○ A pista é representada por uma linha numérica (ex.: de 0 a 30).
    ○ O jogador e o computador começam na posição 0.
2. Turnos:
    ○ O jogador e o computador alternam turnos para rolar um dado (gerar um número aleatório
    entre 1 e 6).
    ○ O número gerado é somado à posição atual do competidor.
    ○ O jogo exibe a posição atual do jogador e do computador após cada rodada.
3. Eventos Especiais:
    ○ Para tornar o jogo mais interessante, algumas posições na pista podem ter eventos especiais:
    ■ Avanço extra: Se o competidor parar em uma posição específica (ex.: 5, 10, 15), ele
    avança +3 casas.
    ■ Recuo: Se o competidor parar em outra posição específica (ex.: 7, 13, 20), ele recua -2
    casas.
    ■ Rodada extra: Se o competidor tirar 6 no dado, ele ganha uma rodada extra.

4. Condição de Vitória:
    ○ O primeiro competidor a alcançar ou ultrapassar a posição final (ex.: 30) vence o jogo.
*/


class Program
{
    static void Main(string[] args)
    {
        const int limiteLinhaChegada = 30;
        const int bonusAvancoExtra = 3;
        const int penalidadeRecuo = 2;


        while (true)
        {


            int posicaoJogador = 0;
            int posicaoComputador = 0;
            bool jogoEstaEmAndamento = true;

            while (jogoEstaEmAndamento) 
            {
                // --- TURNO DO JOGADOR ---
                Console.Clear();
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Jogo dos Dados");
                Console.WriteLine("-------------------------------------------");


                // Lógica do Jogo
                Console.Write("Pressione ENTER para lançar um dado...");
                Console.ReadLine();

                int resultadoJogador = RandomNumberGenerator.GetInt32(1, 7);
                Console.WriteLine($"O número sorteado foi: {resultadoJogador}");
                posicaoJogador += resultadoJogador;

                if (posicaoJogador == 5 || posicaoJogador == 10 || posicaoJogador == 15 || posicaoJogador == 25)
                {
                    
                    Console.WriteLine($"EVENTO: Avanço de {bonusAvancoExtra} casas!");
                    posicaoJogador += bonusAvancoExtra;


                }
                else if (posicaoJogador == 7 || posicaoJogador == 13 || posicaoJogador == 20)
                {
                    Console.WriteLine($"EVENTO: Recuo de {penalidadeRecuo} casas");
                    posicaoJogador -= penalidadeRecuo;


                }

                if (posicaoJogador >= limiteLinhaChegada)
                {

                    Console.WriteLine("\nParabéns! Você alcançou a linha de chegada.");
                    jogoEstaEmAndamento = false;
                    break;
                }

                // --- TURNO DO COMPUTADOR ---
                Console.WriteLine("\n-------------------------------------------");
                Console.WriteLine("Rodada do Computador");
                int resultadoComputador = RandomNumberGenerator.GetInt32(1, 7);
                Console.WriteLine($"O computador sorteou: {resultadoComputador}");
                posicaoComputador += resultadoComputador;

                if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15 || posicaoComputador == 25)
                {
                    posicaoComputador += bonusAvancoExtra;
                }
                else if (posicaoComputador == 7 || posicaoComputador == 13 || posicaoComputador == 20)
                {
                    posicaoComputador -= penalidadeRecuo;
                }

                Console.WriteLine($"Computador está na posição: {posicaoComputador}");

                if (posicaoComputador >= limiteLinhaChegada)
                {
                    Console.WriteLine("\nO computador venceu!");
                    jogoEstaEmAndamento = false;
                    break;
                }

                Console.Write("\nPressione ENTER para o próximo turno...");
                Console.ReadLine();
            }

            Console.Write("\nDeseja continuar? (S/N): ");
            string? opcaoContinuar = Console.ReadLine()?.ToUpper();


            if (opcaoContinuar != "S")
            {
                break;
            }

        }

    }

}
