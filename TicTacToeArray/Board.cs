using System;

namespace JogoVelhaMatriz
{
    internal class Board
    {
        TicTacToeService ticTacToeService = new TicTacToeService();

        public void InputPosition()
        {
            Console.WriteLine("Vez do Jogador " +
                (ticTacToeService.currentPlayer == 'X' ? ticTacToeService.Player1 : ticTacToeService.Player2));

            Console.WriteLine("Digite a posição");
            if (!char.TryParse(Console.ReadLine(), out char position))
            {
                Console.WriteLine("Posição inválida");
                InputPosition();
            }

            if (ticTacToeService.AddPosition(position))
                ShowBoard();
            else
                ShowWinner();
        }

        public void ShowWinner()
        {
            int status = ticTacToeService.CheckEarned();

            if (status > 0 && status < 3)
                Console.WriteLine($"O jogador {(status == 1 ? ticTacToeService.Player1 : ticTacToeService.Player1)} ganhou");
            else if (status == 0)
                Console.WriteLine("Deu velha!");

            ticTacToeService.board = ticTacToeService.ResetBoard();
        }

        public void ShowBoard()
        {
            Console.Clear();

            for (int row = 0; row < ticTacToeService.board.GetLength(0); row++)
            {
                for (int column = 0; column < ticTacToeService.board.GetLength(1); column++)
                {
                    Console.Write($" \t|{ticTacToeService.board[row, column]}|");
                }
                Console.WriteLine();
                Console.WriteLine("\t-------------------");
            }
            InputPosition();
        }

        public void InputPlayer()
        {
            Console.Clear();

            Console.WriteLine("Digite o nome do Jogador 1 (X)");
            ticTacToeService.Player1 = Console.ReadLine() + "(X)";

            Console.WriteLine("Digite o nome do Jogador 2 (O)");
            ticTacToeService.Player2 = Console.ReadLine() + "(O)";

            ShowBoard();
        }


        public void Menu()
        {

            Console.WriteLine(@"
       dP                                     dP                               dP dP                
       88                                     88                               88 88                
       88 .d8888b. .d8888b. .d8888b.    .d888b88 .d8888b.    dP   .dP .d8888b. 88 88d888b. .d8888b. 
       88 88'  `88 88'  `88 88'  `88    88'  `88 88'  `88    88   d8' 88ooood8 88 88'  `88 88'  `88 
88.  .d8P 88.  .88 88.  .88 88.  .88    88.  .88 88.  .88    88 .88'  88.  ... 88 88    88 88.  .88 
 `Y8888'  `88888P' `8888P88 `88888P'    `88888P8 `88888P8    8888P'   `88888P' dP dP    dP `88888P8 
                    ~~~~.88
                    d8888P                      

                                1) Iniciar o jogo
                                ------------------------------
                                0) - Sair
");

            string option = Console.ReadLine();

            switch (option)
            {
                case "0": Environment.Exit(0); break;

                case "1":
                    InputPlayer();
                    BackMenu();
                    break;

                default:
                    Console.WriteLine("Opção inválida! ");
                    BackMenu();
                    break;
            }

        }

        public void BackMenu()
        {
            Console.WriteLine("\n Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
}
