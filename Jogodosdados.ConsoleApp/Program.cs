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

    V2
       1. Refatoração estruturada com extração de métodos
*/


class Program
{
    static void Main(string[] args)
    {
        const int limiteLinhaChegada = 30;
        const int bonusAvancoExtra = 3;
        const int penalidadeRecuo = 2;

        ExecutarPartida(limiteLinhaChegada, bonusAvancoExtra, penalidadeRecuo);
    }

    static void ExecutarPartida(int limite, int bonus, int penalidade)
    {

        while (true)
        {

            
            int posicaoJogador = 0;
            int posicaoComputador = 0;


            while (true)
            {
                // Turno do jogador
                posicaoJogador = ExecutarRodada(posicaoJogador, limite, bonus, penalidade, "Jogador");
                if (posicaoJogador >= limite)
                {
                    Console.WriteLine("\nPARABÉNS! Você alcançou a linha de chegada e venceu.");
                    break;
                }
            

                // Turno do computador
                posicaoComputador = ExecutarRodada(posicaoComputador, limite, bonus, penalidade, "Computador");
                if (posicaoComputador >= limite)
                {
                    Console.WriteLine("\nQUE PENA! O computador alcançou a linha de chegada primeiro.");
                    break;

                }
            }        
            
            Console.WriteLine("\n-------------------------------------------");
            Console.Write("Deseja jogar novamente? (S/N): ");
            string? resposta = Console.ReadLine()?.ToUpper();
            if (resposta != "S") break;
            
        }
    }

    static int ExecutarRodada(int posicao, int limite, int bonus, int penalidade, string quemJoga)
    {
        int resultado;
        do
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"JOGO DOS DADOS - RODADA DO {quemJoga.ToUpper()}");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"Posição atual: {posicao} de {limite}");

            if (quemJoga == "Jogador")
            {
               Console.Write("\nPressione ENTER para lançar o dado...");
               Console.ReadLine();     
            }
            else
            {
               Console.WriteLine("\nO computador está lançando o dado...");
               Thread.Sleep(1000); // Pausa para lançar o dado     
            }

            resultado = RandomNumberGenerator.GetInt32(1, 7);
            Console.WriteLine($"Número sorteado: {resultado}");
            posicao += resultado;

            // Verificação de eventos especiais
            if (posicao == 5 || posicao == 10 || posicao == 15 || posicao == 25)
            {
               Console.WriteLine($"EVENTO: Parou em casa de bônus! Avança +{bonus} casas.");
               posicao += bonus;     
            }
            else if (posicao == 7 || posicao == 13 || posicao == 20)
            {
               Console.WriteLine($"EVENTO: Parou em casa de recuo! Volta -{penalidade} casas.");
               posicao -= penalidade;     
            }

            Console.WriteLine($"Nova posição: {posicao}");

            if (posicao >= limite) break;

            // Requisito: Rodada extra se tirar 6
            if (resultado == 6)
            {
               Console.WriteLine("\n>>> DADO 6! Ganhou uma RODADA EXTRA! <<<");
               Console.Write("Pressione ENTER para continuar...");
               Console.ReadLine();     
            }
            else
            {
               Console.Write("\nPressione ENTER para encerrar o turno...");
               Console.ReadLine();     
            }
        
        } while (resultado == 6); // Repete se tirar 6 

        return posicao;
    }
}                  
