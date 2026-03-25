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

    static void ExecutarPartida(
        int limiteLinhaChegada,
        int bonusAvancoExtra,
        int penalidadeRecuo
    )
    {
        
        while (true)
        {


            int posicaoJogador = 0;
            int posicaoComputador = 0;

            
            while (true)
            {
                posicaoJogador = Jogador.ExecutarRodada(
                    posicaoJogador,
                    limiteLinhaChegada,
                    bonusAvancoExtra,
                    penalidadeRecuo
                );

                if (posicaoJogador >= limiteLinhaChegada)
                    break;

                posicaoComputador = Computador.ExecutarRodada(
                    posicaoComputador,
                    limiteLinhaChegada,
                    bonusAvancoExtra,
                    penalidadeRecuo
                );

                if (posicaoComputador >= limiteLinhaChegada)
                    break;
            }

            if (!JogadorDesejaContinuar())
                break;
        }
    }
    
    static bool JogadorDesejaContinuar()
    {
        Console.Write("Deseja continuar? (s/N): ");
        string? opcaoContinuar = Console.ReadLine()?.ToUpper();

        if (opcaoContinuar != "S")
            return false;

        return true;
    }
}