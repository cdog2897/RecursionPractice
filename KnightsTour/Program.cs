using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour
{
    internal class Program
    {
        static int BoardSize = 8;
        static int AttemptedMoves = 0;
        static int[] xMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
        static int[] yMove = { 1, 2, 2, 1, -1, -2, -2, -1, };
        static int[,] boardGrid = new int[BoardSize, BoardSize];

        static void Main(string[] args)
        { 
            Console.WriteLine("Select a starting position:");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            solveKT(x, y);
            Console.ReadLine();
        }

        static void solveKT(int startX, int startY)
        {
            // initialization of matrix, value of -1 means "not visited yet"
            for(int x = 0; x < BoardSize; x++)
            {
                for(int y = 0; y < BoardSize; y++)
                {
                    boardGrid[x, y] = -1;
                }
            }
            //int startX = 1;
            //int startY = 3;

            // set starting position for knight
            boardGrid[startX, startY] = 0;

            // count the guesses
            AttemptedMoves = 0;

            if(!solveKTUtil(startX, startY, 1))
            {
                Console.WriteLine("Solution does not exist for {0} {1}", startX, startY);
            }
            else
            {
                printSolution(boardGrid);
                Console.WriteLine("Attempted moves = {0}", AttemptedMoves);
            }
        }

        // recursive utility function to solve problem
        static bool solveKTUtil(int x, int y, int moveCount)
        {
            AttemptedMoves++;
            if(AttemptedMoves % 1000000 == 0)
            {
                Console.WriteLine("Attempts: {0}", AttemptedMoves);
            }
            int k, next_x, next_y;
            
            // see if we have reached a solution
            if(moveCount == BoardSize * BoardSize)
            {
                return true;
            }
            
            for(k = 0; k < 8; k++)
            {
                next_x = x + xMove[k];
                next_y = y + yMove[k];
                if(isSquareSafe(next_x, next_y))
                {
                    boardGrid[next_x, next_y] = moveCount;
                    if(solveKTUtil(next_x, next_y, moveCount+1))
                    {
                        return true;
                    }
                    // backtracking
                    else
                    {
                        boardGrid[next_x, next_y] = -1;
                    }
                }
            }
            return false;
        }

        // a utility function to check if the move is already visited
        static bool isSquareSafe(int x, int y)
        {
            return (x >= 0 && x < BoardSize &&
                    y >= 0 && y < BoardSize &&
                    boardGrid[x, y] == -1);
        }

        static void printSolution(int[,] solution)
        {
            for(int x = 0; x < BoardSize; x++)
            {
                for(int y = 0; y < BoardSize; y++)
                {
                    Console.Write(solution[x, y] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
