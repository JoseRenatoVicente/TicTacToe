namespace JogoVelhaMatriz
{

    internal class TicTacToeService
    {
        public char[,] board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        public char currentPlayer = 'X';
        public string Player1, Player2;

        public bool AddPosition(char position)
        {
            for (int row = 0; row < board.GetLength(0); row++)
                for (int column = 0; column < board.GetLength(1); column++)
                    if (board[row, column] == position)
                    {
                        board[row, column] = currentPlayer;
                        currentPlayer = InvertPlayer();
                    }
            
            if (CheckEarned() != 3)
                return false;

            return true;
        }

        public int CheckEarned()
        {
            string result = "";

            //CheckMainDiagonal
            for (int row = 0; row < board.GetLength(0); row++)
            {
                result += board[row, row];

                if (result == "XXX")
                    return 1;
                else if (result == "OOO")
                    return 2;
            }

            //CheckSecondaryDiagonal
            result = "";
            for (int row = 0; row < board.GetLength(0); row++)
            {
                result += board[row, board.GetLength(0) - 1 - row];

                if (result == "XXX")
                    return 1;
                else if (result == "OOO")
                    return 2;
            }

            //CheckRowsColumns
            for (int i = 0; i < board.GetLength(0); i++)
            {
                string rows = $"{board[i, 0]}{board[i, 1]}{board[i, 2]}";

                string columns = $"{board[0, i]}{board[1, i]}{board[2, i]}";

                if (rows == "XXX" || columns == "XXX")
                    return 1;
                else if (rows == "OOO" || columns == "OOO")
                    return 2;
            }

            //CheckTie
            for (int row = 0; row < board.GetLength(0); row++)
                for (int column = 0; column < board.GetLength(1); column++)
                    if (board[row, column] == ResetBoard()[row, column])
                        return 3;

            return 0;
        }


        public char InvertPlayer() => currentPlayer == 'X' ? 'O' : 'X';
        public char[,] ResetBoard() => new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };

    }
}
