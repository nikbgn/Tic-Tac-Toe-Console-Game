using System;

namespace Tic_Tac_Toe_Console_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            char player1Symbol = 'X';
            char player2Symbol = 'O';
            int turn = 0;
            char[] gameBoard = new char[9] { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
            string winner = string.Empty;

            Console.WriteLine("Welcome to my simple tic tac toe game. You can place a symbol on the board by selecting its place on the board (0-8)\n");

            while (true)
            {
                visualiseBoard(gameBoard);

                int checkWinner = gameWonDecider(gameBoard);


                switch (checkWinner)
                {
                    case 1:
                        Console.WriteLine("Player 1 wins!");
                        return;

                    case 2:
                        Console.WriteLine("Player 2 wins!");
                        return;
                    case 3:
                        Console.WriteLine("Draw!");
                        return;
                    default:
                        break;
                }
                if (turn % 2 == 0)
                {
                    gameBoard = playTurn(player1Symbol, gameBoard);
                }
                else
                {
                    gameBoard = playTurn(player2Symbol, gameBoard);
                }
                turn++;

            }

        }

        private static void visualiseBoard(char[] gameBoard)
        {

            string outPutBoard = $"| {gameBoard[0]} | {gameBoard[1]} | {gameBoard[2]} |\n| {gameBoard[3]} | {gameBoard[4]} | {gameBoard[5]} |\n| {gameBoard[6]} | {gameBoard[7]} | {gameBoard[8]} | \n";
            Console.WriteLine(outPutBoard);
        }

        private static char[] playTurn(char playerSymbol, char[] gameBoard)
        {
            //Find if the spot selected by the player is legal
            while (true)
            {
                int place = int.Parse(Console.ReadLine());
                if (verifyLegalTurn(place, gameBoard))
                {
                    gameBoard[place] = playerSymbol;
                    break;
                }

            }
            return gameBoard;
        }

        private static bool verifyLegalTurn(int place, char[] gameBoard)
        {
            bool isLegal = false;
            //Make sure that the player doesn't input anything that is outside of the board.
            if (place >= gameBoard.Length || place < 0)
            {
                Console.WriteLine("THAT SPOT DOES NOT EXIST... :)");
                return isLegal;
            }
            //Empty places in the board are marked as '-'
            if (gameBoard[place] == '-') { isLegal = true; }
            else
            {
                Console.WriteLine("ILLEGAL MOVE!");
            }
            return isLegal;
        }

        private static int gameWonDecider(char[] gameBoard)
        {
            bool isBoardFilled = true;
            foreach (char elem in gameBoard)
            {
                if (elem == '-') { isBoardFilled = false; break; }
            }
            if (isBoardFilled) return 3;

            //Check for P1 Win:
            if (rowCheck(gameBoard, 264) || colCheck(gameBoard, 264) || diagonalCheck(gameBoard, 264)) { return 1; }//p1win!
            //Check for P2 Win:
            else if (rowCheck(gameBoard, 237) || colCheck(gameBoard, 237) || diagonalCheck(gameBoard, 237)) { return 2; } //p2win!

            //X+X+X = 264
            //O+O+O = 237
            return 4;
        }


        //Functions to check if someone has 3 connected symbols, meeting the win criteria.
        private static bool diagonalCheck(char[] gameBoard, int target)
        {
            bool detectedWin = false;
            int sum1Diag = gameBoard[0] + gameBoard[4] + gameBoard[8];
            int sum2Diag = gameBoard[2] + gameBoard[4] + gameBoard[6];

            if (sum1Diag == target || sum2Diag == target) { detectedWin = true; }
            return detectedWin;
        }

        private static bool colCheck(char[] gameBoard, int target)
        {
            bool detectedWin = false;
            int sum1Row = gameBoard[0] + gameBoard[3] + gameBoard[6];
            int sum2Row = gameBoard[1] + gameBoard[4] + gameBoard[7];
            int sum3Row = gameBoard[2] + gameBoard[5] + gameBoard[8];


            if (sum1Row == target || sum2Row == target || sum3Row == target) { detectedWin = true; }
            return detectedWin;
        }

        private static bool rowCheck(char[] gameBoard, int target)
        {
            bool detectedWin = false;
            int sum1Row = gameBoard[0] + gameBoard[1] + gameBoard[2];
            int sum2Row = gameBoard[3] + gameBoard[4] + gameBoard[5];
            int sum3Row = gameBoard[6] + gameBoard[7] + gameBoard[8];


            if (sum1Row == target || sum2Row == target || sum3Row == target) { detectedWin = true; }
            return detectedWin;
        }
    }
}
