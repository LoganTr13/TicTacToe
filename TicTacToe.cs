using System;
using System.Threading;

namespace TicTacToe
{
    class Program
    {
        static char[,] grid = new char[4,4];
        static char playerAtual = 'X';
        static int p = 0;

        static void Main()
        {            
            grid[1,1] = '#'; grid[1,2] = '#'; grid[1,3] = '#';

            grid[2,1] = '#'; grid[2,2] = '#'; grid[2,3] = '#';

            grid[3,1] = '#'; grid[3,2] = '#'; grid[3,3] = '#';

            Board();
            gameLoop();            
        }

        static void gameLoop()
        {
            
            int Ln, Col;
            while (true)
            {
                //Tratamento de Caracter//
                Console.WriteLine("Vez Do " + playerAtual);
                Console.Write("Escreva a linha, entre 1 a 3: ");
                string Linha = Console.ReadLine();
                Ln = Convert.ToInt16(Linha[0]) - 48;
                Console.Clear();
                Board();
                Console.WriteLine("Vez Do " + playerAtual);
                Console.Write("Escreva a Coluna, entre 1 a 3: ");
                string Coluna = Console.ReadLine();
                Col = Convert.ToInt16(Coluna[0]) - 48;
                //Fim Do Tratamento//

                if(grid[Ln,Col] == '#')
                {
                    grid[Ln,Col] = playerAtual;
                    rules();
                    if(playerAtual == 'X')  {playerAtual = 'O';}
                    else  {playerAtual = 'X';}
                }else{
                    Console.Clear();
                    Console.WriteLine("A área escolhida ja esta ocupada, tente novamente...");
                    Thread.Sleep(3000);
                }
                Console.Clear();
                Board();
            }
        }
        static void Board()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    " + grid[1,1] + " | " + grid[1,2] + " | " + grid[1,3]);
            Console.WriteLine("    ---------");
            Console.WriteLine("    " + grid[2,1] + " | " + grid[2,2] + " | " + grid[2,3]);
            Console.WriteLine("    ---------");
            Console.WriteLine("    " + grid[3,1] + " | " + grid[3,2] + " | " + grid[3,3]);
            Console.WriteLine();
        }
        static void rules()
        {
            
            if(grid[1,3] == grid[2,2] && grid[2,2] == grid[3,1] && grid[2,2] != '#')
            {
                Console.Clear();
                Console.WriteLine(playerAtual + " venceu!");
                Console.ReadLine();
            }
            if(grid[1,1] == grid[2,2] && grid[2,2] == grid[3,3] && grid[2,2] != '#')
            {
                Console.Clear();
                Console.WriteLine(playerAtual + " venceu!");
                Console.ReadLine();
            }
            for (int l = 1; l < 4; l++)
            {
                for (int c = 1; c < 4; c++)
                {
                    if(grid[l,c] == playerAtual)
                    {
                        p++;
                        if(p == 3)
                        {
                            Console.Clear();
                            Console.WriteLine(playerAtual + " venceu!"); 
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        p = 0;
                        break;                  
                    }
                }
            }
            for (int c = 1; c < 4; c++)
            {
                for (int l = 1; l < 4; l++)
                {
                    if(grid[l,c] == playerAtual)
                    {
                        p++;
                        if(p == 3)
                        {
                            Console.Clear();
                            Console.WriteLine(playerAtual + " venceu!");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        p = 0;
                        break;                        
                    }
                }
            }
        }
    }
}
