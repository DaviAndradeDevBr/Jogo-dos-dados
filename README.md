# Jogo dos Dados  🎲



## Introdução

O Jogo dos Dados é um simulador de corrida baseado em turnos, onde o jogador compete contra o computador. Esta versão foi **refatorada utilizando paradigmas de programação estruturada**, organizando a lógica em métodos modulares para facilitar a manutenção e leitura do código.

## Regras do Jogo 📜

1. **Pista**: O objetivo é alcançar ou ultrapassar a marca de **30 casas**.
2. **Turnos**: O jogador e o computador alternam jogadas.
3. **Sorteio**: Um dado de 6 faces determina o avanço em cada jogada.
4. **Eventos Especiais**:
   - **Avanço Extra (+3 casas)**: Ocorre nas posições 5, 10, 15 e 25.
   - **Recuo (-2 casas)**: Ocorre nas posições 7, 13 e 20.
   - **Rodada Extra**: Se o competidor tirar o número **6** no dado, ele ganha o direito de jogar novamente.

5. **Vitória**: O primeiro a atingir o limite da pista vence a partida.

## Diferenciais desta Versão 💎

- **Modularização**: Lógica extraída para métodos específicos (`ExecutarPartida` e `ExecutarRodada`).
- **Inteligência de Turno**: O sistema identifica automaticamente se é a vez do usuário (solicitando input) ou do computador (com pausas dramáticas).
- **Tratamento de Acentos**: Interface limpa e mensagens interativas.

## Instruções de Uso 💻

1.  Obtenha o código via clone de repositório ou download do arquivo `.zip`.
2.  Acesse o diretório raiz através do terminal.
3.  Utilize o comando abaixo para restaurar as dependências:
    ```bash
    dotnet restore
    ```
4.  Inicie a aplicação:
    ```bash
    dotnet run --project jogodosdados.ConsoleApp


## Requisitos de Sistema

.NET SDK 10.0 ou superior.
