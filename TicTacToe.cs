using System;
using System.Threading;

namespace TicTacToe {
    class Program {
        static char[,] grid = new char[3,3];
        static char currentPlayer = 'X';
        static bool winState = false;
        static bool tieState = false;
        static string currentPlayerColor;
        static int Main() {
            ClearGrid();
            Console.Clear();
            while(!winState && !tieState) {
                currentPlayerColor = ((currentPlayer == 'X') ? "\u001b[1;31m" : "\u001b[1;36m") +currentPlayer+"\u001b[0m";
                int Ln, Col;
                // get line
                PrintGrid();
                Console.WriteLine($"Time of: {currentPlayerColor}");
                Console.Write("L  Write Line, 1-3: ");
                string choiceLine = Console.ReadLine();
                Ln = Convert.ToInt16(choiceLine[0]-1) - 48;
                Console.Clear();
                // get colum
                PrintGrid();
                Console.WriteLine($"time of: {currentPlayerColor}");
                Console.Write($"L{Ln+1} Write Colum, 1-3: ");
                string choiceColum = Console.ReadLine();
                Col = Convert.ToInt16(choiceColum[0]-1) - 48;
                Console.Clear();

                if(grid[Ln,Col] == '*') {
                    grid[Ln,Col] = currentPlayer;
                    winState = CheckWinner();
                    if(!winState) currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    else break;
                } else {
                    Console.Clear();
                    Console.WriteLine("\n  It's not your local, try again. (enter to continue)");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            if(!tieState) {
                Console.Clear();
                PrintGrid();
                Console.WriteLine($"\nCongratulations! player {currentPlayerColor} has win! (enter to exit)");
                Console.ReadLine();
                return 0;
            }
            Console.Clear();
            PrintGrid();
            Console.WriteLine($"\nThe game have tied. (enter to exit)");
            Console.ReadLine();
            return 0;
        }
        static void PrintGrid() {
            Console.Write("\n\n    1 2 3\n");
            for(int i=0;i<3;i++) {
                Console.Write($"  {i+1} ");
                for(int j=0;j<3;j++) {
                    string colorMake = ((grid[i,j] == 'X') ? "\u001b[1;31m" : (grid[i,j] == 'O') ? "\u001b[1;36m" : "\u001b[37m");
                    Console.Write($"{colorMake}{grid[i,j]}\u001b[0m ");
                }
                Console.WriteLine();
            }
            Console.Write("\n");
        }
        static void ClearGrid() {
            for(int i=0;i<9;i++) {
                grid[i/3,i%3] = '*';
            }
        }
        static bool CheckWinner() {
            int tieCount = 0;
            for(int i=0;i<9;i++) {
                tieCount = (grid[i/3,i%3] != '*') ? tieCount+1 : tieCount;
            }
            tieState = (tieCount==9);
            for(int i = 0; i < 3; i++) {
                if (grid[i, 0] != '*' && grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2]||
                    grid[0, i] != '*' && grid[0, i] == grid[1, i] && grid[1, i] == grid[2, i]) return true;
            }
            return (grid[0, 0] != '*' && grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2]) ||
                (grid[0, 2] != '*' && grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0]);
        }
    }
}