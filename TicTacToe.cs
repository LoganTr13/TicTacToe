using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] grid = new char[3,3];
        static char playerAtual = 'X';

        static void Main()
        {            
            grid[0,0] = '#'; grid[0,1] = '#'; grid[0,2] = '#';

            grid[1,0] = '#'; grid[1,1] = '#'; grid[1,2] = '#';

            grid[2,0] = '#'; grid[2,1] = '#'; grid[2,2] = '#';

            Console.WriteLine(grid[0,0] + " | " + grid[0,1] + " | " + grid[0,2]);
            Console.WriteLine(grid[1,0] + " | " + grid[1,1] + " | " + grid[1,2]);
            Console.WriteLine(grid[2,0] + " | " + grid[2,1] + " | " + grid[2,2]);

            gameLoop();            
        }

        static void gameLoop()
        {
            
            int Ln, Col;
            while (true)
            {
                Console.WriteLine(playerAtual + " coloque a posição da linha entre 0 e 2");
                Ln = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("posição da Coluna entre 0 e 2");
                Col = Convert.ToInt32(Console.ReadLine());

                grid[Ln,Col] = playerAtual;

                Console.WriteLine(grid[0,0] + " | " + grid[0,1] + " | " + grid[0,2]);
                Console.WriteLine(grid[1,0] + " | " + grid[1,1] + " | " + grid[1,2]);
                Console.WriteLine(grid[2,0] + " | " + grid[2,1] + " | " + grid[2,2]);
                rules();
                if(playerAtual == 'X')
                {
                    playerAtual = 'O';
                }
                else
                {
                    playerAtual = 'X';
                }
            }
        }
        static void rules()
        {
            int p = 0;
            for (int l = 0; l < 2; l++)
            {
                for (int c = 0; c < 2; c++)
                {
                    if(grid[l,c] == playerAtual)
                    {
                        p++;
                    }
                    else
                    {
                        break;
                        p = 0;
                    }
                }
            }
            for (int c = 0; c < 2; c++)
            {
                for (int l = 0; l < 2; l++)
                {
                    if(grid[l,c] == playerAtual)
                    {
                        p++;
                    }
                    else
                    {
                        break;
                        p = 0;
                    }
                }
            }   
            if(p == 3)
            {
                Console.Clear();
                Console.Write(playerAtual + " Venceu!");
                Console.Read();
            }           
        }

    }
    
}
